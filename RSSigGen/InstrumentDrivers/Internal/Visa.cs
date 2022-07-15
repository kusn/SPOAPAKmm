using System;
using System.IO;
using System.Text;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class Visa : IDisposable
    {
        //
        // Сводка:
        //     VisaC object
        private VisaC _visaC;

        private object _readLocker;

        private VisaResourceManager _rsrcManager;

        //
        // Сводка:
        //     Buffer for reading from instrument
        private readonly byte[] _buffer = new byte[1000000];

        private int? _cachedTimeout;

        //
        // Сводка:
        //     Keeps the SRQ installed handler reference
        private VisaC.EventHandler _installedVisaCsrqHandler;

        protected int InterfaceType { get; }

        protected string ResourceClass { get; }

        internal bool HasDirectSession { get; }

        //
        // Сводка:
        //     VISA timeout in milliseconds
        internal int Timeout
        {
            get
            {
                if (!_cachedTimeout.HasValue)
                {
                    _cachedTimeout = _GetAttributeInt(1073676314u);
                }

                return _cachedTimeout.Value;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("TimeoutMs");
                }

                if (_cachedTimeout.HasValue)
                {
                    if (value != _cachedTimeout.Value)
                    {
                        _SetAttributeInt(1073676314u, value);
                    }
                }
                else
                {
                    _SetAttributeInt(1073676314u, value);
                }

                _cachedTimeout = value;
            }
        }

        //
        // Сводка:
        //     Enable termination character when Reading
        internal bool ReadTermCharEnabled
        {
            get
            {
                return _GetAttributeInt(1073676344u) == 1;
            }
            set
            {
                _SetAttributeInt(1073676344u, value ? 1 : 0);
            }
        }

        //
        // Сводка:
        //     Define termination character when Reading
        internal int ReadTermChar
        {
            get
            {
                return _GetAttributeInt(1073676312u);
            }
            set
            {
                _SetAttributeInt(1073676312u, value);
            }
        }

        //
        // Сводка:
        //     Send End Enable when Writing
        internal bool SendEndEnable
        {
            get
            {
                return _GetAttributeInt(1073676310u) == 1;
            }
            set
            {
                _SetAttributeInt(1073676310u, value ? 1 : 0);
            }
        }

        //
        // Сводка:
        //     Serial Port Send End In
        internal int SerialSendEndIn
        {
            get
            {
                return _GetAttributeInt(1073676467u);
            }
            set
            {
                _SetAttributeInt(1073676467u, value);
            }
        }

        //
        // Сводка:
        //     Serial Port Send End Out
        internal int SerialSendEndOut
        {
            get
            {
                return _GetAttributeInt(1073676468u);
            }
            set
            {
                _SetAttributeInt(1073676468u, value);
            }
        }

        //
        // Сводка:
        //     Checks whether the TCPIP session is HiSLIP
        internal bool IsHislip => _GetAttributeInt(1073677059u) == 1;

        //
        // Сводка:
        //     Size of the internal buffer used for all read operations
        internal int ReadBufferSize => _buffer.Length;

        //
        // Сводка:
        //     VISA Handle object
        internal VisaSessionHandle Session { get; }

        //
        // Сводка:
        //     VISA Manufacturer string
        internal string VisaManufacturer => _rsrcManager.VisaManufacturer;

        //
        // Сводка:
        //     Returns used VISA name including bittness
        internal string VisaDllName
        {
            get
            {
                if (_visaC != null)
                {
                    return _visaC.VisaDllName;
                }

                return "Visa32.dll (64-bit)";
            }
        }

        //
        // Сводка:
        //     Constructor for the VISA object
        //
        // Параметры:
        //   resourceName:
        //     Standard VISA Resource name or an alias name
        //
        //   directSession:
        //     If you provide a non-null number, the session is reused
        //
        //   visaPlugin:
        //     If non-null, you can use a custom VISA API implementation. Has priority over
        //     resourceName plugin
        //
        //   simulating:
        //     If true, the Visa object is in simulation mode
        internal Visa(string resourceName, byte[] directSession, string visaPlugin, bool simulating)
        {
            _readLocker = new object();
            HasDirectSession = directSession != null;
            _installedVisaCsrqHandler = null;
            if (HasDirectSession)
            {
                Session = new VisaSessionHandle(directSession);
                if (Session.Simulate)
                {
                    _rsrcManager = new VisaResourceManager(resourceName, $"{Session.Plugin} Simulating");
                    InterfaceType = 6;
                    ResourceClass = "TCPIP";
                }
                else
                {
                    _visaC = new VisaC(Session.Plugin);
                    Session.Plugin = _visaC.SelectedPlugin;
                    _rsrcManager = new VisaResourceManager(resourceName, _visaC, Session.RmHandle);
                    InterfaceType = _GetAttributeInt(1073676657u);
                    ResourceClass = _GetAttributeString(3221159937u);
                }

                return;
            }

            if (simulating)
            {
                Session = new VisaSessionHandle(resourceName, visaPlugin, simulate: true);
                _rsrcManager = new VisaResourceManager(resourceName, $"{Session.Plugin} Simulating");
                InterfaceType = 6;
                ResourceClass = "TCPIP";
                return;
            }

            Session = new VisaSessionHandle(resourceName, visaPlugin, simulate: false);
            _visaC = new VisaC(Session.Plugin);
            Session.Plugin = _visaC.SelectedPlugin;
            _rsrcManager = new VisaResourceManager(resourceName, _visaC);
            try
            {
                _rsrcManager.Open();
                Session.RmHandle = _rsrcManager.Handle;
            }
            catch (DllNotFoundException)
            {
                throw new DllNotFoundException("VISA library '" + _visaC.VisaDllName + "' could not be loaded. Make sure you have installed R&S VISA, or other vendor's VISA.");
            }

            try
            {
                _ThrowOnError(_visaC.Open(Session.RmHandle, Session.VisaResourceName, 0u, 0u, out var session), "Error when opening new VISA Session. ResourceName: '" + resourceName + "'");
                Session.Handle = session;
                InterfaceType = _GetAttributeInt(1073676657u);
                ResourceClass = _GetAttributeString(3221159937u);
            }
            catch (VisaException)
            {
                Close();
                throw;
            }
        }

        //
        // Сводка:
        //     String representation of the object: "Visa {manufacturer}, {ResourceClass}, '{resource
        //     name}'"
        public override string ToString()
        {
            if (!Session.ValidRm)
            {
                return "Invalid VISA session";
            }

            if (Session.ValidRm && !Session.ValidConnection)
            {
                return _rsrcManager.VisaManufacturer + " VISA Resource Manager";
            }

            if (!Session.HasDefaultPlugin)
            {
                return _rsrcManager.VisaManufacturer + " Visa session (" + Session.Plugin.ToString() + "), '" + Session.ResourceName + "'";
            }

            return _rsrcManager.VisaManufacturer + " Visa session, '" + Session.ResourceName + "'";
        }

        //
        // Сводка:
        //     Converts the status code into human-readable message
        //
        // Параметры:
        //   status:
        //     Status code from VISA functions
        private string _GetVISAStatusDesc(int status)
        {
            byte[] array = new byte[256];
            if (Session.ValidConnection)
            {
                _visaC.StatusDesc(Session.Handle, status, array);
            }
            else if (Session.ValidRm)
            {
                _visaC.StatusDesc(Session.RmHandle, status, array);
            }
            else
            {
                _visaC.StatusDesc(0, status, array);
            }

            return Encoding.ASCII.GetString(array).TrimEnd('\0');
        }

        //
        // Сводка:
        //     Error handler for all the VISA IOException()
        //
        // Параметры:
        //   status:
        //     Return value from VISA functions
        //
        //   context:
        //     Additional optional text
        private int _ThrowOnError(int status, string context = "")
        {
            if (status < 0)
            {
                string text = (string.IsNullOrEmpty(context) ? $"{this}: " : ((!context.StartsWith("$", StringComparison.Ordinal)) ? $"{this}: {context} " : (context.TrimStart('$') + " ")));
                if (status == -1073807339)
                {
                    text += $"Timeout occurred. VISA timeout is set to {Timeout} ms";
                    throw new VisaTimeoutException(Session.ResourceName, text, Timeout);
                }

                throw new VisaException(message: (status == -1073807343) ? (text + "Given Resource Name is invalid or does not exist. VISA manufacturer: " + _rsrcManager.VisaManufacturer + ", DLL: " + VisaDllName) : ((status == -1073807346 && !Session.ValidConnection) ? (text + "session handle is null. You have probably called Dispose() method on the driver's object or on an object sharing the same VISA session handle.") : ((status != -1073807342) ? (text + $"VISA Error 0x{status:X}: {_GetVISAStatusDesc(status)}") : (text + "VISA manufacturer: " + _rsrcManager.VisaManufacturer + ", DLL: " + VisaDllName))), resourceString: Session.ResourceName);
            }

            return status;
        }

        //
        // Сводка:
        //     Returns true, if entered status code indicates that more data might be available
        //
        // Параметры:
        //   status:
        private bool _MoreDataIsAvailable(int status)
        {
            return status == 1073676294;
        }

        //
        // Сводка:
        //     Read bytes to Stream
        //
        // Параметры:
        //   stream:
        //     Stream to read to
        //
        //   count:
        //     Number of bytes to read
        //
        //   moreDataAvailable:
        //     Returns true, if more data for reading is available
        //
        //   assureResponseEndWithTc:
        //     If true, each VISA read must end with TermChar. If not, the reading continues
        //
        // Возврат:
        //     Number of bytes actually read
        internal int ReadToStream(Stream stream, int count, bool assureResponseEndWithTc, out bool moreDataAvailable)
        {
            byte[] array = new byte[count];
            int status = _visaC.Read(Session.Handle, array, (uint)count, out var read);
            status = _ThrowOnError(status, "Read To Stream -");
            stream.Write(array, 0, (int)read);
            moreDataAvailable = _MoreDataIsAvailable(status);
            if (assureResponseEndWithTc && read < count && read != 0)
            {
                byte b = Convert.ToByte(ReadTermChar);
                if (array[read - 1] != b)
                {
                    status = _visaC.Read(Session.Handle, array, (uint)count - read, out var read2);
                    status = _ThrowOnError(status, "Read To Stream2 -");
                    stream.Write(array, 0, (int)read2);
                    moreDataAvailable = _MoreDataIsAvailable(status);
                    return (int)(read + read2);
                }
            }

            return (int)read;
        }

        //
        // Сводка:
        //     Writes bytes from Stream
        //
        // Параметры:
        //   stream:
        //     Stream to write from
        //
        //   count:
        //     Bytes count to write
        //
        // Возврат:
        //     Bytes count actually written
        internal int WriteFromStream(Stream stream, int count)
        {
            byte[] buffer = new byte[count];
            int length = stream.Read(buffer, 0, count);
            _ThrowOnError(_visaC.Write(Session.Handle, buffer, (uint)length, out var written), "Write To Stream -");
            return (int)written;
        }

        //
        // Сводка:
        //     Get Attribute of Int32 type
        //
        // Параметры:
        //   attributeId:
        //
        // Возврат:
        //     value of the attribute
        private int _GetAttributeInt(uint attributeId)
        {
            if (Session.Simulate)
            {
                return 0;
            }

            _ThrowOnError(_visaC.GetAttributeInt(Session.Handle, attributeId, out var attrValue), "Get Attribute Int32 -");
            return (int)attrValue.ToUInt32();
        }

        //
        // Сводка:
        //     Set Attribute of Int32 type
        //
        // Параметры:
        //   attributeId:
        //
        //   value:
        private void _SetAttributeInt(uint attributeId, int value)
        {
            if (!Session.Simulate)
            {
                _ThrowOnError(_visaC.SetAttribute(Session.Handle, attributeId, (UIntPtr)(ulong)value), "Set Attribute Int32 -");
            }
        }

        //
        // Сводка:
        //     Get Attribute of string type
        //
        // Параметры:
        //   attributeId:
        //
        // Возврат:
        //     value of the attribute
        private string _GetAttributeString(uint attributeId)
        {
            if (Session.Simulate)
            {
                return "";
            }

            StringBuilder stringBuilder = new StringBuilder(256);
            _ThrowOnError(_visaC.GetAttributeString(Session.Handle, attributeId, stringBuilder), "Get Attribute String -");
            return stringBuilder.ToString();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Close();
        }

        //
        // Сводка:
        //     When cought by the garbage collector, dispose automatically
        ~Visa()
        {
            Dispose(disposing: false);
        }

        //
        // Сводка:
        //     Close the resource manager and the visa session
        internal void Close()
        {
            if (HasDirectSession)
            {
                return;
            }

            if (_visaC == null)
            {
                Session.InvalidateHandles();
                return;
            }

            if (Session.ValidRm)
            {
                _rsrcManager.Close();
            }

            if (Session.ValidConnection)
            {
                _visaC.Close(Session.Handle);
            }

            Session.InvalidateHandles();
        }

        //
        // Сводка:
        //     Calling viClear() method
        internal void Clear()
        {
            _ThrowOnError(_visaC.Clear(Session.Handle), "Calling viClear -");
        }

        //
        // Сводка:
        //     Write text to instrument
        //
        // Параметры:
        //   text:
        //     text to write
        internal void Write(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            uint written;
            int num = _visaC.Write(Session.Handle, bytes, (uint)bytes.Length, out written);
            if (num < 0)
            {
                _ThrowOnError(num, "VISA Write -");
            }
        }

        //
        // Сводка:
        //     Write binary buffer to instrument
        //
        // Параметры:
        //   buffer:
        //     binary buffer to write
        internal void Write(byte[] buffer)
        {
            uint written;
            int num = _visaC.Write(Session.Handle, buffer, (uint)buffer.Length, out written);
            if (num < 0)
            {
                _ThrowOnError(num, "Write Binary Data -");
            }
        }

        //
        // Сводка:
        //     Reads data from instrument with defined maximum length. The maxLength value cannot
        //     exceed the _buffer.Length
        //
        // Параметры:
        //   maxLength:
        //     Maximum data length to read
        //
        //   moreDataAvailable:
        //     Returns true, if more data for reading is available
        //
        //   assureResponseEndWithTc:
        //     If true, each VISA read must end with TermChar. If not, the reading continues
        //
        //   readCount:
        //     Number of bytes actually read
        //
        // Возврат:
        //     Data as Byte array
        internal byte[] Read(int maxLength, out bool moreDataAvailable, bool assureResponseEndWithTc, out int readCount)
        {
            lock (_readLocker)
            {
                if (maxLength > _buffer.Length)
                {
                    throw new VisaException(Session.ResourceName, $"Attempting to read data from instrument with maximum count bigger than internal buffer size: {maxLength} > {_buffer.Length}");
                }

                int num = _visaC.Read(Session.Handle, _buffer, (uint)maxLength, out var read);
                if (num < 0)
                {
                    _ThrowOnError(num, "VISA Read -");
                }

                moreDataAvailable = _MoreDataIsAvailable(num);
                if (assureResponseEndWithTc && read < maxLength && read != 0)
                {
                    byte b = Convert.ToByte(ReadTermChar);
                    if (_buffer[read - 1] != b)
                    {
                        byte[] array = new byte[maxLength - read];
                        num = _visaC.Read(Session.Handle, array, (uint)maxLength - read, out var read2);
                        num = _ThrowOnError(num, "VISA Read2 -");
                        Buffer.BlockCopy(array, 0, _buffer, (int)read, (int)read2);
                        moreDataAvailable = _MoreDataIsAvailable(num);
                        if (!moreDataAvailable && read == maxLength && _buffer[read - 1] != b)
                        {
                            moreDataAvailable = true;
                        }

                        read += read2;
                    }
                }

                readCount = (int)read;
                return _buffer;
            }
        }

        //
        // Сводка:
        //     Reads data as string from instrument with defined maximum length. The maxLength
        //     value cannot exceed the _buffer.Length
        //
        // Параметры:
        //   maxLength:
        //     Maximum string length to read
        //
        //   moreDataAvailable:
        //     Returns true, if more data for reading is available
        //
        //   assureResponseEndWithTc:
        //     If true, each VISA read must end with TermChar. If not, the reading continues
        //
        //   readCount:
        //     Number of characters actually read
        //
        // Возврат:
        //     Read data as string
        internal string ReadString(int maxLength, out bool moreDataAvailable, bool assureResponseEndWithTc, out int readCount)
        {
            byte[] bytes = Read(maxLength, out moreDataAvailable, assureResponseEndWithTc, out readCount);
            return Encoding.ASCII.GetString(bytes, 0, readCount);
        }

        //
        // Сводка:
        //     Reads single character
        //
        // Возврат:
        //     read character
        internal char ReadChar()
        {
            byte[] array = new byte[1];
            _ThrowOnError(_visaC.Read(Session.Handle, array, 1u, out var _), "VISA Read Byte -");
            return Convert.ToChar(array[0]);
        }

        //
        // Сводка:
        //     Reads up to a specified ASCII character, and returns the string before
        //
        // Параметры:
        //   c:
        //     character to stop the reading
        //
        //   maxCount:
        //     Maximum characters to read. The reading stops if it reached the desired character,
        //     maxCount, or end of message
        //
        // Возврат:
        //     String before the c
        internal string ReadUpToChar(char c, int maxCount)
        {
            int num = 0;
            string text = "";
            char c2 = '\n';
            while (num < maxCount)
            {
                c2 = ReadChar();
                if (c2 == c)
                {
                    break;
                }

                num++;
                text += c2;
            }

            if (c2 != c)
            {
                throw new VisaException(Session.ResourceName, $"Expecting to receive a character '{c}' within {maxCount} bytes, received '{text}'");
            }

            return text;
        }

        //
        // Сводка:
        //     Reads Status Byte using viReadSTB()
        //
        // Возврат:
        //     STatus Byte value
        internal uint ReadStb()
        {
            uint status;
            int num = _visaC.ReadStb(Session.Handle, out status);
            if (num < 0)
            {
                _ThrowOnError(num, "viReadSTB() -");
            }

            return status;
        }

        //
        // Сводка:
        //     Enables Service Request Event
        protected void EnableSrqEvent(VisaConstants.EventMechanism mechanism)
        {
            int num = _visaC.EnableEvent(Session.Handle, 1073684491u, (short)mechanism, 0);
            if (num < 0)
            {
                _ThrowOnError(num, "Enable SRQ event -");
            }
        }

        //
        // Сводка:
        //     Disables Service Request Event
        protected void DisableSrqEvent(VisaConstants.EventMechanism mechanism)
        {
            int num = _visaC.DisableEvent(Session.Handle, 1073684491u, (short)mechanism);
            if (num < 0)
            {
                _ThrowOnError(num, "Disable SRQ event -");
            }
        }

        //
        // Сводка:
        //     Flushes all the existing events
        protected void DiscardAllEnabledEvents(VisaConstants.EventMechanism mechanism)
        {
            int num = _visaC.DiscardEvents(Session.Handle, 1073709055u, (short)mechanism);
            if (num < 0)
            {
                _ThrowOnError(num, "Discard all events -");
            }
        }

        //
        // Сводка:
        //     Flushes all the existing SRQ events
        protected void DiscardAllSrqEvents(VisaConstants.EventMechanism mechanism)
        {
            int num = _visaC.DiscardEvents(Session.Handle, 1073684491u, (short)mechanism);
            if (num < 0)
            {
                _ThrowOnError(num, "Discard all SRQ events -");
            }
        }

        //
        // Сводка:
        //     Installs SRQ handler
        private void _InstallSrqHandler(VisaC.EventHandler handler)
        {
            int num = _visaC.InstallHandler(Session.Handle, 1073684491u, handler, 0);
            if (num < 0)
            {
                _ThrowOnError(num, "Adding srq event handler for service request (ViInstallHandler) -");
            }
        }

        //
        // Сводка:
        //     Uninstalls SRQ handler
        private void _UninstallSrqHandler(VisaC.EventHandler handler)
        {
            int num = _visaC.UninstallHandler(Session.Handle, 1073684491u, handler, 0);
            if (num < 0)
            {
                _ThrowOnError(num, "Removing event handler for service request (ViUninstallHandler) -");
            }
        }

        //
        // Сводка:
        //     Waits on Service Request Event. If a timeout occurs, the method returns true
        //
        // Параметры:
        //   timeoutMs:
        //     timeout for waiting on the SRQ event
        //
        //   disableAfterwards:
        //     If true, the DisableSrqEvent() is called afterwards
        //
        // Возврат:
        //     True, if timeout occurred
        internal bool WaitOnSrqEvent(int timeoutMs, bool disableAfterwards)
        {
            int outEventType;
            int num = _visaC.WaitOnEvent(Session.Handle, 1073684491u, timeoutMs, out outEventType, IntPtr.Zero);
            if (disableAfterwards)
            {
                DisableSrqEvent(VisaConstants.EventMechanism.Queue);
            }

            if (num == -1073807339)
            {
                return true;
            }

            if (num < 0)
            {
                _ThrowOnError(num, "Waiting on SRQ Event -");
            }

            return false;
        }

        //
        // Сводка:
        //     internal method to install a new srq handler. Visa-C SRQ handler is always only
        //     one method (SrqHandler), which serves as a router for other C#-like event 'handler'
        internal void InstallSrqVisaChandler(EventHandler<InstrEventArgs> handler)
        {
            if (_installedVisaCsrqHandler != null)
            {
                _UninstallSrqHandler(_installedVisaCsrqHandler);
            }

            _installedVisaCsrqHandler = SrqHandler;
            _InstallSrqHandler(_installedVisaCsrqHandler);
            int SrqHandler(int vi, uint inEventType, int inContext, int inUserHandle)
            {
                InstrEventArgs e = new InstrEventArgs(Session.ResourceName)
                {
                    StatusByte = (StatusByte)ReadStb()
                };
                handler?.Invoke(this, e);
                return 0;
            }
        }

        //
        // Сводка:
        //     internal method to uninstall VISA-C srq handler.
        internal void UninstallSrqVisaChandler()
        {
            if (_installedVisaCsrqHandler != null)
            {
                _UninstallSrqHandler(_installedVisaCsrqHandler);
            }

            _installedVisaCsrqHandler = null;
            DisableSrqEvent(VisaConstants.EventMechanism.Handler);
        }
    }
}
