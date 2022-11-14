using System;
using System.Net;
using System.Net.Sockets;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class VisaSocket : Socket
    {
        //
        // Сводка:
        //     Server IP Address
        internal string IpAddress { get; set; }

        //
        // Сводка:
        //     Server Port number
        internal int Port { get; set; }

        //
        // Сводка:
        //     Read Termination character
        internal char TermChar { get; set; }

        //
        // Сводка:
        //     Read Termination character enable
        internal bool TermCharEnable { get; set; }

        //
        // Сводка:
        //     Set timeout - write and receive
        internal int Timeout
        {
            get
            {
                return base.ReceiveTimeout;
            }
            set
            {
                int num3 = (base.ReceiveTimeout = (base.SendTimeout = value));
            }
        }

        //
        // Сводка:
        //     Empty Constructor
        internal VisaSocket(char termChar)
            : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        {
            TermChar = termChar;
            TermCharEnable = true;
        }

        //
        // Сводка:
        //     Constructor with IP Address and port
        internal VisaSocket(string ipAddress, int port, char termChar)
            : this(termChar)
        {
            IpAddress = ipAddress;
            Port = port;
        }

        public override string ToString()
        {
            string arg = (base.Connected ? "Connected" : "NotConnected");
            return $"VisaSocket {IpAddress}:{Port} ({arg})";
        }

        //
        // Сводка:
        //     Initialize connection
        internal void Connect()
        {
            IPAddress address = IPAddress.Parse(IpAddress);
            try
            {
                Connect(address, Port);
            }
            catch (SocketException)
            {
                _Throw("Establishing the connection to the instrument failed");
            }

            if (!base.Connected)
            {
                _Throw("Establishing the connection to the instrument failed");
            }
        }

        //
        // Сводка:
        //     Internal handling of exceptions
        //
        // Параметры:
        //   message:
        private void _Throw(string message)
        {
            message = $"SocketIO IP {IpAddress} port {Port}: " + message;
            throw new SocketInstrException(IpAddress, Port, message.Trim());
        }

        //
        // Сводка:
        //     Write bytes
        internal int Write(byte[] buffer, int count)
        {
            if (!base.Connected)
            {
                _Throw("Connection is not valid");
            }

            try
            {
                return Send(buffer, 0, count, SocketFlags.None);
            }
            catch (SocketException ex)
            {
                _Throw("Error during writing. Details: " + ((Exception)(object)ex).Message);
            }

            return 0;
        }

        //
        // Сводка:
        //     Read bytes
        internal int Read(byte[] buffer, int maxLen, out bool moreDataAvailable)
        {
            if (!base.Connected)
            {
                _Throw("Connection is not valid");
            }

            bool flag = false;
            int num = 0;
            int num2 = 0;
            while (true)
            {
                int num3 = maxLen - num;
                if (num3 <= 0)
                {
                    break;
                }

                try
                {
                    int num4 = Receive(buffer, num, num3, SocketFlags.None);
                    num2 = num;
                    num += num4;
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.TimedOut)
                {
                    _Throw($"Read timeout, timeout is set to {base.ReceiveTimeout} ms");
                }

                if (!TermCharEnable)
                {
                    continue;
                }

                int num5 = -1;
                for (int i = num2; i < num; i++)
                {
                    if (buffer[i] == TermChar)
                    {
                        num5 = i;
                        break;
                    }
                }

                if (num5 >= 0)
                {
                    num = num5 + 1;
                    flag = true;
                    break;
                }
            }

            if (num < maxLen)
            {
                moreDataAvailable = false;
            }
            else if (TermCharEnable)
            {
                moreDataAvailable = !flag;
            }
            else
            {
                moreDataAvailable = true;
            }

            return num;
        }

        //
        // Сводка:
        //     Disconnects the session
        internal void Disconnect()
        {
            Disconnect(reuseSocket: false);
        }

        //
        // Сводка:
        //     When cought by the garbage collector, dispose automatically
        ~VisaSocket()
        {
            Dispose(disposing: false);
        }
    }
}
