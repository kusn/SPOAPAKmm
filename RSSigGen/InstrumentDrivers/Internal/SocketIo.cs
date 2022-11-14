using System;
using System.Text;
using System.Text.RegularExpressions;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal static class SocketIo
    {
        internal static int viOpenDefaultRM(out int rmSession)
        {
            rmSession = ResourceManager.GetNewSessionHandle();
            return 0;
        }

        internal static int viOpen(int rmSession, string resource, uint accessMode, uint timeOut, out int session)
        {
            session = 0;
            Match match = new Regex("TCPIP::([^:]+)::(\\d+)::SOCKET", RegexOptions.IgnoreCase).Match(resource);
            if (!match.Success)
            {
                string lastError = "ResourceName '" + resource + "' is invalid for the direct SocketIO session. Supported format: 'TCPIP::192.168.1.1::5025::SOCKET'";
                SetLastError(rmSession, lastError);
                return -5001;
            }

            string value = match.Groups[1].Value;
            int port = match.Groups[2].Value.ToInt32();
            VisaSocket visaSocket = new VisaSocket(value, port, '\n');
            visaSocket.Connect();
            session = rmSession;
            ResourceManager.SessionsList[session] = visaSocket;
            return 0;
        }

        //
        // Сводка:
        //     Sets last error for the session
        internal static void SetLastError(int session, string lastError)
        {
            ResourceManager.LastError[session] = lastError;
        }

        //
        // Сводка:
        //     Gets and clears last error for the session
        internal static string GetLastError(int session)
        {
            string result = ResourceManager.LastError[session];
            ResourceManager.LastError[session] = null;
            return result;
        }

        //
        // Сводка:
        //     Closes and disposes of the session
        internal static int viClose(int session)
        {
            if (ResourceManager.SessionsList.ContainsKey(session))
            {
                VisaSocket visaSocket = ResourceManager.SessionsList[session];
                ResourceManager.SessionsList.Remove(session);
                ResourceManager.LastError.Remove(session);
                if (visaSocket != null)
                {
                    visaSocket.Disconnect();
                    visaSocket.Dispose();
                }
            }

            return 0;
        }

        internal static int viClear(int session)
        {
            return 0;
        }

        internal static int viWrite(int session, byte[] buffer, uint length, out uint written)
        {
            written = 0u;
            try
            {
                written = (uint)ResourceManager.SessionsList[session].Write(buffer, (int)length);
            }
            catch (SocketInstrException ex)
            {
                SetLastError(session, ex.Message);
                return -5001;
            }

            return 0;
        }

        internal static int viRead(int session, byte[] buffer, uint length, out uint read)
        {
            read = 0u;
            bool moreDataAvailable;
            try
            {
                read = (uint)ResourceManager.SessionsList[session].Read(buffer, (int)length, out moreDataAvailable);
            }
            catch (SocketInstrException ex)
            {
                SetLastError(session, ex.Message);
                if (ex.Message.Contains("Read timeout"))
                {
                    return -1073807339;
                }

                return -5001;
            }

            if (!moreDataAvailable)
            {
                return 0;
            }

            return 1073676294;
        }

        internal static int viSetAttribute(int session, uint attrName, UIntPtr attrValue)
        {
            switch (attrName)
            {
                case 1073676314u:
                    {
                        uint timeout = attrValue.ToUInt32();
                        ResourceManager.SessionsList[session].Timeout = (int)timeout;
                        return 0;
                    }
                case 1073676344u:
                    {
                        uint num2 = attrValue.ToUInt32();
                        ResourceManager.SessionsList[session].TermCharEnable = num2 != 0;
                        return 0;
                    }
                case 1073676312u:
                    {
                        uint num = attrValue.ToUInt32();
                        ResourceManager.SessionsList[session].TermChar = (char)num;
                        return 0;
                    }
                case 1073676310u:
                    attrValue.ToUInt32();
                    return 0;
                default:
                    {
                        string lastError = $"Attribute {attrName} is not supported or has an non-integer type";
                        SetLastError(session, lastError);
                        return -5001;
                    }
            }
        }

        internal static int viGetAttribute(int session, uint attrName, out UIntPtr attrValue)
        {
            switch (attrName)
            {
                case 1073676314u:
                    {
                        int timeout = ResourceManager.SessionsList[session].Timeout;
                        attrValue = new UIntPtr((uint)timeout);
                        return 0;
                    }
                case 1073676344u:
                    {
                        bool termCharEnable = ResourceManager.SessionsList[session].TermCharEnable;
                        attrValue = new UIntPtr(termCharEnable ? 1u : 0u);
                        return 0;
                    }
                case 1073676312u:
                    {
                        char termChar = ResourceManager.SessionsList[session].TermChar;
                        attrValue = new UIntPtr(termChar);
                        return 0;
                    }
                case 1073676310u:
                    attrValue = new UIntPtr(1u);
                    return 0;
                case 1073676657u:
                    attrValue = new UIntPtr(6u);
                    return 0;
                default:
                    {
                        attrValue = default(UIntPtr);
                        string lastError = $"Attribute {attrName} is not supported or has an non-integer type";
                        SetLastError(session, lastError);
                        return -5001;
                    }
            }
        }

        //
        // Сводка:
        //     String type attributes reading
        internal static int viGetAttribute(int session, uint attrName, StringBuilder attrValue)
        {
            switch (attrName)
            {
                case 3221159937u:
                    attrValue.Append("SOCKET");
                    return 0;
                case 3221160308u:
                    attrValue.Append("Rohde & Schwarz GmbH (Socket IO)");
                    return 0;
                default:
                    {
                        string lastError = $"Attribute {attrName} is not supported or has an non-string type";
                        SetLastError(session, lastError);
                        return -5001;
                    }
            }
        }

        internal static int viStatusDesc(int session, int status, byte[] buffer)
        {
            string text = $"Unknown error {status:X}";
            if (status == -5001)
            {
                text = GetLastError(session);
            }

            Buffer.BlockCopy(Encoding.ASCII.GetBytes(text), 0, buffer, 0, text.Length);
            return 0;
        }

        internal static int viFindRsrc(int rmSession, string expr, out int vi, out int retCount, StringBuilder desc)
        {
            vi = 0;
            retCount = 0;
            return 0;
        }

        internal static int viFindNext(int rmSession, StringBuilder desc)
        {
            return 0;
        }
    }
}
