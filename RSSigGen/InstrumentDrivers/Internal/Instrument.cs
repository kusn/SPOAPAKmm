using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using RSSigGen.RS;

namespace RSSigGen.InstrumentDrivers.Internal
{
    internal class Instrument : IDisposable
    {
        internal class ReturnArgLinkedEventArgs : EventArgs
        {
            internal string Name { get; set; }

            internal string Context { get; set; }

            internal object Value { get; set; }

            internal DateTime TimeStamp { get; set; }
        }

        private readonly VisaSession _session;

        private readonly StreamLogger _logger;

        private readonly InstrOptionsParseMode _optsParseMode;

        private string _idnString;

        private readonly bool _idnModelFullName;

        private readonly Dictionary<string, RepeatedCapability> _globalRepCaps;

        private readonly InternalLinker _linker;

        private object _locker;

        private InstrumentOptions _instrOptions;

        //
        // Сводка:
        //     Handlers for all the Write with OPC events Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args)
        internal EventHandler<InstrEventArgs> WriteWithOpcHandler;

        //
        // Сводка:
        //     Handlers for all the Query with OPC events Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args)
        internal EventHandler<InstrEventArgs> QueryWithOpcHandler;

        //
        // Сводка:
        //     Manufacturer of the instrument (From *IDN?)
        internal string Manufacturer { get; private set; }

        //
        // Сводка:
        //     // e.g. FSW or NRP. If _identificationModelFullName == True, the Model is FSW26
        //     or NRP67A
        internal string Model { get; private set; }

        //
        // Сводка:
        //     always full name - e.g. FSW26 or NRP67A (From *IDN?)
        internal string FullInstrumentModelName { get; private set; }

        //
        // Сводка:
        //     Instrument's serial number (From *IDN?)
        internal string SerialNumber { get; private set; }

        //
        // Сводка:
        //     Instrument's firmware version (From *IDN?)
        internal string FirmwareRevision { get; private set; }

        //
        // Сводка:
        //     Setting of the Instrument session
        internal SessionSettings Settings { get; }

        //
        // Сводка:
        //     Resource name of the Visa Instrument
        internal string ResourceName { get; }

        //
        // Сводка:
        //     If True, the instrument performs CheckStatus() after each SCPI command
        internal bool QueryInstrumentStatus { get; set; }

        //
        // Сводка:
        //     Any positive number changes VISA Timeout for the duration of STB polling
        internal int ReadStbVisaTimeoutMs
        {
            get
            {
                return _session.ReadStbVisaTimeout;
            }
            set
            {
                _session.ReadStbVisaTimeout = value;
            }
        }

        //
        // Сводка:
        //     Session type: Gpib, Serial, Vxi11, Hislip, Socket, Usb
        internal VisaSession.SessionKind SessionType => _session.SessionType;

        //
        // Сводка:
        //     Delay before each Read()
        internal int ReadDelay
        {
            get
            {
                return _session.ReadDelay;
            }
            set
            {
                _session.ReadDelay = value;
            }
        }

        //
        // Сводка:
        //     Delay before each Write()
        internal int WriteDelay
        {
            get
            {
                return _session.WriteDelay;
            }
            set
            {
                _session.WriteDelay = value;
            }
        }

        //
        // Сводка:
        //     Use only in Simulation mode. This sets/reads the instrument's *IDN? string. The
        //     *IDN? string is immediately parsed for properties Manufacturer, Model, SerialNumber,
        //     FirmwareRevision
        internal string IdnString
        {
            get
            {
                return _idnString;
            }
            set
            {
                _ParseIdnString(_idnString = value);
            }
        }

        //
        // Сводка:
        //     True: Instrument in simulation mode
        internal bool Simulate => _session.Session.Simulate;

        //
        // Сводка:
        //     Maximal size of one transferred data segment
        internal int IoSegmentSize
        {
            get
            {
                return _session.IoSegmentSize;
            }
            set
            {
                _session.IoSegmentSize = value;
            }
        }

        //
        // Сводка:
        //     Manufacturer of VISA used by the instrument
        internal string VisaManufacturer => _session.VisaManufacturer;

        //
        // Сводка:
        //     Used Visa DLL name including bittness
        internal string VisaDllName => _session.VisaDllName;

        //
        // Сводка:
        //     VISA Timeout
        internal int VisaTimeoutMs
        {
            get
            {
                return _session.Timeout;
            }
            set
            {
                _session.Timeout = value;
            }
        }

        //
        // Сводка:
        //     Opc Timeout in milliseconds
        internal int OpcTimeoutMs
        {
            get
            {
                return _session.OpcTimeout;
            }
            set
            {
                _session.OpcTimeout = value;
            }
        }

        //
        // Сводка:
        //     Logging of the VISA communication
        internal bool LoggingEnabled
        {
            get
            {
                return _logger.LoggingEnabled;
            }
            set
            {
                _logger.LoggingEnabled = value;
            }
        }

        //
        // Сводка:
        //     Logger debug messages to include source information
        internal bool LoggingDebugMessages
        {
            get
            {
                return _logger.LoggingDebugEnabled;
            }
            set
            {
                _logger.LoggingDebugEnabled = value;
            }
        }

        //
        // Сводка:
        //     Sets / Gets Instrument *OPC? query sending after each settings When true, the
        //     driver sends *OPC? every time a write command is performed For queries, the *OPC?
        //     is skipped Use this if you want to make sure your sequence is performed command-after-command
        internal bool OpcQueryAfterEachSetting { get; set; }

        //
        // Сводка:
        //     Defines the coding of floating-point numbers in binary data
        internal InstrBinaryFloatNumbersFormat BinFloatNumbersFormat { get; set; }

        //
        // Сводка:
        //     Defines the coding of integer numbers in binary data
        internal InstrBinaryIntegerNumbersFormat BinIntegerNumbersFormat { get; set; }

        //
        // Сводка:
        //     Simulation mode *OPT? response. This is set-only property to apply a new instrument
        //     options string. In real mode, the actual *OPT? response it parsed. The string
        //     is parsed with the parse mode defined in InstrumentProperties when initializing
        //     the Instrument.
        internal string InstrumentOptionsString
        {
            set
            {
                if (_optsParseMode != 0)
                {
                    _instrOptions = new InstrumentOptions(value, _optsParseMode);
                }
            }
        }

        //
        // Сводка:
        //     Instrument Options object for installed option-checking operations This is a
        //     lazy property, the internal property _instrOptions is initialized on the first
        //     access
        internal InstrumentOptions InstrOptions
        {
            get
            {
                if (_instrOptions == null)
                {
                    _instrOptions = _QueryOptionsAndParse(Settings.OptionsParseMode);
                }

                return _instrOptions;
            }
        }

        //
        // Сводка:
        //     Timeout for Self-test procedure
        internal int SelfTestTimeout { get; set; }

        //
        // Сводка:
        //     Serialized session data
        internal byte[] Session => _session.Session.Serialize();

        //
        // Сводка:
        //     Register for this event to get an event if a return argument was suppressed
        internal EventHandler<ReturnArgLinkedEventArgs> ReturnArgLinked
        {
            get
            {
                return _linker.Callback;
            }
            set
            {
                _linker.Callback = value;
            }
        }

