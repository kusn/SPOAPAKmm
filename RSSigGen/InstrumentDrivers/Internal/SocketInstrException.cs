using System;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class SocketInstrException : Exception
    {
        //
        // Сводка:
        //     Server IP Address
        internal string IpAddress;

        //
        // Сводка:
        //     Server Port number
        internal int Port;

        internal SocketInstrException(string ipAddress, int port, string message)
            : base(message)
        {
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
