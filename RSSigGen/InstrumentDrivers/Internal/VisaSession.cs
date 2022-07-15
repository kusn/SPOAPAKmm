using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class VisaSession : Visa
    {
        //
        // Сводка:
        //     Session type constructed from the VISA interfaceType and ResourceClass parameters
        internal enum SessionKind
        {
            Unsupported = 0,
            Gpib = 1,
            Serial = 2,
            Vxi11 = 3,
            Hislip = 4,
            Socket = 5,
            Usb = 6,
            Nrpz = 33024
        }

        internal enum ReadDataType
        {
            Unknown,
            AsciiData,
            NullData,
            BinDataKnownLen,
            BinDataUnknownLen
        }

        //
        // Сводка:
        //     Event Status Register flags. Only the ones actually used (OPC flag) are defined
        //     here.
        [Flags]
        private enum EventStatusRegister
        {
            OperationComplete = 0x1
        }

        private bool _fastSweep;

        private WaitForOpcMode _opcWaitMode;

        private readonly bool _addTermCharToWriteBinData;

        private readonly bool _assureWriteWithTc;

        private readonly char _termChar;

        private StatusByte? _currentSreMask;

        private StatusByte _baseSreMask;

        private EventStatusRegister? _currentEseMask;

        private EventStatusRegister _baseEseMask;

        private int _opcTimeout;

        //
        // Сводка:
        //     External Service Request handlers dictionary. Only one handler can be installed
        //     per Stb mask
        private readonly Dictionary<StatusByte, EventHandler<InstrEventArgs>> _userSrqHandlers;

        //
        // Сводка:
        //     First read length - for NRP-Z session it is the full ReadBufferSize of 1E6 Bytes
        private int FirsReadLen
        {
            get
            {
                if (SessionType != SessionKind.Nrpz)
                {
                    return Math.Min(IoSegmentSize, 1024);
                }

                return base.ReadBufferSize;
            }
        }

        //
        // Сводка:
        //     Next read length - for NRP-Z session it is equal to 1E6 Bytes
        private int NextReadChunkLen
        {
            get
            {
                if (SessionType != SessionKind.Nrpz)
                {
                    return Math.Min(IoSegmentSize, 65536);
                }

                return FirsReadLen;
            }
        }

        internal bool VxiCapable { get; }

        internal int ReadStbVisaTimeout { get; set; }

        internal int WriteDelay { get; set; }

        internal int ReadDelay { get; set; }

        internal int IoSegmentSize { get; set; }

        internal SessionSettings Settings { get; }

        //
        // Сводка:
        //     Event handler for segmented transfer
        internal EventHandler<InstrSegmentEventArgs> ReadSegmentHandler { get; set; }

        internal EventHandler<InstrSegmentEventArgs> WriteSegmentHandler { get; set; }

        //
        // Сводка:
        //     Timeout for all the OPC-sync operations
        internal int OpcTimeout
        {
            get
            {
                return _opcTimeout;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("OpcTimeout");
                }

                _opcTimeout = value;
            }
        }

        //
        // Сводка:
        //     If true, start of a OPC-synced operation uses viReadStb instead if *STB?
        internal bool FastSweep
        {
            get
            {
                return _fastSweep;
            }
            set
            {
                _fastSweep = VxiCapable && value;
            }
        }

        //
        // Сводка:
        //     Type of the VISA session
        internal SessionKind SessionType { get; }

        //
        // Сводка:
        //     External events handler for all the VISA events
        internal EventHandler<InstrEventArgs> EventsHandler { get; set; }

        //
        // Сводка:
        //     If set to true (default value), each VISA read must end with TermChar. If not,
        //     the reading continues
        internal bool AssureResponseEndWithTc { get; }

        //
        // Сводка:
        //     Returns true, if at least one SRQ error handler is installed
        internal bool HasErrHandlerInstalled
        {
            get
            {
                if (_currentSreMask.HasValue)
                {
                    return _currentSreMask.Value.HasFlag(StatusByte.ErrorQueueNotEmpty);
                }

                return false;
            }
        }

        //
        // Сводка:
        //     Constructor for the VisaSession
        //
        // Параметры:
        //   resourceName:
        //
        //   directSession:
        //     If you provide a non-null number, the session is reused.
        //
        //   xmlSettings:
        //     XML-style settings to be used for the session
        //
        //   visaPlugin:
        //     If non-null, you can use a custom VISA API implementation
        //
        //   simulating:
        //     If true, the Visa object is in simulation mode.
        internal VisaSession(string resourceName, byte[] directSession, XElement xmlSettings, string visaPlugin, bool simulating)
            : base(resourceName, directSession, visaPlugin, simulating)
        {
            _userSrqHandlers = new Dictionary<StatusByte, EventHandler<InstrEventArgs>>();
            SessionType = _GetSessionKind();
            Settings = new SessionSettings(xmlSettings, resourceName, SessionType.ToString(), null);
            VxiCapable = Settings.VxiCapable;
            _termChar = Settings.TermChar;
            switch (SessionType)
            {
                case SessionKind.Serial:
                    base.ReadTermChar = _termChar;
                    base.ReadTermCharEnabled = true;
                    base.SerialSendEndIn = 0;
                    base.SerialSendEndOut = 0;
                    VxiCapable = false;
                    break;
                case SessionKind.Socket:
                    base.ReadTermChar = _termChar;
                    base.ReadTermCharEnabled = true;
                    VxiCapable = false;
                    break;
                case SessionKind.Nrpz:
                    base.ReadTermChar = _termChar;
                    base.ReadTermCharEnabled = true;
                    VxiCapable = false;
                    break;
            }

            WriteDelay = Settings.WriteDelay;
            ReadDelay = Settings.ReadDelay;
            IoSegmentSize = Settings.IoSegmentSize;
            AssureResponseEndWithTc = Settings.AssureResponseEndWithTc;
            _assureWriteWithTc = Settings.AssureWriteWithTc;
            _addTermCharToWriteBinData = Settings.AddTermCharToWriteBinData;
            _opcWaitMode = Settings.OpcWaitMode;
            if (!VxiCapable)
            {
                _assureWriteWithTc = true;
                _addTermCharToWriteBinData = true;
                if (_opcWaitMode == WaitForOpcMode.ServiceRequest)
                {
                    _opcWaitMode = WaitForOpcMode.OpcQuery;
                }
            }

            base.Timeout = Settings.VisaTimeout;
            OpcTimeout = Settings.OpcTimeout;
            ReadStbVisaTimeout = Settings.ReadStbVisaTimeout;
            if (base.Session.Simulate)
            {
                return;
            }

            Clear();
            if (SessionType == SessionKind.Nrpz)
            {
                return;
            }

            Write("*CLS");
            if (VxiCapable)
            {
                StatusByte statusByte = _ReadStb(blockTmoSettings: false);
                if (statusByte.HasFlag(StatusByte.MessageAvailable))
                {
                    _FlushJunkData(totalFlush: true);
                }
            }

            _opcWaitMode = _SetRegistersEseSre(_opcWaitMode);
        }

        //
        // Сводка:
        //     String representation of the object: "Instrument {vendor}, {Session Kind}, '{resource
        //     name}'"
        public override string ToString()
        {
            return "Visa Session " + base.Session.ResourceName;
        }

        //
        // Сводка:
        //     Returns session type
        private SessionKind _GetSessionKind()
        {
            switch (base.InterfaceType)
            {
                case 1:
                case 3:
                    return SessionKind.Gpib;
                case 4:
                    return SessionKind.Serial;
                case 6:
                    if (base.ResourceClass == "SOCKET")
                    {
                        return SessionKind.Socket;
                    }

                    if (!base.IsHislip)
                    {
                        return SessionKind.Vxi11;
                    }

                    return SessionKind.Hislip;
                case 7:
                    return SessionKind.Usb;
                case 33024:
                    return SessionKind.Nrpz;
                default:
                    return SessionKind.Unsupported;
            }
        }

        //
        // Сводка:
        //     Returns integer value of OpcTimeoutMs property, if the input nullable value is
        //     null, 0, or less than 0. Otherwise returns the input value.
        private int _ResolveOpcTimeout(int? timeoutMs)
        {
            if (!timeoutMs.HasValue || timeoutMs < 1)
            {
                return OpcTimeout;
            }

            return timeoutMs.Value;
        }

        //
        // Сводка:
        //     Delay Writing by defined number of milliseconds
        private void _DelayBeforeWrite()
        {
            if (WriteDelay > 0)
            {
                Thread.Sleep(WriteDelay);
            }
        }

        //
        // Сводка:
        //     Delay Reading by defined number of milliseconds
        private void _DelayBeforeRead()
        {
            if (ReadDelay > 0)
            {
                Thread.Sleep(ReadDelay);
            }
        }

        //
        // Сводка:
        //     Sets the ESE and SRE registers based on the entered WaitForOpcMode Returns coerced
        //     WaitForOpcMode
        private WaitForOpcMode _SetRegistersEseSre(WaitForOpcMode mode)
        {
            if (!VxiCapable && mode == WaitForOpcMode.ServiceRequest)
            {
                mode = WaitForOpcMode.StbPolling;
            }

            if (mode == WaitForOpcMode.ServiceRequest)
            {
                _baseSreMask = StatusByte.EventStatusByte;
                _baseEseMask = EventStatusRegister.OperationComplete;
            }
            else
            {
                _baseSreMask = StatusByte.None;
                _baseEseMask = EventStatusRegister.OperationComplete;
            }

            _SetSreMask(_baseSreMask);
            _SetEseMask(_baseEseMask);
            return mode;
        }

        //
        // Сводка:
        //     Reads junk bytes to clear the instrument's output buffer. If totalFlush is true,
        //     the method tries to completely flush the data. If false, after several reads
        //     it throws exception
        //
        // Параметры:
        //   totalFlush:
        private void _FlushJunkData(bool totalFlush)
        {
            bool moreDataAvailable = true;
            _DelayBeforeRead();
            int num = 10;
            int readCount;
            if (totalFlush)
            {
                while (moreDataAvailable)
                {
                    Read(num, out moreDataAvailable, assureResponseEndWithTc: false, out readCount);
                    num = Math.Min(base.ReadBufferSize, num * 10);
                }
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    Read(num, out moreDataAvailable, assureResponseEndWithTc: false, out readCount);
                    num = Math.Min(base.ReadBufferSize, num * 10);
                    if (!moreDataAvailable)
                    {
                        break;
                    }
                }
            }

            if (moreDataAvailable)
            {
                throw new RsSmabException(base.Session.ResourceName, "Reading junk data - data length is too big to be completely read from the instrument.");
            }
        }

        //
        // Сводка:
        //     Parses the binary data and returns the expected length of the following data
        private long _ParseBinaryDataHeader(bool exceptionIfNotBinData, out string wholeHeader, out ReadDataType dataType)
        {
            long result = -1L;
            _DelayBeforeRead();
            char c = ReadChar();
            int readCount;
            if (c == '#')
            {
                c = ReadChar();
                switch (c)
                {
                    case '0':
                        wholeHeader = "#0";
                        dataType = ReadDataType.BinDataUnknownLen;
                        return result;
                    case '(':
                        {
                            string text2 = "";
                            dataType = ReadDataType.BinDataKnownLen;
                            for (int i = 0; i < 100; i++)
                            {
                                c = ReadChar();
                                if (c == ')')
                                {
                                    break;
                                }

                                text2 += c;
                            }

                            wholeHeader = "#(" + text2 + ")";
                            return text2.ToInt64();
                        }
                    default:
                        {
                            dataType = ReadDataType.BinDataKnownLen;
                            string text = c.ToString();
                            wholeHeader = ReadString(int.Parse(text, RsDrvFormat.Number), out var _, assureResponseEndWithTc: false, out readCount);
                            result = wholeHeader.ToInt64();
                            wholeHeader = "#" + text + wholeHeader;
                            return result;
                        }
                }
            }

            dataType = ReadDataType.AsciiData;
            if (c == _termChar)
            {
                dataType = ReadDataType.NullData;
                if (VxiCapable)
                {
                    StatusByte statusByte = _ReadStb(blockTmoSettings: false);
                    if (statusByte.HasFlag(StatusByte.MessageAvailable))
                    {
                        dataType = ReadDataType.AsciiData;
                    }
                }
            }

            wholeHeader = c.ToString();
            if (exceptionIfNotBinData)
            {
                if (dataType == ReadDataType.NullData)
                {
                    throw new RsSmabException(base.Session.ResourceName, "Expecting binary data, received empty ASCII string.");
                }

                wholeHeader += ReadString(20, out var moreDataAvailable2, assureResponseEndWithTc: false, out readCount);
                if (moreDataAvailable2)
                {
                    _FlushJunkData(totalFlush: true);
                }

                throw new RsSmabException(base.Session.ResourceName, "Expecting binary data, received ASCII response: " + wholeHeader.TrimEnd());
            }

            return result;
        }

        //
        // Сводка:
        //     Segmented reading of unknown-length data into a Stream. For Socket and Serial
        //     interfaces this method only works if the ReadTermCharacterEnabled is True Enter
        //     the startTime if you already have read some data into the stream, otherwise the
        //     method creates its own start time
        private void _ReadDataUnknownLengthToStream(Stream stream, int segmentSize, bool binTransfer, DateTime? startTime = null)
        {
            if (!startTime.HasValue)
            {
                startTime = DateTime.Now;
            }

            int num = 0;
            long num2 = stream.Position;
            if (num2 > 0)
            {
                num++;
            }

            if (!VxiCapable && binTransfer && base.ReadTermCharEnabled)
            {
                throw new RsSmabException(base.Session.ResourceName, $"{SessionType} interface does not support reading binary data of unknown length.");
            }

            bool flag;
            do
            {
                long position = stream.Position;
                bool moreDataAvailable;
                int num3 = ReadToStream(stream, segmentSize, assureResponseEndWithTc: false, out moreDataAvailable);
                flag = !moreDataAvailable || num3 < segmentSize;
                num++;
                num2 += num3;
                _InvokeReadSegmentEvent(startTime.Value, num, num3, position, flag, -1L, num2, stream);
            }
            while (!flag);
        }

        //
        // Сводка:
        //     Segmented reading of known-length data into a Stream. Maximum size of the data
        //     is Int32.MaxValue
        private void _ReadDataKnownLengthToStream(Stream stream, long length, int segmentSize)
        {
            DateTime now = DateTime.Now;
            if (stream.GetType() == typeof(MemoryStream))
            {
                long num = length + ((MemoryStream)stream).Length;
                if (num > int.MaxValue)
                {
                    throw new RsSmabException(base.Session.ResourceName, $"MemoryStream maximum capacity ({int.MaxValue}) is not enough to hold the expected data of {length} length. Use the FileStream instead.");
                }

                ((MemoryStream)stream).Capacity = (int)num;
            }

            if (length == 0L)
            {
                if (VxiCapable)
                {
                    if ((_ReadStb(blockTmoSettings: false) & StatusByte.MessageAvailable) > StatusByte.None)
                    {
                        _FlushJunkData(totalFlush: false);
                    }
                }
                else
                {
                    base.ReadTermCharEnabled = true;
                    _FlushJunkData(totalFlush: false);
                }

                return;
            }

            if (length < segmentSize)
            {
                long position = stream.Position;
                ReadToStream(stream, (int)length, assureResponseEndWithTc: false, out var moreDataAvailable);
                _InvokeReadSegmentEvent(now, 1, (int)length, position, finished: true, length, length, stream);
                if (moreDataAvailable)
                {
                    if (!VxiCapable)
                    {
                        base.ReadTermCharEnabled = true;
                    }

                    _FlushJunkData(totalFlush: false);
                }

                return;
            }

            long num2 = length;
            int num3 = 1;
            long num4 = 0L;
            int num5;
            while (num2 > segmentSize)
            {
                long position2 = stream.Position;
                num5 = ReadToStream(stream, segmentSize, assureResponseEndWithTc: false, out var _);
                num4 += num5;
                num2 -= num5;
                _InvokeReadSegmentEvent(now, num3, num5, position2, finished: false, length, num4, stream);
                if (num5 < segmentSize)
                {
                    throw new RsSmabException(base.Session.ResourceName, "Reading Binary Data segment - fewer data than expected was read.");
                }

                num3++;
            }

            long position3 = stream.Position;
            num5 = ReadToStream(stream, (int)num2, assureResponseEndWithTc: false, out var moreDataAvailable3);
            num4 += num5;
            num2 -= num5;
            _InvokeReadSegmentEvent(now, num3, num5, position3, finished: true, length, num4, stream);
            if (num2 != 0L)
            {
                throw new RsSmabException(base.Session.ResourceName, "Reading Binary Data last segment - fewer data than expected was read.");
            }

            if (moreDataAvailable3)
            {
                if (!VxiCapable)
                {
                    base.ReadTermCharEnabled = true;
                }

                _FlushJunkData(totalFlush: false);
            }
        }

        //
        // Сводка:
        //     If any ReadSegmentHandler is registered, this method calls that handler
        private void _InvokeReadSegmentEvent(DateTime startTime, int segmentIx, int segmentSize, long segmentOffset, bool finished, long totalSize, long transferredSize, Stream stream)
        {
            if (ReadSegmentHandler != null && ReadSegmentHandler.GetInvocationList().Length != 0)
            {
                InstrSegmentEventArgs e = new InstrSegmentEventArgs(base.Session.ResourceName, startTime)
                {
                    SegmentSize = segmentSize,
                    SegmentDataOffset = segmentOffset,
                    DataStream = stream,
                    TotalSize = totalSize,
                    TransferredSize = transferredSize,
                    SegmentIx = segmentIx,
                    Finished = finished
                };
                ReadSegmentHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     If any SegmentTransferHandler is registered, this method calls that handler
        private void _InvokeWriteSegmentEvent(DateTime startTime, int segmentIx, int segmentSize, bool finished, long totalSize, long transferredSize)
        {
            if (WriteSegmentHandler != null && WriteSegmentHandler.GetInvocationList().Length != 0)
            {
                InstrSegmentEventArgs e = new InstrSegmentEventArgs(base.Session.ResourceName, startTime)
                {
                    SegmentSize = segmentSize,
                    DataStream = null,
                    SegmentDataOffset = -1L,
                    TotalSize = totalSize,
                    TransferredSize = transferredSize,
                    SegmentIx = segmentIx,
                    Finished = finished
                };
                WriteSegmentHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Read string from instrument with maximum defined length. The maxLength value
        //     cannot exceed the VISA's _buffer.Length (100kB)
        private string _ReadString(int maxLength, out bool moreDataAvailable)
        {
            if (ReadDelay > 0)
            {
                _DelayBeforeRead();
            }

            int readCount;
            return ReadString(maxLength, out moreDataAvailable, AssureResponseEndWithTc, out readCount);
        }

        //
        // Сводка:
        //     Reads string from instrument with unlimited length trimmed for trailing TermChars
        //     The read is performed in two steps to optimize memory use: The First read is
        //     performed with the fixed size of 1024 bytes. The Second read is then performed
        //     with 64kB segments, until all the data are read out.
        private string _ReadStringUnknownLength()
        {
            DateTime now = DateTime.Now;
            if (ReadDelay > 0)
            {
                _DelayBeforeRead();
            }

            bool moreDataAvailable;
            int readCount;
            byte[] array = Read(FirsReadLen, out moreDataAvailable, AssureResponseEndWithTc, out readCount);
            string @string;
            if (!moreDataAvailable)
            {
                @string = Encoding.ASCII.GetString(array, 0, readCount);
                return @string.TrimEnd(_termChar);
            }

            using (MemoryStream memoryStream = new MemoryStream(readCount))
            {
                memoryStream.Write(array, 0, readCount);
                _InvokeReadSegmentEvent(now, 1, readCount, 0L, finished: false, -1L, readCount, memoryStream);
                _ReadDataUnknownLengthToStream(memoryStream, NextReadChunkLen, binTransfer: false, now);
                @string = Encoding.ASCII.GetString(memoryStream.ToArray());
            }

            return @string.TrimEnd(_termChar);
        }

        //
        // Сводка:
        //     Sends *STB? query and reads the result
        private StatusByte _QueryStb()
        {
            return (StatusByte)QueryShort("*STB?").ToInt32(0);
        }

        //
        // Сводка:
        //     Reads viReadSTB and casts it to the StatusByte type
        private StatusByte _ReadStb(bool blockTmoSettings)
        {
            if (blockTmoSettings || ReadStbVisaTimeout <= 0)
            {
                return (StatusByte)ReadStb();
            }

            int timeout = 0;
            if (ReadStbVisaTimeout > 0)
            {
                timeout = base.Timeout;
                base.Timeout = ReadStbVisaTimeout;
            }

            try
            {
                return (StatusByte)ReadStb();
            }
            finally
            {
                base.Timeout = timeout;
            }
        }

        //
        // Сводка:
        //     Reads Status Byte Register and ends if the ESB bit (5) is set to 1. This method
        //     also works with the SOCKET and SERIAL interface by sending *STB? query. In that
        //     case however, command cannot be a query.
        private StatusByte _WriteAndPollStbVxi(string command, bool isQuery, int timeoutMs, StatusByte maskToEnd)
        {
            int timeout = 0;
            ClearBeforeRead();
            Write(command + ";*OPC");
            if (ReadStbVisaTimeout > 0)
            {
                timeout = base.Timeout;
                base.Timeout = ReadStbVisaTimeout;
            }

            try
            {
                DateTime now = DateTime.Now;
                DateTime dateTime = now.AddMilliseconds(timeoutMs);
                StatusByte statusByte;
                do
                {
                    statusByte = _ReadStb(blockTmoSettings: true);
                    _PollingDelay(now);
                    if (DateTime.Now > dateTime)
                    {
                        _NarrowDownOpcToutError(command, isQuery, timeoutMs);
                    }
                }
                while ((statusByte & maskToEnd) == 0);
                return statusByte;
            }
            finally
            {
                if (ReadStbVisaTimeout > 0)
                {
                    base.Timeout = timeout;
                }
            }
        }

        //
        // Сводка:
        //     Queries Status Byte Register (*STB?) and ends if the ESB bit (5) is set to 1.
        //     The command must not be a query. This method also works with the SOCKET and SERIAL
        //     interface.
        private StatusByte _WriteAndPollStbNonVxi(string command, int timeoutMs, StatusByte maskToEnd)
        {
            ClearBeforeRead();
            Write(command + ";*OPC");
            DateTime now = DateTime.Now;
            DateTime dateTime = now.AddMilliseconds(timeoutMs);
            StatusByte statusByte;
            do
            {
                statusByte = _QueryStb();
                _PollingDelay(now);
                if (DateTime.Now > dateTime)
                {
                    InstrumentErrors.ThrowOpcToutException(base.Session.ResourceName, OpcTimeout, timeoutMs);
                }
            }
            while ((statusByte & maskToEnd) == 0);
            return statusByte;
        }

        //
        // Сводка:
        //     Generates progressive polling delay
        private void _PollingDelay(DateTime start)
        {
            TimeSpan timeSpan = DateTime.Now - start;
            switch (_opcWaitMode)
            {
                case WaitForOpcMode.StbPolling:
                    if (!(timeSpan.TotalMilliseconds < 10.0))
                    {
                        if (timeSpan.TotalMilliseconds < 100.0)
                        {
                            Thread.Sleep(5);
                        }
                        else if (timeSpan.TotalMilliseconds < 1000.0)
                        {
                            Thread.Sleep(20);
                        }
                        else if (timeSpan.TotalMilliseconds < 5000.0)
                        {
                            Thread.Sleep(50);
                        }
                        else if (timeSpan.TotalMilliseconds < 10000.0)
                        {
                            Thread.Sleep(100);
                        }
                        else if (timeSpan.TotalMilliseconds < 50000.0)
                        {
                            Thread.Sleep(500);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }

                    break;
                case WaitForOpcMode.StbPollingSlow:
                    if (timeSpan.TotalMilliseconds < 10.0)
                    {
                        Thread.Sleep(1);
                    }
                    else if (timeSpan.TotalMilliseconds < 1000.0)
                    {
                        Thread.Sleep(20);
                    }
                    else if (timeSpan.TotalMilliseconds < 5000.0)
                    {
                        Thread.Sleep(100);
                    }
                    else if (timeSpan.TotalMilliseconds < 10000.0)
                    {
                        Thread.Sleep(200);
                    }
                    else if (timeSpan.TotalMilliseconds < 20000.0)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }

                    break;
                case WaitForOpcMode.StbPollingSuperSlow:
                    if (timeSpan.TotalMilliseconds < 1000.0)
                    {
                        Thread.Sleep(100);
                    }
                    else if (timeSpan.TotalMilliseconds < 10000.0)
                    {
                        Thread.Sleep(500);
                    }
                    else if (timeSpan.TotalMilliseconds < 20000.0)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }

                    break;
            }
        }

        //
        // Сводка:
        //     Used internally after _StbPolling() to check if the message is available Throws
        //     an exception in case of MAV not available
        //
        // Параметры:
        //   stb:
        //     Last read STB
        //
        //   query:
        //     Sent query - only for error message purposes
        //
        //   timeoutMs:
        //     Timeout used - only for error message purposes
        //
        //   errorMessageContext:
        //     Context to add at the beginning of exception message
        private void _CheckMessageAvailableAfterOpc(StatusByte stb, string query, int timeoutMs, string errorMessageContext)
        {
            if (!VxiCapable || (stb & StatusByte.MessageAvailable) != 0)
            {
                return;
            }

            errorMessageContext = errorMessageContext + " SCPI query '" + query.Trim() + "'";
            errorMessageContext = errorMessageContext.Trim();
            if ((stb & StatusByte.ErrorQueueNotEmpty) > StatusByte.None)
            {
                InstrumentErrors.AssertNoInstrumentStatusErrors(base.Session.ResourceName, QuerySystemErrorAll(), errorMessageContext);
                return;
            }

            stb = _ReadStb(blockTmoSettings: false);
            if (!stb.HasFlag(StatusByte.EventStatusByte))
            {
                InstrumentErrors.ThrowOpcToutException(base.Session.ResourceName, OpcTimeout, timeoutMs, (errorMessageContext + " No response from the instrument.").Trim());
            }
        }

        //
        // Сводка:
        //     This method when called after VisaTimeoutException() can narrow down the error
        //     to more specific exception e.g. InstrumentStatusException()
        private void _NarrowDownVisaTimeoutError(string context)
        {
            StatusByte statusByte;
            if (VxiCapable)
            {
                statusByte = _ReadStb(blockTmoSettings: false);
            }
            else
            {
                int timeout = base.Timeout;
                try
                {
                    base.Timeout = 500;
                    Write("*STB?");
                    statusByte = (StatusByte)Convert.ToInt32(_ReadString(64, out var _), RsDrvFormat.Number);
                }
                finally
                {
                    base.Timeout = timeout;
                }
            }

            context = $"{context}VISA Timeout error occurred ({base.Timeout} milliseconds)";
            if (statusByte.HasFlag(StatusByte.ErrorQueueNotEmpty))
            {
                InstrumentErrors.AssertNoInstrumentStatusErrors(base.Session.ResourceName, QuerySystemErrorAll(), context + " and ...");
            }

            throw new VisaTimeoutException(base.Session.ResourceName, context, base.Timeout);
        }

        //
        // Сводка:
        //     This method when called after Ivi.Driver.MaxTimeExceededException can narrow
        //     down the error to more specific exception e.g. InstrumentStatusException()
        private void _NarrowDownOpcToutError(string command, bool isQuery, int? timeoutMs)
        {
            StatusByte statusByte = _ReadStb(blockTmoSettings: false);
            timeoutMs = _ResolveOpcTimeout(timeoutMs);
            if (isQuery)
            {
                if (statusByte.HasFlag(StatusByte.ErrorQueueNotEmpty))
                {
                    Clear();
                    string context = $"Sending query '{command.Trim()}' with OPC Wait resulted in timeout. OPC Timeout is set to {timeoutMs} ms. Additionally, ";
                    InstrumentErrors.AssertNoInstrumentStatusErrors(base.Session.ResourceName, QuerySystemErrorAll(), context);
                }

                InstrumentErrors.ThrowOpcToutException(base.Session.ResourceName, OpcTimeout, timeoutMs.Value, "Sending query '" + command.Trim() + "'.");
            }
            else
            {
                if (statusByte.HasFlag(StatusByte.ErrorQueueNotEmpty))
                {
                    string context2 = $"Sending command '{command.Trim()}' with OPC Wait resulted in timeout. OPC Timeout is set to {OpcTimeout} ms. Additionally, ";
                    InstrumentErrors.AssertNoInstrumentStatusErrors(base.Session.ResourceName, QuerySystemErrorAll(), context2);
                }

                InstrumentErrors.ThrowOpcToutException(base.Session.ResourceName, OpcTimeout, timeoutMs.Value, "Sending command '" + command.Trim() + "'");
            }
        }

        //
        // Сводка:
        //     Sending *ESE command with mask parameter
        //
        // Параметры:
        //   mask:
        //     Event Status Register mask
        private void _SetEseMask(EventStatusRegister mask)
        {
            if (!_currentEseMask.HasValue || _currentEseMask != mask)
            {
                Write($"*ESE {(int)mask}");
                _currentEseMask = mask;
            }
        }

        //
        // Сводка:
        //     Sending *SRE command with StatusByte mask parameter
        private void _SetSreMask(StatusByte mask)
        {
            if (!mask.HasFlag(StatusByte.EventStatusByte) && _opcWaitMode == WaitForOpcMode.ServiceRequest)
            {
                _opcWaitMode = WaitForOpcMode.StbPolling;
            }

            if (!_currentSreMask.HasValue || _currentSreMask != mask)
            {
                Write($"*SRE {(int)mask}");
                _currentSreMask = mask;
            }
        }

        //
        // Сводка:
        //     Internal method for OPC wait with ServiceRequest
        private StatusByte _WriteAndWaitForSrq(string command, bool isQuery, int timeoutMs)
        {
            ClearBeforeRead();
            EnableSrqEvent(VisaConstants.EventMechanism.Queue);
            DiscardAllSrqEvents(VisaConstants.EventMechanism.Queue);
            Write(command + ";*OPC");
            if (WaitOnSrqEvent(timeoutMs, disableAfterwards: true))
            {
                _NarrowDownOpcToutError(command, isQuery, timeoutMs);
            }

            return _ReadStb(blockTmoSettings: false);
        }

        //
        // Сводка:
        //     Internal method to synchronise a command with OPC. Returns last Status Byte value
        private StatusByte _WriteAndWaitForOpc(string command, bool isQuery, int? timeoutMs)
        {
            timeoutMs = _ResolveOpcTimeout(timeoutMs);
            command = command.TrimEnd(_termChar);
            if (isQuery)
            {
                InstrumentErrors.AssertQueryContainsQuestionMark(base.Session.ResourceName, command, "Query with OPC");
            }
            else
            {
                InstrumentErrors.AssertCommandContainsNoQuestionMark(base.Session.ResourceName, command, "Write with OPC");
            }

            if (_opcWaitMode == WaitForOpcMode.ServiceRequest)
            {
                return _WriteAndWaitForSrq(command, isQuery, timeoutMs.Value);
            }

            if (_opcWaitMode == WaitForOpcMode.OpcQuery)
            {
                if (isQuery)
                {
                    throw new RsSmabException(base.Session.ResourceName, "Sending a query with OpcQuery synchronization is not possible");
                }

                return _WriteAndQueryOpc(command, timeoutMs.Value);
            }

            if (VxiCapable)
            {
                return _WriteAndPollStbVxi(command, isQuery, timeoutMs.Value, StatusByte.ErrorQueueNotEmpty | StatusByte.EventStatusByte);
            }

            return _WriteAndPollStbNonVxi(command, timeoutMs.Value, StatusByte.ErrorQueueNotEmpty | StatusByte.EventStatusByte);
        }

        //
        // Сводка:
        //     Writes a command and queries an *OPC? afterwards. Can not be used for queries.
        private StatusByte _WriteAndQueryOpc(string command, int timeoutMs)
        {
            ClearBeforeRead();
            int timeout = base.Timeout;
            base.Timeout = timeoutMs;
            try
            {
                Write(command);
                QueryShort("*OPC?");
            }
            finally
            {
                base.Timeout = timeout;
            }

            return _QueryStb();
        }

        //
        // Сводка:
        //     Read binary data to byte array
        private byte[] _ReadBinaryData(bool exceptionIfNotBinData, out bool isBinData)
        {
            using MemoryStream memoryStream = new MemoryStream();
            isBinData = _ReadBinaryData(memoryStream, exceptionIfNotBinData);
            return memoryStream.ToArray();
        }

        //
        // Сводка:
        //     Read binary data and returns it in the entered Stream. Returns true, if the data
        //     was binary data block.
        private bool _ReadBinaryData(Stream stream, bool exceptionIfNotBinData)
        {
            string wholeHeader;
            ReadDataType dataType;
            long num = _ParseBinaryDataHeader(exceptionIfNotBinData, out wholeHeader, out dataType);
            switch (dataType)
            {
                case ReadDataType.AsciiData:
                    stream.Write(Encoding.ASCII.GetBytes(wholeHeader), 0, wholeHeader.Length);
                    _ReadDataUnknownLengthToStream(stream, IoSegmentSize, binTransfer: false);
                    return false;
                case ReadDataType.NullData:
                    return false;
                default:
                    try
                    {
                        if (!VxiCapable)
                        {
                            base.ReadTermCharEnabled = false;
                        }

                        if (dataType == ReadDataType.BinDataUnknownLen)
                        {
                            _ReadDataUnknownLengthToStream(stream, IoSegmentSize, binTransfer: true);
                        }
                        else if (num == 0L)
                        {
                            _FlushJunkData(totalFlush: false);
                        }
                        else
                        {
                            _ReadDataKnownLengthToStream(stream, num, IoSegmentSize);
                        }
                    }
                    finally
                    {
                        if (!VxiCapable)
                        {
                            base.ReadTermCharEnabled = true;
                        }
                    }

                    return true;
            }
        }

        //
        // Сводка:
        //     Perform VISA.viClear conditionally based on the instrument settings
        internal new void Clear()
        {
            if (Settings.PerformVisaClear)
            {
                try
                {
                    base.Clear();
                }
                catch (Exception ex) when (ex is VisaException || ex is VisaTimeoutException)
                {
                }
            }
        }

        //
        // Сводка:
        //     Writes byte buffer to the instrument
        internal new void Write(byte[] data)
        {
            if (WriteDelay > 0)
            {
                _DelayBeforeWrite();
            }

            base.Write(data);
        }

        //
        // Сводка:
        //     Writes string command to the instrument. If the session is non-VXI11, the command
        //     is appended by the TermChar if necessary
        internal new void Write(string command)
        {
            if (WriteDelay > 0)
            {
                _DelayBeforeWrite();
            }

            bool flag = false;
            if (_assureWriteWithTc)
            {
                flag = !command.EndsWithTc(_termChar);
            }

            if (flag)
            {
                base.Write(command + _termChar);
            }
            else
            {
                base.Write(command);
            }
        }

        //
        // Сводка:
        //     Internal method to synchronise a command with OPC
        internal void WriteWithOpc(string command, int? timeoutMs)
        {
            _WriteAndWaitForOpc(command, isQuery: false, timeoutMs);
        }

        //
        // Сводка:
        //     Adds user-defined Service request handler, called when any of the stbMask bits
        //     is set in the actual STB register. Optionally, it enables SRQ events Sets *SRE
        //     register mask to allow for the registered events to be invoked
        internal void InstallUserSrqHandler(EventHandler<InstrEventArgs> handler, StatusByte stbMask, bool enableEvent)
        {
            if (stbMask == StatusByte.None || stbMask.HasFlag(StatusByte.MessageAvailable) || stbMask.HasFlag(StatusByte.RequestService))
            {
                throw new ArgumentException($"stbMask value is invalid: {stbMask}");
            }

            _userSrqHandlers[stbMask] = handler ?? throw new ArgumentException("handler can not be null");
            StatusByte statusByte = StatusByte.None;
            foreach (StatusByte key in _userSrqHandlers.Keys)
            {
                statusByte |= key;
            }

            _SetSreMask(_baseSreMask | statusByte);
            if (statusByte != 0)
            {
                InstallSrqVisaChandler(LocalSrqHandler);
                if (enableEvent)
                {
                    EnableSrqEvent(VisaConstants.EventMechanism.Handler);
                }
            }

            void LocalSrqHandler(object sender, InstrEventArgs e)
            {
                EventHandler<InstrEventArgs> eventHandler = null;
                uint statusByte2 = (uint)e.StatusByte;
                foreach (StatusByte key2 in _userSrqHandlers.Keys)
                {
                    if (((uint)key2 & statusByte2) != 0)
                    {
                        eventHandler = (EventHandler<InstrEventArgs>)Delegate.Combine(eventHandler, _userSrqHandlers[key2]);
                    }
                }

                eventHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Removes user Service request handler if previously registered. Optionally, it
        //     disables SRQ events Sets new *SRE register mask based on the remaining handlers
        //     Returns the SRE register mask
        internal void UninstallUserSrqHandler(StatusByte stbMask, bool disable)
        {
            if (disable)
            {
                DisableSrqEvent(VisaConstants.EventMechanism.Handler);
            }

            if (_userSrqHandlers.ContainsKey(stbMask))
            {
                _userSrqHandlers.Remove(stbMask);
            }

            StatusByte statusByte = StatusByte.None;
            foreach (StatusByte key in _userSrqHandlers.Keys)
            {
                statusByte |= key;
            }

            _SetSreMask(_baseSreMask | statusByte);
            if (statusByte == StatusByte.None)
            {
                UninstallSrqVisaChandler();
            }
        }

        //
        // Сводка:
        //     Common handler for all the Write/Query with OPC event
        private void _AfterOpcEvent(InstrEventArgs e, object data)
        {
            UninstallUserSrqHandler(StatusByte.EventStatusByte, disable: true);
            if (EventsHandler != null)
            {
                e.Data = data;
                EventsHandler(this, e);
            }
        }

        //
        // Сводка:
        //     Writes with OPC, but does not wait for the opc from the instrument. Instead,
        //     it invokes the registered handler (property EventsHandler) when the OPC arrives.
        internal void WriteWithOpcEvent(string command)
        {
            command = command.TrimEnd(_termChar);
            InstrumentErrors.AssertCommandContainsNoQuestionMark(base.Session.ResourceName, command, "Write with OPC Event");
            if (!VxiCapable)
            {
                throw new InvalidOperationException("Write with OPC Event can only be used with VXI-capable sessions.");
            }

            ClearBeforeRead();
            InstallUserSrqHandler(LocalHandler, StatusByte.EventStatusByte, enableEvent: true);
            Write(command + ";*OPC");
            void LocalHandler(object sender, InstrEventArgs e)
            {
                _AfterOpcEvent(e, null);
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization, but does not wait for the response from the instrument.
        //     Instead, it invokes the registered handler (property EventsHandler) when the
        //     response arrives. You can read the response in the event argument ResponseString.
        internal void QueryStringWithOpcEvent(string query)
        {
            query = query.TrimEnd(_termChar);
            InstrumentErrors.AssertQueryContainsQuestionMark(base.Session.ResourceName, query, "Query String With OPC Event");
            if (!VxiCapable)
            {
                throw new InvalidOperationException("Query with OPC Event can only be used with VXI-capable sessions.");
            }

            ClearBeforeRead();
            InstallUserSrqHandler(LocalHandler, StatusByte.EventStatusByte, enableEvent: true);
            Write(query + ";*OPC");
            void LocalHandler(object sender, InstrEventArgs e)
            {
                e.BinData = false;
                _AfterOpcEvent(e, _ReadStringUnknownLength());
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization, but does not wait for the response from the instrument.
        //     Instead, it invokes the registered handler (property EventsHandler) when the
        //     response arrives. You can read the binary response in the event argument Data.
        internal void QueryBinDataWithOpcEvent(string query, bool exceptionIfNotBinData)
        {
            query = query.TrimEnd(_termChar);
            InstrumentErrors.AssertQueryContainsQuestionMark(base.Session.ResourceName, query, "Query Bin Data With OPC Event");
            if (!VxiCapable)
            {
                throw new InvalidOperationException("Query bin data with OPC Event can only be used with VXI-capable sessions.");
            }

            ClearBeforeRead();
            InstallUserSrqHandler(LocalHandler, StatusByte.EventStatusByte, enableEvent: true);
            Write(query + ";*OPC");
            void LocalHandler(object sender, InstrEventArgs e)
            {
                MemoryStream memoryStream = new MemoryStream();
                e.BinData = _ReadBinaryData(memoryStream, exceptionIfNotBinData);
                _AfterOpcEvent(e, memoryStream);
            }
        }

        //
        // Сводка:
        //     Writes command with *WAI synchronization.
        internal void WriteWithWai(string command)
        {
            if (command.EndsWithTc(_termChar))
            {
                Write(command.TrimEnd(_termChar) + ";*WAI");
            }
            else
            {
                Write(command + ";*WAI");
            }
        }

        //
        // Сводка:
        //     Sends "*ESR? query to reset the clear-on-read bits of the Event Status Register
        internal void QueryAndClearEsr()
        {
            QueryShort("*ESR?");
        }

        //
        // Сводка:
        //     Method for querying short responses of maximum 64 bytes. The responses is TermChar-trimmed.
        internal string QueryShort(string query)
        {
            bool moreDataAvailable = false;
            string text = "";
            Write(query);
            try
            {
                text = _ReadString(64, out moreDataAvailable);
            }
            catch (VisaTimeoutException)
            {
                _NarrowDownVisaTimeoutError("Querying '" + query.Trim() + "' - ");
            }

            if (moreDataAvailable)
            {
                throw new RsSmabException(base.Session.ResourceName, $"Querying '{query.Trim()}' - more data available than expected Maximum response length of {64} bytes is allowed. Response: '{text.Trim()}'");
            }

            return text.Trim(_termChar);
        }

        //
        // Сводка:
        //     Combines Write + ReadStringUnknownLength()
        internal string QueryStringUnknownLength(string query)
        {
            string result = "";
            Write(query);
            try
            {
                result = _ReadStringUnknownLength();
                return result;
            }
            catch (VisaTimeoutException)
            {
                _NarrowDownVisaTimeoutError("Querying '" + query.Trim() + "' - ");
                return result;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown length, and supresses any timeout exceptions. If the
        //     VISA read ends with timeout, response is null You can set the VISA timeout locally
        //     just for this one call
        internal string QueryStringNoToutError(string query, int? timeout = null)
        {
            int timeout2 = base.Timeout;
            string result = null;
            try
            {
                if (timeout.HasValue)
                {
                    base.Timeout = timeout.Value;
                }

                result = QueryStringUnknownLength(query);
                return result;
            }
            catch (VisaTimeoutException)
            {
                return result;
            }
            catch (InstrumentStatusException)
            {
                return result;
            }
            finally
            {
                base.Timeout = timeout2;
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization. The response length is unlimited. If timeoutMs
        //     is set to -1, it is taken from the current OPCtimeout value.
        internal string QueryStringWithOpc(string query, int? timeoutMs)
        {
            InstrumentErrors.AssertQueryContainsQuestionMark(base.Session.ResourceName, query, "Query with VISA timeout");
            timeoutMs = _ResolveOpcTimeout(timeoutMs);
            if (VxiCapable && _opcWaitMode != WaitForOpcMode.OpcQuery)
            {
                StatusByte stb = _WriteAndWaitForOpc(query, isQuery: true, timeoutMs);
                _CheckMessageAvailableAfterOpc(stb, query, timeoutMs.Value, "Query String With OPC");
                return _ReadStringUnknownLength();
            }

            Write(query);
            int timeout = base.Timeout;
            base.Timeout = timeoutMs.Value;
            try
            {
                string result = _ReadStringUnknownLength();
                if (_opcWaitMode == WaitForOpcMode.OpcQuery)
                {
                    QueryOpc();
                    return result;
                }

                return result;
            }
            finally
            {
                base.Timeout = timeout;
            }
        }

        //
        // Сводка:
        //     Sends *OPC? query and reads the result
        internal bool QueryOpc()
        {
            if (Settings.DisableOpcQuery)
            {
                return false;
            }

            return QueryShort("*OPC?").ToBoolean();
        }

        //
        // Сводка:
        //     Sends *OPC? query and reads the result. The VISA timeout is defined only for
        //     this call
        internal bool QueryOpc(int visaTimeout)
        {
            if (Settings.DisableOpcQuery)
            {
                return false;
            }

            if (visaTimeout <= 0)
            {
                return QueryOpc();
            }

            int timeout = base.Timeout;
            base.Timeout = visaTimeout;
            try
            {
                return QueryShort("*OPC?").ToBoolean();
            }
            finally
            {
                base.Timeout = timeout;
            }
        }

        //
        // Сводка:
        //     Clears IO buffers and the ESR register before reading/writing responses synchronized
        //     with *OPC;
        internal void ClearBeforeRead()
        {
            if (SessionType == SessionKind.Nrpz)
            {
                return;
            }

            if (!VxiCapable)
            {
                Write("*CLS");
                QueryStringUnknownLength("*OPC?");
            }

            StatusByte statusByte = (FastSweep ? _ReadStb(blockTmoSettings: false) : _QueryStb());
            StatusByte statusByte2 = StatusByte.ErrorQueueNotEmpty | StatusByte.MessageAvailable | StatusByte.EventStatusByte;
            if ((statusByte & statusByte2) == 0)
            {
                return;
            }

            while ((statusByte & (StatusByte.ErrorQueueNotEmpty | StatusByte.MessageAvailable | StatusByte.EventStatusByte)) > StatusByte.None)
            {
                if ((statusByte & StatusByte.ErrorQueueNotEmpty) > StatusByte.None)
                {
                    Write("*CLS");
                }

                if ((statusByte & StatusByte.MessageAvailable) > StatusByte.None)
                {
                    _FlushJunkData(totalFlush: true);
                }

                if ((statusByte & StatusByte.EventStatusByte) > StatusByte.None)
                {
                    Write("*CLS");
                    QueryAndClearEsr();
                }

                StatusByte statusByte3 = statusByte;
                statusByte = _QueryStb();
                if (statusByte == statusByte3)
                {
                    throw new RsSmabException(base.Session.ResourceName, $"Can not clear instrument's status subsystem. Status Byte: {statusByte}");
                }
            }
        }

        //
        // Сводка:
        //     Returns one response to the SYSTEM:ERROR? query If 0,"No error is returned, the
        //     return string is null
        internal string QuerySystemError()
        {
            Write("SYST:ERR?");
            string text = _ReadStringUnknownLength();
            if (text.StartsWith("0,", StringComparison.Ordinal))
            {
                return null;
            }

            return text;
        }

        //
        // Сводка:
        //     Returns all errors in the instrument's error queue Used query: "SYSTEM:ERROR?"
        internal List<string> QuerySystemErrorAll()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < 50; i++)
            {
                string text = QuerySystemError();
                if (string.IsNullOrEmpty(text))
                {
                    break;
                }

                list.Add(text);
            }

            return list;
        }

        //
        // Сводка:
        //     Writes all the stream data as binary data to the instrument It sends the entered
        //     command, followed by the constructed binary data header and the binary data from
        //     the stream.
        internal void WriteBinaryData(string command, Stream stream)
        {
            DateTime now = DateTime.Now;
            string text = Convert.ToString(stream.Length);
            command = command.TrimEnd(_termChar);
            string text2 = ((stream.Length <= 999999999) ? $"{command}#{text.Length}{text}" : (command + "#(" + text + ")"));
            if (stream.Length <= IoSegmentSize)
            {
                byte[] array = new byte[stream.Length + text2.Length + (_addTermCharToWriteBinData ? 1 : 0)];
                Buffer.BlockCopy(Encoding.ASCII.GetBytes(text2), 0, array, 0, text2.Length);
                stream.Read(array, text2.Length, (int)stream.Length);
                if (_addTermCharToWriteBinData)
                {
                    Buffer.BlockCopy(new byte[1] { Convert.ToByte(_termChar) }, 0, array, array.Length - 1, 1);
                }

                Write(array);
                _InvokeWriteSegmentEvent(now, 1, (int)stream.Length, finished: true, stream.Length, stream.Length);
                return;
            }

            try
            {
                base.SendEndEnable = false;
                long num = stream.Length;
                long num2 = 0L;
                _DelayBeforeWrite();
                base.Write(text2);
                int num3 = 1;
                while (num > IoSegmentSize)
                {
                    int num4 = WriteFromStream(stream, IoSegmentSize);
                    num -= num4;
                    num2 += num4;
                    _InvokeWriteSegmentEvent(now, num3, num4, finished: false, stream.Length, num2);
                    num3++;
                }

                if (_addTermCharToWriteBinData)
                {
                    WriteFromStream(stream, (int)num);
                    base.SendEndEnable = true;
                    Write(new byte[1] { Convert.ToByte(_termChar) });
                }
                else
                {
                    base.SendEndEnable = true;
                    WriteFromStream(stream, (int)num);
                }

                _InvokeWriteSegmentEvent(now, num3, (int)num, finished: true, stream.Length, stream.Length);
            }
            finally
            {
                base.SendEndEnable = true;
            }
        }

        //
        // Сводка:
        //     Reads binary data to byte array
        internal byte[] ReadBinaryData(bool exceptionIfNotBinData, out bool isBinData)
        {
            byte[] result = null;
            isBinData = false;
            try
            {
                result = _ReadBinaryData(exceptionIfNotBinData, out isBinData);
                return result;
            }
            catch (VisaTimeoutException)
            {
                _NarrowDownVisaTimeoutError("Reading binary data - ");
                return result;
            }
        }

        //
        // Сводка:
        //     Queries binary data to byte array
        internal byte[] QueryBinaryData(string query, bool exceptionIfNotBinData, out bool isBinData)
        {
            byte[] result = null;
            isBinData = false;
            Write(query);
            try
            {
                result = _ReadBinaryData(exceptionIfNotBinData, out isBinData);
                return result;
            }
            catch (VisaTimeoutException)
            {
                _NarrowDownVisaTimeoutError("Querying binary data, SCPI query '" + query.Trim() + "' - ");
                return result;
            }
        }

        //
        // Сводка:
        //     Queries binary data and returns it in the entered Stream.
        internal bool QueryBinaryData(string query, Stream stream, bool exceptionIfNotBinData)
        {
            bool result = false;
            Write(query);
            try
            {
                result = _ReadBinaryData(stream, exceptionIfNotBinData);
                return result;
            }
            catch (VisaTimeoutException)
            {
                _NarrowDownVisaTimeoutError("Querying binary data to stream, SCPI query '" + query.Trim() + "' - ");
                return result;
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization. If timeoutMs is set to -1, it is taken from the
        //     current OPC Timeout value
        internal byte[] QueryBinaryDataWithOpc(string query, bool exceptionIfNotBinData, out bool isBinData, int? timeoutMs)
        {
            timeoutMs = _ResolveOpcTimeout(timeoutMs);
            if (VxiCapable && _opcWaitMode != WaitForOpcMode.OpcQuery)
            {
                StatusByte stb = _WriteAndWaitForOpc(query, isQuery: true, timeoutMs);
                _CheckMessageAvailableAfterOpc(stb, query, timeoutMs.Value, "Query Binary Data with OPC");
                return _ReadBinaryData(exceptionIfNotBinData, out isBinData);
            }

            InstrumentErrors.AssertQueryContainsQuestionMark(base.Session.ResourceName, query, "Query String With OPC");
            Write(query);
            int timeout = base.Timeout;
            base.Timeout = timeoutMs.Value;
            try
            {
                byte[] result = _ReadBinaryData(exceptionIfNotBinData, out isBinData);
                if (_opcWaitMode == WaitForOpcMode.OpcQuery)
                {
                    QueryOpc();
                    return result;
                }

                return result;
            }
            finally
            {
                base.Timeout = timeout;
            }
        }

        //
        // Сводка:
        //     Returns true, if error queue contains at least one error
        internal bool ErrorQueueIsNotEmpty()
        {
            return (_QueryStb() & StatusByte.ErrorQueueNotEmpty) > StatusByte.None;
        }
    }
}