        //
        // Сводка:
        //     Event handler for segmented reads
        internal EventHandler<InstrSegmentEventArgs> ReadSegmentHandler
        {
            get
            {
                return _session.ReadSegmentHandler;
            }
            set
            {
                _session.ReadSegmentHandler = value;
            }
        }

        //
        // Сводка:
        //     Event handler for segmented writes
        internal EventHandler<InstrSegmentEventArgs> WriteSegmentHandler
        {
            get
            {
                return _session.WriteSegmentHandler;
            }
            set
            {
                _session.WriteSegmentHandler = value;
            }
        }

        //
        // Сводка:
        //     Opening an instrument session. If simulate is true, it cannot be later switched
        //     to false anymore
        internal Instrument(string resourceName, byte[] directSession, XElement xml)
        {
            _locker = new object();
            _session = null;
            _logger = new StreamLogger();
            _globalRepCaps = new Dictionary<string, RepeatedCapability>();
            ResourceName = resourceName;
            SessionSettings sessionSettings = new SessionSettings(xml, resourceName, null, null);
            bool simulate = sessionSettings.Simulate;
            string text = sessionSettings.SelectVisa;
            if (sessionSettings.PreferRsVisa && string.IsNullOrEmpty(text))
            {
                text = "RsVisaPrio";
            }

            _session = new VisaSession(resourceName, directSession, xml, text, simulate);
            Settings = _session.Settings;
            _optsParseMode = Settings.OptionsParseMode;
            _idnModelFullName = Settings.IdnModelFullName;
            _logger.MaxBinEntryLength = Settings.LoggingMaxBinEntryLength;
            _logger.MaxAsciiEntryLength = Settings.LoggingMaxAsciiEntryLength;
            LoggingEnabled = Settings.LoggingEnabled;
            LoggingDebugMessages = Settings.LoggingDebug;
            BinFloatNumbersFormat = Settings.BinFloatNumbersFormat;
            BinIntegerNumbersFormat = Settings.BinIntNumbersFormat;
            QueryInstrumentStatus = Settings.QueryInstrumentStatus;
            SelfTestTimeout = Settings.SelfTestTimeout;
            Manufacturer = "Rohde&Schwarz";
            Model = "R&S Instrument";
            SerialNumber = "100001";
            FirmwareRevision = "1.00";
            _linker = new InternalLinker();
            if (Simulate)
            {
                if (Settings.SimulationIdnString != null)
                {
                    IdnString = Settings.SimulationIdnString;
                }
                else if (Settings.SimulationIdnString == null)
                {
                    IdnString = Manufacturer + "," + Model + "," + SerialNumber + ",4.70.300.0036";
                }

                if (Settings.SimulationOptString != null)
                {
                    InstrumentOptionsString = Settings.SimulationOptString;
                }
                else if (Settings.SimulationOptString == null)
                {
                    InstrumentOptionsString = "K0";
                }
            }
            else
            {
                _session.ClearBeforeRead();
                _idnString = _session.QueryStringUnknownLength("*IDN?").TrimStringResponse();
                _ParseIdnString(_idnString);
            }
        }

        //
        // Сводка:
        //     String representation of the object: "Instrument {vendor}, {Session Kind}, '{resource
        //     name}'"
        public override string ToString()
        {
            if (Simulate)
            {
                return "Simulated, Model: '" + Model + "', ResourceName: '" + ResourceName + "'";
            }

            return "Instrument Model: '" + Model + "', ResourceName: '" + ResourceName + "'";
        }

        //
        // Сводка:
        //     Assigns new locking object. Use it to synchronise between multiple Instrument
        //     objects
        internal void AssignLock(object locker)
        {
            _locker = locker ?? throw new ArgumentException("locker");
        }

        //
        // Сводка:
        //     Returns locking object. Use it to synchronise between multiple Instrument objects
        internal object GetLock()
        {
            return _locker;
        }

        //
        // Сводка:
        //     Queries *OPT? and creates a new instance of the InstrumentOptions
        private InstrumentOptions _QueryOptionsAndParse(InstrOptionsParseMode mode)
        {
            lock (_locker)
            {
                if (mode == InstrOptionsParseMode.Skip)
                {
                    return new InstrumentOptions("", mode);
                }

                string text = "K0";
                string text2 = text;
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    text2 = _session.QueryStringNoToutError("*OPT?", 1000) ?? text;
                }

                InstrumentOptions result = new InstrumentOptions(text2, mode);
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("Querying_*OPT?", text2);
                }

                return result;
            }
        }

        //
        // Сводка:
        //     Parse the *IDN? response to Manufacturer, Model, SerialNumber and FirmwareRevision
        private void _ParseIdnString(string idnString)
        {
            Match match = new Regex("(?<manufacturer>[\\w& ]+),(?<model>[a-zA-Z]+)(?<modelSuffix>[\\-0-9a-zA-Z]*),(?<serialNumber>[^,]+),(?<revision>[\\w \\.\\-/]+)").Match(idnString);
            if (match.Success)
            {
                Manufacturer = match.Groups["manufacturer"].Value;
                SerialNumber = match.Groups["serialNumber"].Value;
                FirmwareRevision = match.Groups["revision"].Value;
                Model = match.Groups["model"].Value;
                FullInstrumentModelName = Model + match.Groups["modelSuffix"].Value;
                if (_idnModelFullName)
                {
                    Model = FullInstrumentModelName;
                }
            }
        }

        //
        // Сводка:
        //     Parses entered response string to string, Returns only the string part of the
        //     message e.g.: response = '-110,"Command error"' returns: 'Command error'
        private string _ParseErrorQueryResponse(string response)
        {
            Match match = new Regex("^(?<code>-?[\\d]+).*?(\"(?<msg>.*)\")").Match(response);
            if (!match.Success)
            {
                throw new RsSmabException(ResourceName, "Unexpected error entry response: \"" + response + "\"");
            }

            return match.Groups["msg"].Value;
        }

        //
        // Сводка:
        //     Replaces all the global repCaps in the command: e.g. "{instance}" => "1"
        private string _ReplaceGlobalRepCaps(string command)
        {
            foreach (KeyValuePair<string, RepeatedCapability> globalRepCap in _globalRepCaps)
            {
                command = command.Replace(globalRepCap.Key, globalRepCap.Value.GetCmdStringValue());
            }

            return command;
        }

        //
        // Сводка:
        //     Queries binary data to byte array. If the exceptionIfNotBinData is true, an exception
        //     is thrown if the read data does not begin with '#' Returns true, if the response
        //     was binary data, otherwise false
        private byte[] _QueryBinaryData(string query, bool exceptionIfNotBinData, out bool isBinData)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                byte[] array;
                if (!Simulate)
                {
                    array = _session.QueryBinaryData(query, exceptionIfNotBinData, out isBinData);
                }
                else
                {
                    array = new byte[11]
                    {
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                        10
                    };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.LogBinaryData("QueryBinaryData", query.Trim(), array);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Query binary data with OPC synchronization. Also performs error checking if the
        //     property QueryInstrumentStatus is set to true and allowCheckStatus is True If
        //     the exceptionIfNotBinData is true, an exception is thrown if the read data does
        //     not begin with '#' If you omit the timeout out or set it to null / -1 / 0, the
        //     method uses the current OPC timeout
        private byte[] _QueryBinaryDataWithOpc(string query, bool exceptionIfNotBinData, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                byte[] array;
                if (!Simulate)
                {
                    array = _session.QueryBinaryDataWithOpc(query, exceptionIfNotBinData, out var _, timeoutMs);
                    CheckStatus();
                    _session.QueryAndClearEsr();
                }
                else
                {
                    array = new byte[11]
                    {
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                        10
                    };
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryDataWithOpc", $"Query: '{query.Trim()}', Data Length: {array.Length} bytes");
                }

                return array;
            }
        }

        //
        // Сводка:
        //     Checks the instrument's IdnString against the provided patterns. Throws the RsSmabException,
        //     if none of the patterns in the array are found in the instrument's IdnString.
        //     idnPatterns - RegEx patterns to match in the IdnString supportedInstrModels is
        //     a list of instrument models only used for the exception message
        internal void FitsIdnPattern(List<string> idnPatterns, List<string> supportedInstrModels)
        {
            if (string.IsNullOrEmpty(_idnString))
            {
                throw new RsSmabException(ResourceName, "Instrument IDN query was not assigned yet");
            }

            foreach (string idnPattern in idnPatterns)
            {
                if (Regex.IsMatch(_idnString, idnPattern, RegexOptions.IgnoreCase))
                {
                    return;
                }
            }

            string text = string.Join("\n", idnPatterns);
            string text2 = "Instrument model '" + Model + "' is not supported by the driver.\n*IDN? response: '" + _idnString + "'\nAllowed *IDN? pattern(s)\n: " + text + "\n";
            if (supportedInstrModels != null)
            {
                text2 = text2 + "Supported instrument model(s): " + string.Join(", ", supportedInstrModels) + "\n";
            }

            text2 += "You can suppress this exception by setting the parameter 'idQuery' to false.";
            throw new RsSmabException(ResourceName, text2);
        }

        //
        // Сводка:
        //     Perform standard self test by sending *TST? query and returns the result
        internal int SelfTest(int selftestTimeout)
        {
            lock (_locker)
            {
                int result;
                if (!Simulate)
                {
                    string text = QueryStringWithOpc("*TST?", allowCheckStatus: true, selftestTimeout);
                    Match match = new Regex("^(?<code>-?[\\d]+)(,(?<msg>.*))?").Match(text);
                    if (!match.Success)
                    {
                        throw new RsSmabException(ResourceName, "Unexpected response on *TST? (selftest) query: " + text.Trim());
                    }

                    result = match.Groups["code"].Value.ToInt32(0);
                }
                else
                {
                    result = 0;
                }

                CheckStatus();
                return result;
            }
        }

        //
        // Сводка:
        //     Perform standard self test by sending *TST? query
        internal int SelfTest()
        {
            return SelfTest(SelfTestTimeout);
        }

        //
        // Сводка:
        //     Check status method to be used internally Throws InstrumentStatusException in case
        //     of an error in the instrument's error queue. The procedure is skipped, if the
        //     QueryInstrumentStatus is set to false or force it with forceCheck to true
        internal void CheckStatus(bool forceCheck)
        {
            lock (_locker)
            {
                if (!forceCheck && !QueryInstrumentStatus)
                {
                    return;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    if (Settings.StbInErrorCheck)
                    {
                        if (_session.ErrorQueueIsNotEmpty())
                        {
                            if (_session.HasErrHandlerInstalled)
                            {
                                if (_logger.LoggingEnabled)
                                {
                                    _logger.Log("Check Status", "Errors reported in the error queue, read by an error handler");
                                }

                                throw new InstrumentStatusException(ResourceName, "Instrument error(s) detected. Errors are read by an error handler", new List<string> { "" });
                            }

                            _AssertNoSystErrorsAndLog();
                        }
                    }
                    else
                    {
                        _AssertNoSystErrorsAndLog();
                    }
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                    _logger.Log("CheckStatus", "OK");
                }
            }
        }

        //
        // Сводка:
        //     Check status method to be used internally Throws InstrumentStatusException in case
        //     of an error in the instrument's error queue. The procedure is skipped, if the
        //     QueryInstrumentStatus is set to false.
        internal void CheckStatus()
        {
            CheckStatus(forceCheck: false);
        }

        //
        // Сводка:
        //     Asserts that the SYST:ERR? does not return any errors. If so, throw the InstrumentStatusException.
        private void _AssertNoSystErrorsAndLog()
        {
            List<string> list = _session.QuerySystemErrorAll().Select(new Func<string, string>(_ParseErrorQueryResponse)).ToList();
            if (list.Count <= 0)
            {
                return;
            }

            if (_logger.LoggingEnabled)
            {
                if (list.Count == 1)
                {
                    _logger.Log("Check Status", "Error: " + list[0]);
                }
                else
                {
                    _logger.Log("Check Status", string.Format("{0} Error(s): {1}", list.Count, string.Join(" | ", list)));
                }
            }

            InstrumentErrors.AssertNoInstrumentStatusErrors(ResourceName, list);
        }

        //
        // Сводка:
        //     Returns true, if the current instrument model fits the entered model string
        internal bool IsInstrumentModel(string model)
        {
            return Model == model;
        }

        //
        // Сводка:
        //     Adds global repcap identified with the name
        internal void AddGlobalRepCap(string name, RepeatedCapability repCap)
        {
            _globalRepCaps.Add(name, repCap);
        }

        //
        // Сводка:
        //     Sets the new global repCap value as enum value Can not be Default
        internal void SetGlobalRepCapValue(string name, object enumValue)
        {
            try
            {
                _globalRepCaps[name].SetEnumValue(enumValue);
            }
            catch (ArgumentException)
            {
                throw new RsSmabException(ResourceName, $"Commands group Repeated capability '{_globalRepCaps[name].Name}' cannot be set to the value '{enumValue}'\n" + "You have to select a concrete value");
            }
        }

        //
        // Сводка:
        //     Returns new current global repcap value as enum object
        internal object GetGlobalRepCapValue(string name)
        {
            return _globalRepCaps[name].GetEnumValue();
        }

        //
        // Сводка:
        //     Clears instrument's status subsystem
        internal void ClearStatus()
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    _session.Clear();
                    _session.ClearBeforeRead();
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("ClearStatus", "");
                }

                CheckStatus();
            }
        }

        //
        // Сводка:
        //     Sends *RST to the instrument
        internal void Reset()
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    ClearStatus();
                    Write("*RST");
                    QueryOpc();
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("Reset", "*RST");
                }

                CheckStatus();
            }
        }

        //
        // Сводка:
        //     Uses SYSTEM:ERROR? query in a loop to read and delete all the errors in the instrument's
        //     error queue. The errors are ordered from the oldest ones to the newest one If
        //     no error is present, the method returns an empty collection
        internal List<string> QueryErrorsAll()
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                List<string> list = (Simulate ? new List<string>() : (_session.ErrorQueueIsNotEmpty() ? _session.QuerySystemErrorAll().Select(new Func<string, string>(_ParseErrorQueryResponse)).ToList() : new List<string>()));
                if (_logger.LoggingEnabled)
                {
                    if (list.Count > 0)
                    {
                        _logger.Log("QueryAllErrors", string.Format("{0} Error(s): {1}", list.Count, string.Join(" | ", list)));
                    }
                    else
                    {
                        _logger.Log("QueryAllErrors", "No Error");
                    }
                }

                return list;
            }
        }

        //
        // Сводка:
        //     Uses SYSTEM:ERROR? query to read and delete the oldest error in the instrument's
        //     error queue. If no error is present, the method returns {code=0, msg='No Error'}
        internal string QueryOldestError()
        {
            lock (_locker)
            {
                string text = "No Error";
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    string text2 = _session.QuerySystemError();
                    text = (string.IsNullOrEmpty(text2) ? "No Error" : _ParseErrorQueryResponse(text2));
                }

                if (_logger.LoggingEnabled)
                {
                    if (text.ToLower() != "no error")
                    {
                        _logger.Log("QueryErrorFirst", "Error: " + text);
                    }
                    else
                    {
                        _logger.Log("QueryErrorFirst", "No Error");
                    }
                }

                return text;
            }
        }

        //
        // Сводка:
        //     Writes string command to the instrument
        internal void Write(string command)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                command = _ReplaceGlobalRepCaps(command);
                if (!Simulate)
                {
                    _session.Write(command);
                    if (OpcQueryAfterEachSetting)
                    {
                        _session.QueryOpc();
                    }
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("Write", command.TrimEnd());
                }

                CheckStatus();
            }
        }

        //
        // Сводка:
        //     Writes command with OPC synchronization. Also performs error checking if the
        //     property QueryInstrumentStatus is set to true and allowCheckStatus is true. If
        //     you omit the timeout or set it to null / -1 / 0, the method uses the current
        //     OPC timeout
        internal void WriteWithOpc(string command, bool allowCheckStatus, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                command = _ReplaceGlobalRepCaps(command);
                if (!Simulate)
                {
                    _session.WriteWithOpc(command, timeoutMs);
                    if (allowCheckStatus)
                    {
                        CheckStatus();
                        _session.QueryAndClearEsr();
                    }
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("WriteWithOpc", command.TrimEnd());
                }
            }
        }

        //
        // Сводка:
        //     Writes command with OPC synchronization. Also performs error checking if the
        //     property QueryInstrumentStatus is set to true. If you omit the timeout out or
        //     set it to null / -1 / 0, the method uses the current OPC timeout
        internal void WriteWithOpc(string command, int? timeoutMs = null)
        {
            WriteWithOpc(command, allowCheckStatus: true, timeoutMs);
        }

        //
        // Сводка:
        //     Sends a query and reads response from the instrument. The returned response is
        //     trimmed of any trailing TermChars and has no length limit.
        internal string QueryString(string query)
        {
            lock (_locker)
            {
                string text = "Simulating";
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryString", query, text);
                }

                CheckStatus();
                return text;
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization. Also performs error checking if QueryInstrumentStatus
        //     is true and allowCheckStatus is true If you omit the timeout out or set it to
        //     null / -1 / 0, the method uses the current OPC timeout
        internal string QueryStringWithOpc(string query, bool allowCheckStatus, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                if (!Simulate)
                {
                    text = _session.QueryStringWithOpc(query, timeoutMs);
                    if (allowCheckStatus)
                    {
                        CheckStatus();
                        _session.QueryAndClearEsr();
                    }
                }
                else
                {
                    text = "0, Simulation Mode";
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryStringWithOpc", query, text);
                }

                CheckStatus();
                return text;
            }
        }

        //
        // Сводка:
        //     Query with OPC synchronization. Also performs error checking if QueryInstrumentStatus
        //     is true. The response is trimmed of any trailing TermChars and has no length
        //     limit. If you omit the timeout out or set it to null / -1 / 0, the method uses
        //     the current OPC timeout
        internal string QueryStringWithOpc(string query, int? timeoutMs = null)
        {
            return QueryStringWithOpc(query, allowCheckStatus: true, timeoutMs);
        }

        //
        // Сводка:
        //     Sends a query and reads response from the instrument as Int32
        internal int QueryInt32(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0" : _session.QueryShort(query));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryInt32", query, text);
                }

                CheckStatus();
                return text.ToInt32();
            }
        }

        //
        // Сводка:
        //     Sends opc-synced query and reads response from the instrument as Int32. If you
        //     omit the timeout out or set it to null / -1 / 0, the method uses the current
        //     OPC timeout
        internal int QueryInt32WithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0" : _session.QueryStringWithOpc(query, timeoutMs));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryInt32WithOpc", query, text);
                }

                CheckStatus();
                _session.QueryAndClearEsr();
                return text.ToInt32();
            }
        }

        //
        // Сводка:
        //     Sends a query and reads response from the instrument as Int64
        internal long QueryInt64(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0" : _session.QueryShort(query));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryInt64", query, text);
                }

                CheckStatus();
                return text.ToInt64();
            }
        }

        //
        // Сводка:
        //     Sends opc-synced query and reads response from the instrument as Int64. If you
        //     omit the timeout out or set it to null / -1 / 0, the method uses the current
        //     OPC timeout
        internal long QueryInt64WithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0" : _session.QueryStringWithOpc(query, timeoutMs));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryInt64WithOpc", query, text);
                }

                CheckStatus();
                _session.QueryAndClearEsr();
                return text.ToInt64();
            }
        }

        //
        // Сводка:
        //     Sends a query and reads response from the instrument as Double
        internal double QueryDouble(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0.0" : _session.QueryShort(query));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryDouble", query, text);
                }

                CheckStatus();
                return text.ToDouble();
            }
        }

        //
        // Сводка:
        //     Sends opc-synced query and reads response from the instrument as Double. If you
        //     omit the timeout out or set it to null / -1 / 0, the method uses the current
        //     OPC timeout
        internal double QueryDoubleWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "0.0" : _session.QueryStringWithOpc(query, timeoutMs));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryDoubleWithOpc", query, text);
                }

                CheckStatus();
                _session.QueryAndClearEsr();
                return text.ToDouble();
            }
        }

        //
        // Сводка:
        //     Sends a query and reads response from the instrument as Boolean
        internal bool QueryBoolean(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "False" : _session.QueryShort(query));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBoolean", query, text);
                }

                CheckStatus();
                return text.ToBoolean();
            }
        }

        //
        // Сводка:
        //     Sends opc-synced query and reads response from the instrument as Boolean. If
        //     you omit the timeout out or set it to null / -1 / 0, the method uses the current
        //     OPC timeout
        internal bool QueryBooleanWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text = (Simulate ? "False" : _session.QueryStringWithOpc(query, timeoutMs));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBooleanWithOpc", query, text);
                }

                CheckStatus();
                _session.QueryAndClearEsr();
                return text.ToBoolean();
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as an array
        //     of comma-separated strings array If the response from the instrument is empty,
        //     the method returns 0-length array.
        internal string[] QueryStringArray(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                string[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                    array = (string.IsNullOrEmpty(text) ? new string[0] : text.Split(','));
                }
                else
                {
                    text = "Simulating element 1,Simulating element 2,Simulating element 3,Simulating element 4";
                    array = text.Split(',');
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryStringArray", query, array.Length, text);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as an array
        //     of comma-separated strings array. If you omit the timeout out or set it to null
        //     / -1 / 0, the method uses the current OPC timeout. If the response from the instrument
        //     is empty, the method returns 0-length array.
        internal string[] QueryStringArrayWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                string[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringWithOpc(query, timeoutMs);
                    array = (string.IsNullOrEmpty(text) ? new string[0] : text.Split(','));
                }
                else
                {
                    text = "Simulating element 1,Simulating element 2,Simulating element 3,Simulating element 4";
                    array = text.Split(',');
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryStringArrayWithOpc", query, array.Length, text);
                }

                CheckStatus();
                _session.QueryAndClearEsr();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as comma-separated
        //     double array If you provide defValue, any parsing exception is suppressed an
        //     the method returns that defValue. If the response from the instrument is empty,
        //     the method returns 0-length array.
        internal double[] QueryAsciiDoubleArray(string query, double? defValue = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                double[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                    array = text.ToDoubleArray(defValue);
                }
                else
                {
                    text = "1e-3, 1.5, 2, 2.5, 3, 3.5, 5, 10, 100.123, 5e6";
                    array = text.ToDoubleArray(defValue);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryAsciiDoubleArray", query, array.Length, text);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as comma-separated
        //     integer array. If you provide defValue, any parsing exception is suppressed an
        //     the method returns that defValue. If the response from the instrument is empty,
        //     the method returns 0-length array.
        internal int[] QueryAsciiInt32Array(string query, int? defValue = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                int[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                    array = text.ToInt32Array(defValue);
                }
                else
                {
                    text = "-10e3, -10, -5, -4, -1, 1, 2, 3, 4, 5, 10, 10e6";
                    array = text.ToInt32Array(defValue);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryAsciiInt32Array", query, array.Length, text);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as comma-separated
        //     integer array. If you provide defValue, any parsing exception is suppressed an
        //     the method returns that defValue. If the response from the instrument is empty,
        //     the method returns 0-length array.
        internal long[] QueryAsciiInt64Array(string query, long? defValue = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                long[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                    array = text.ToInt64Array(defValue);
                }
                else
                {
                    text = "-10e3, -10, -5, -4, -1, 1, 2, 3, 4, 5, 10, 10e6";
                    array = text.ToInt64Array(defValue);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryAsciiInt64Array", query, array.Length, text);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and represents it as comma-separated
        //     booleans array If the response from the instrument is empty, the method returns
        //     0-length array.
        internal bool[] QueryAsciiBooleanArray(string query)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string text;
                bool[] array;
                if (!Simulate)
                {
                    text = _session.QueryStringUnknownLength(query);
                    array = text.ToBooleanArray();
                }
                else
                {
                    text = "False, OFF, True, VI_FALSE, 0, 1, TRUE, ON, VI_TRUE";
                    array = text.ToBooleanArray();
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryAsciiBooleanArray", query, array.Length, text);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and parses it to the given object
        //     structure based on the object attributes. 'structure' is a structure object that
        //     should be filled.
        internal object QueryStructure(string query, object structure)
        {
            lock (_locker)
            {
                string content = QueryString(query);
                ArgumentsStruct argumentsStruct = new ArgumentsStruct(structure);
                if (!Simulate)
                {
                    argumentsStruct.ParseFromCmdResponse(content);
                    _linker.InvokeInternalLinking(argumentsStruct.Args, query);
                }

                return structure;
            }
        }

        //
        // Сводка:
        //     Queries with OPC string of unknown size from instrument, and parses it to the
        //     given object structure based on the object attributes. 'structure' is a structure
        //     object that should be filled. If you omit the timeout out or set it to null /
        //     -1 / 0, the method uses the current OPC timeout
        internal object QueryStructureWithOpc(string query, object structure, int? timeoutMs = null)
        {
            lock (_locker)
            {
                string content = QueryStringWithOpc(query, timeoutMs);
                ArgumentsStruct argumentsStruct = new ArgumentsStruct(structure);
                if (!Simulate)
                {
                    argumentsStruct.ParseFromCmdResponse(content);
                    _linker.InvokeInternalLinking(argumentsStruct.Args, query);
                }

                return structure;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, and returns a string part without
        //     the suppressed argument
        internal string QueryStringSuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                string response = QueryString(query);
                return _linker.CutFromResponseString(suppressed, response, query);
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument, cuts away the part with the suppressed
        //     argument, and represents it as an array of comma-separated strings array
        internal string[] QueryStringArraySuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                string response;
                if (!Simulate)
                {
                    response = _session.QueryStringUnknownLength(query);
                    response = _linker.CutFromResponseString(suppressed, response, query);
                }
                else
                {
                    response = "SuppressedElement,Simulating element 2,Simulating element 3,Simulating element 4";
                }

                string[] array = (string.IsNullOrEmpty(response) ? new string[0] : response.Split(','));
                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryStringArraySuppressed", query, array.Length, response);
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument Returns a string part converted
        //     to double without the suppressed argument
        internal double QueryDoubleSuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                string response = QueryString(query);
                if (Simulate)
                {
                    return 0.0;
                }

                response = _linker.CutFromResponseString(suppressed, response, query);
                return response.ToDouble();
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument Returns a string part converted
        //     to int32 without the suppressed argument
        internal int QueryInt32Suppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                string response = QueryString(query);
                if (Simulate)
                {
                    return 0;
                }

                response = _linker.CutFromResponseString(suppressed, response, query);
                return response.ToInt32();
            }
        }

        //
        // Сводка:
        //     Queries string of unknown size from instrument Returns a string part converted
        //     to boolean without the suppressed argument
        internal bool QueryBooleanSuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                string response = QueryString(query);
                if (Simulate)
                {
                    return false;
                }

                response = _linker.CutFromResponseString(suppressed, response, query);
                return response.ToBoolean();
            }
        }

        //
        // Сводка:
        //     Componses a string from the given object structure and its attributes and sends
        //     it to the instrument.
        internal void WriteStructure(string command, object structure)
        {
            lock (_locker)
            {
                string text = new ArgumentsStruct(structure).ComposeCmdString();
                command = command + " " + text;
                Write(command);
            }
        }

        //
        // Сводка:
        //     Componses a string from the given object structure and its attributes and sends
        //     it to the instrument. If you omit the timeout out or set it to null / -1 / 0,
        //     the method uses the current OPC timeout.
        internal void WriteStructureWithOpc(string command, object structure, int? timeoutMs = null)
        {
            lock (_locker)
            {
                string text = new ArgumentsStruct(structure).ComposeCmdString();
                command = command + " " + text;
                WriteWithOpc(command, timeoutMs);
            }
        }

        //
        // Сводка:
        //     Writes all the stream data as binary data to the instrument It sends the entered
        //     command, followed by the constructed binary data header and the binary data from
        //     the stream.
        internal void WriteBinaryData(string command, Stream stream)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                command = _ReplaceGlobalRepCaps(command);
                if (!Simulate)
                {
                    _session.WriteBinaryData(command, stream);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("WriteBinaryDataToStream", $"{command.Trim()} , sent data length: {stream.Length} bytes");
                }

                CheckStatus();
            }
        }

        //
        // Сводка:
        //     Writes all the data as binary data to the instrument It sends the entered command,
        //     followed by the constructed binary data header and the binary data from the binaryData.
        internal void WriteBinaryData(string command, byte[] binaryData)
        {
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
                _logger.BlockNextLogEntry();
            }

            MemoryStream memoryStream = new MemoryStream(binaryData);
            WriteBinaryData(command, memoryStream);
            memoryStream.Close();
            if (_logger.LoggingEnabled)
            {
                _logger.LogBinaryData("WriteBinaryData", command, binaryData);
            }
        }

        //
        // Сводка:
        //     Queries binary data from the instrument and returns it as byte array
        internal byte[] QueryBinaryData(string query)
        {
            bool isBinData;
            return _QueryBinaryData(query, exceptionIfNotBinData: true, out isBinData);
        }

        //
        // Сводка:
        //     Queries binary data from the instrument and returns it to the provided stream
        internal void QueryBinaryData(string query, Stream stream)
        {
            lock (_locker)
            {
                long length = stream.Length;
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                if (!Simulate)
                {
                    _session.QueryBinaryData(query, stream, exceptionIfNotBinData: true);
                }
                else
                {
                    byte[] array = new byte[11]
                    {
                        0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                        10
                    };
                    stream.Write(array, 0, array.Length);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBinaryDataToStream", $"{query.Trim()} , received data length: {stream.Length - length} bytes");
                }

                CheckStatus();
            }
        }

        //
        // Сводка:
        //     Query binary data with OPC synchronization. Also performs error checking if the
        //     property QueryInstrumentStatus is set to true. If you omit the timeout out or
        //     set it to null / -1 / 0, the method uses the current OPC timeout
        internal byte[] QueryBinaryDataWithOpc(string query, int? timeoutMs = null)
        {
            return _QueryBinaryDataWithOpc(query, exceptionIfNotBinData: true, timeoutMs);
        }

        //
        // Сводка:
        //     Query binary data with OPC synchronization, and returns it in the entered Stream.
        //     Also performs error checking if the property QueryInstrumentStatus is set to
        //     true If you omit the timeout out or set it to null / -1 / 0, the method uses
        //     the current OPC timeout
        internal void QueryBinaryDataWithOpc(string query, Stream stream, int? timeoutMs = null)
        {
            long length = stream.Length;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (!Simulate)
            {
                _QueryBinaryDataWithOpc(query, exceptionIfNotBinData: true, timeoutMs);
            }
            else
            {
                byte[] array = new byte[11]
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                    10
                };
                stream.Write(array, 0, array.Length);
            }

            if (_logger.LoggingEnabled)
            {
                _logger.Log("QueryBinaryDataToStreamWithOpc", $"{query.Trim()} , received data length: {stream.Length - length} bytes");
            }
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers that can be returned as ASCII format
        //     or in binary format. The array is always returned as the most-universal double
        //     array.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal double[] QueryBinaryOrAsciiFloatArray(string query)
        {
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            double[] array;
            bool isBinData;
            if (!Simulate)
            {
                array = _QueryBinaryData(query, exceptionIfNotBinData: false, out isBinData).ToArrayOfFloatNumbers(isBinData, BinFloatNumbersFormat);
            }
            else
            {
                array = new double[11]
                {
                    0.1, 1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1,
                    10.2
                };
                isBinData = true;
            }

            if (_logger.LoggingEnabled)
            {
                _logger.Log("QueryBin/ASCIIfloatArray", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((double x) => x.ToDoubleString())));
            }

            return array;
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers that can be returned in ASCII format
        //     or in binary format. The array is always returned as single array. If the BinaryFloatNumbersFormat
        //     is Double8Bytes or Double8BytesSwapped, the method throws ArgumentException.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal float[] QueryBinaryOrAsciiSingleFloatArray(string query)
        {
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            float[] array;
            bool isBinData;
            if (!Simulate)
            {
                array = _QueryBinaryData(query, exceptionIfNotBinData: false, out isBinData).ToArrayOfSingleFloatNumbers(isBinData, BinFloatNumbersFormat);
            }
            else
            {
                array = new float[11]
                {
                    0.1f, 1.2f, 2.3f, 3.4f, 4.5f, 5.6f, 6.7f, 7.8f, 8.9f, 9.1f,
                    10.2f
                };
                isBinData = true;
            }

            if (_logger.LoggingEnabled)
            {
                _logger.Log("QueryBin/AsciiSingleFloatArray", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((float x) => x.ToSingleFloatString())));
            }

            return array;
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers with OPC sync. The numbers can be
        //     returned in ASCII format or in binary format. The array is returned as double
        //     array. If you omit the timeout out or set it to null / -1 / 0, the method uses
        //     the current OPC timeout
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal double[] QueryBinaryOrAsciiFloatArrayWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                double[] array;
                bool isBinData;
                if (!Simulate)
                {
                    array = _session.QueryBinaryDataWithOpc(query, exceptionIfNotBinData: false, out isBinData, timeoutMs).ToArrayOfFloatNumbers(isBinData, BinFloatNumbersFormat);
                    CheckStatus();
                    _session.QueryAndClearEsr();
                }
                else
                {
                    array = new double[11]
                    {
                        0.1, 1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1,
                        10.2
                    };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBin/AsciiFloatArrayWithOPC", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((double x) => x.ToDoubleString())));
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Queries an array of single floating-point numbers with OPC sync. The numbers
        //     can be returned in ASCII format or in binary format. The array is always returned
        //     as single float array. If the BinaryFloatNumbersFormat is Double8Bytes or Double8BytesSwapped,
        //     the method throws ArgumentException. If you omit the timeout out or set it to
        //     null / -1 / 0, the method uses the current OPC timeout.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal float[] QueryBinaryOrAsciiSingleFloatArrayWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                float[] array;
                bool isBinData;
                if (!Simulate)
                {
                    array = _session.QueryBinaryDataWithOpc(query, exceptionIfNotBinData: false, out isBinData, timeoutMs).ToArrayOfSingleFloatNumbers(isBinData, BinFloatNumbersFormat);
                    CheckStatus();
                    _session.QueryAndClearEsr();
                }
                else
                {
                    array = new float[11]
                    {
                        0.1f, 1.2f, 2.3f, 3.4f, 4.5f, 5.6f, 6.7f, 7.8f, 8.9f, 9.1f,
                        10.2f
                    };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBin/AsciiSingleFloatArrayWithOPC", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((float x) => x.ToSingleFloatString())));
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Same as QueryBinaryOrAsciiFloatArray, but suppresses an argument at the beginning
        //     ending with a comma. Only numeric scalar as suppressed is supported
        internal double[] QueryBinaryOrAsciiFloatArraySuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                double[] array;
                bool isBinData;
                if (!Simulate)
                {
                    if ((suppressed.Type != DataType.Integer || suppressed.Type != DataType.IntegerExt || suppressed.Type != DataType.Integer64 || suppressed.Type != DataType.Float || suppressed.Type != DataType.FloatExt) && suppressed.ArgumentIndex != 0)
                    {
                        throw new RsSmabException(ResourceName, $"Data type {suppressed} is not allowed as a suppression argument");
                    }

                    _session.Write(query);
                    string response = _session.ReadUpToChar(',', 20);
                    _linker.CutFromResponseString(suppressed, response, query);
                    array = _session.ReadBinaryData(exceptionIfNotBinData: false, out isBinData).ToArrayOfFloatNumbers(isBinData, BinFloatNumbersFormat);
                }
                else
                {
                    array = new double[11]
                    {
                        0.1, 1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1,
                        10.2
                    };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBin/ASCIIfloatArray", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((double x) => x.ToDoubleString())));
                }

                return array;
            }
        }

        //
        // Сводка:
        //     Queries an array of integer numbers that can be returned in ASCII format or in
        //     binary format. The array is always returned as the most-universal int32 array.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        internal int[] QueryBinaryOrAsciiIntegerArray(string query)
        {
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            int[] array;
            bool isBinData;
            if (!Simulate)
            {
                array = _QueryBinaryData(query, exceptionIfNotBinData: false, out isBinData).ToArrayOfIntegerNumbers(isBinData, BinIntegerNumbersFormat);
            }
            else
            {
                array = new int[10] { 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 };
                isBinData = true;
            }

            if (_logger.LoggingEnabled)
            {
                _logger.Log("QueryBin/AsciiIntegerArray", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((int x) => x.ToString())));
            }

            return array;
        }

        //
        // Сводка:
        //     Queries an array of integer numbers with OPC synchronization. The numbers can
        //     be returned in ASCII format or in binary format. The array is always returned
        //     as the most-universal int32 array. If you omit the timeout out or set it to null
        //     / -1 / 0, the method uses the current OPC timeout
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        internal int[] QueryBinaryOrAsciiIntegerArrayWithOpc(string query, int? timeoutMs = null)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                int[] array;
                bool isBinData;
                if (!Simulate)
                {
                    array = _session.QueryBinaryDataWithOpc(query, exceptionIfNotBinData: false, out isBinData, timeoutMs).ToArrayOfIntegerNumbers(isBinData, BinIntegerNumbersFormat);
                    CheckStatus();
                    _session.QueryAndClearEsr();
                }
                else
                {
                    array = new int[10] { 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBin/AsciiIntegerArrayWithOPC", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((int x) => x.ToString())));
                }

                CheckStatus();
                return array;
            }
        }

        //
        // Сводка:
        //     Same as QueryBinaryOrAsciiIntegerArray, but suppresses an argument at the beginning
        //     ending with a comma Only numeric scalar as suppressed is supported
        internal int[] QueryBinaryOrAsciiIntegerArraySuppressed(string query, ArgSuppressed suppressed)
        {
            lock (_locker)
            {
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                query = _ReplaceGlobalRepCaps(query);
                int[] array;
                bool isBinData;
                if (!Simulate)
                {
                    if ((suppressed.Type != DataType.Integer || suppressed.Type != DataType.IntegerExt || suppressed.Type != DataType.Integer64 || suppressed.Type != DataType.Float || suppressed.Type != DataType.FloatExt) && suppressed.ArgumentIndex != 0)
                    {
                        throw new RsSmabException(ResourceName, $"Data type {suppressed} is not allowed as a suppression argument");
                    }

                    _session.Write(query);
                    string response = _session.ReadUpToChar(',', 20);
                    _linker.CutFromResponseString(suppressed, response, query);
                    array = _session.ReadBinaryData(exceptionIfNotBinData: false, out isBinData).ToArrayOfIntegerNumbers(isBinData, BinIntegerNumbersFormat);
                }
                else
                {
                    array = new int[11]
                    {
                        1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                        11
                    };
                    isBinData = true;
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryBin/ASCIIintegerArray", query, array.Length, (isBinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((int x) => x.ToString())));
                }

                return array;
            }
        }

        //
        // Сводка:
        //     Sends *OPC? query and reads the result. Does not check the instrument status.
        internal bool QueryOpc()
        {
            lock (_locker)
            {
                bool flag = true;
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    flag = _session.QueryOpc();
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryOpc", flag.ToBooleanString());
                }

                return flag;
            }
        }

        //
        // Сводка:
        //     Sends *OPC? query and reads the result. Does not check the instrument status.
        //     The VISA timeout is defined only for this call.
        internal bool QueryOpc(int visaTimeout)
        {
            lock (_locker)
            {
                bool flag = true;
                if (_logger.LoggingEnabled)
                {
                    _logger.TimerStart();
                }

                if (!Simulate)
                {
                    flag = _session.QueryOpc(visaTimeout);
                }

                if (_logger.LoggingEnabled)
                {
                    _logger.Log("QueryOpc", flag.ToBooleanString());
                }

                return flag;
            }
        }

        //
        // Сводка:
        //     Writes the command to the instrument and invokes the WriteWitOpcHandler when
        //     the operation has completed Handler prototype: void EventHandler(object sender,
        //     InstrEventArgs args)
        internal void WriteStringWithOpcEvent(string command)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            command = _ReplaceGlobalRepCaps(command);
            if (Simulate)
            {
                InstrEventArgs e2 = new InstrEventArgs(ResourceName);
                LocalHandler(_session, e2);
                return;
            }

            _session.EventsHandler = LocalHandler;
            lock (_locker)
            {
                _session.WriteWithOpcEvent(command);
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = command;
                    e.StartTimestamp = contextTime;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                    }

                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("WriteStringWithOpcEvent", command.TrimEnd());
                    }

                    CheckStatus();
                }

                WriteWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Queries the instrument and invokes the QueryWithOpcHandler when the operation
        //     has completed The response is available in the InstrEventArgs.Data as string
        //     Handler prototype: void EventHandler(object sender, InstrEventArgs args)
        internal void QueryStringWithOpcEvent(string query)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (Simulate)
            {
                InstrEventArgs e2 = new InstrEventArgs(ResourceName)
                {
                    Data = "Simulating"
                };
                LocalHandler(_session, e2);
                return;
            }

            lock (_locker)
            {
                query = _ReplaceGlobalRepCaps(query);
                _session.EventsHandler = LocalHandler;
                _session.QueryStringWithOpcEvent(query);
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = query;
                    e.StartTimestamp = contextTime;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                    }

                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("QueryStringWithOpcEvent", query.TrimEnd());
                    }

                    CheckStatus();
                }

                QueryWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Queries the instrument and invokes the QueryWithOpcHandler when the operation
        //     has completed The response is available in the InstrEventArgs.Data as MemoryStream
        //     Handler prototype: void EventHandler(object sender, InstrEventArgs args)
        internal void QueryBinaryDataWithOpcEvent(string query)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (Simulate)
            {
                InstrEventArgs instrEventArgs = new InstrEventArgs(ResourceName);
                instrEventArgs.Data = new MemoryStream(new byte[11]
                {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
                    10
                });
                InstrEventArgs e2 = instrEventArgs;
                LocalHandler(_session, e2);
            }
            else
            {
                lock (_locker)
                {
                    query = _ReplaceGlobalRepCaps(query);
                    _session.EventsHandler = LocalHandler;
                    _session.QueryBinDataWithOpcEvent(query, exceptionIfNotBinData: true);
                }
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = query;
                    e.StartTimestamp = contextTime;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                    }

                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("QueryBinaryDataWithOpcEvent", $"{query.Trim()} , received data length: {((MemoryStream)e.Data).Length} bytes");
                    }

                    CheckStatus();
                }

                QueryWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of floating-point numbers with OPC sync. After the response
        //     arrives, the method invokes the QueryWithOpcHandler. The response is available
        //     in the InstrEventArgs.Data as double[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal void QueryBinaryOrAsciiFloatArrayWithOpcEvent(string query)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (Simulate)
            {
                InstrEventArgs instrEventArgs = new InstrEventArgs(ResourceName);
                instrEventArgs.Data = new double[11]
                {
                    0.1, 1.2, 2.3, 3.4, 4.5, 5.6, 6.7, 7.8, 8.9, 9.1,
                    10.2
                };
                InstrEventArgs e2 = instrEventArgs;
                LocalHandler(_session, e2);
            }
            else
            {
                lock (_locker)
                {
                    query = _ReplaceGlobalRepCaps(query);
                    _session.EventsHandler = LocalHandler;
                    _session.QueryBinDataWithOpcEvent(query, exceptionIfNotBinData: false);
                }
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = query;
                    e.StartTimestamp = contextTime;
                    double[] array;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                        array = ((MemoryStream)e.Data).ToArray().ToArrayOfFloatNumbers(e.BinData, BinFloatNumbersFormat);
                    }
                    else
                    {
                        array = (double[])e.Data;
                    }

                    e.Data = array;
                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("QueryBin/AsciiFloatArrayWithOpcEvent", query, array.Length, (e.BinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((double x) => x.ToDoubleString())));
                    }

                    CheckStatus();
                }

                QueryWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of single floating-point numbers with OPC sync. After the response
        //     arrives, the method invokes the QueryWithOpcHandler. The response is available
        //     in the InstrEventArgs.Data as single float[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryFloatNumbersFormat,
        //     usually float 32-bit (FORM REAL,32).
        internal void QueryBinaryOrAsciiSingleFloatArrayWithOpcEvent(string query)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (Simulate)
            {
                InstrEventArgs instrEventArgs = new InstrEventArgs(ResourceName);
                instrEventArgs.Data = new float[11]
                {
                    0.1f, 1.2f, 2.3f, 3.4f, 4.5f, 5.6f, 6.7f, 7.8f, 8.9f, 9.1f,
                    10.2f
                };
                InstrEventArgs e2 = instrEventArgs;
                LocalHandler(_session, e2);
            }
            else
            {
                lock (_locker)
                {
                    query = _ReplaceGlobalRepCaps(query);
                    _session.EventsHandler = LocalHandler;
                    _session.QueryBinDataWithOpcEvent(query, exceptionIfNotBinData: false);
                }
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = query;
                    e.StartTimestamp = contextTime;
                    float[] array;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                        array = ((MemoryStream)e.Data).ToArray().ToArrayOfSingleFloatNumbers(e.BinData, BinFloatNumbersFormat);
                    }
                    else
                    {
                        array = (float[])e.Data;
                    }

                    e.Data = array;
                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("QueryBin/AsciiSingleFloatArrayWithOpcEvent", query, array.Length, (e.BinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((float x) => x.ToSingleFloatString())));
                    }

                    CheckStatus();
                }

                QueryWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Queries an array of integer numbers with OPC sync. After the response arrives,
        //     the method invokes the QueryWithOpcHandler. The response is available in the
        //     InstrEventArgs.Data as int[] array Handler prototype: void EventHandler(object
        //     sender, InstrEventArgs args) The numbers can be returned in ASCII format or in
        //     binary format.
        //     - For ASCII format, the array numbers are decoded as comma-separated values.
        //     - For Binary Format, the numbers are decoded based on the property BinaryIntegerNumbersFormat,
        //     usually int 32-bit (FORM INT,32).
        internal void QueryBinaryOrAsciiIntegerArrayWithOpcEvent(string query)
        {
            DateTime contextTime = DateTime.Now;
            if (_logger.LoggingEnabled)
            {
                _logger.TimerStart();
            }

            if (Simulate)
            {
                InstrEventArgs instrEventArgs = new InstrEventArgs(ResourceName);
                instrEventArgs.Data = new int[10] { 1, 2, 3, 5, 10, 15, 20, 30, 50, 100 };
                InstrEventArgs e2 = instrEventArgs;
                LocalHandler(_session, e2);
            }
            else
            {
                lock (_locker)
                {
                    query = _ReplaceGlobalRepCaps(query);
                    _session.EventsHandler = LocalHandler;
                    _session.QueryBinDataWithOpcEvent(query, exceptionIfNotBinData: false);
                }
            }

            void LocalHandler(object sender, InstrEventArgs e)
            {
                lock (_locker)
                {
                    e.Context = query;
                    e.StartTimestamp = contextTime;
                    int[] array;
                    if (!Simulate)
                    {
                        _session.QueryAndClearEsr();
                        array = ((MemoryStream)e.Data).ToArray().ToArrayOfIntegerNumbers(e.BinData, BinIntegerNumbersFormat);
                    }
                    else
                    {
                        array = (int[])e.Data;
                    }

                    e.Data = array;
                    if (_logger.LoggingEnabled)
                    {
                        _logger.Log("QueryBin/QueryBinaryOrAsciiIntegerArrayWithOpcEvent", query, array.Length, (e.BinData ? "(in Binary format): " : "(in ASCII format): ") + string.Join(",", array.Select((int x) => x.ToString())));
                    }

                    CheckStatus();
                }

                QueryWithOpcHandler?.Invoke(this, e);
            }
        }

        //
        // Сводка:
        //     Installs a new srq handler invoked if ANY of the stbMask bits in the STB register
        //     is fulfilled
        internal void InstallSrqHandler(EventHandler<InstrEventArgs> handler, StatusByte stbMask)
        {
            _session.InstallUserSrqHandler(handler, stbMask, enableEvent: true);
        }

        //
        // Сводка:
        //     Uninstalls the srq handler
        internal void UninstallSrqHandler(StatusByte stbMask)
        {
            _session.UninstallUserSrqHandler(stbMask, disable: true);
        }

        //
        // Сводка:
        //     Add new StreamWriter listener
        internal void AddLogger(Stream sw)
        {
            _logger.Add(sw);
        }

        //
        // Сводка:
        //     Remove StreamWriter listener
        internal void RemoveLogger(Stream sw)
        {
            _logger.Remove(sw);
        }

        //
        // Сводка:
        //     Writes string message to log
        internal void WriteStringToLog(string logMessage)
        {
            _logger.Log(string.Empty, logMessage);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _session?.Dispose();
        }
    }
}
