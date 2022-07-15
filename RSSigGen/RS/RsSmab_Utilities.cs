using System;
using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Utilities
    {
        private readonly Core _core;

        //
        // Сводка:
        //     All the binary data I/O members
        public BinaryGroup Binary { get; private set; }

        //
        // Сводка:
        //     All the event-related members
        public EventsGroup Events { get; private set; }

        //
        // Сводка:
        //     All the file-transfer related members
        public FileGroup File { get; private set; }

        //
        // Сводка:
        //     All the driver and instrument identification members
        public IdnGroup Identification { get; private set; }

        //
        // Сводка:
        //     All the logging members
        public LoggingGroup Logging { get; private set; }

        //
        // Сводка:
        //     Sets / Gets Instrument Status Checking. When true (default is true), all the
        //     driver methods and properties are sending "SYST:ERR?" at the end to immediately
        //     react on error that might have occurred. We recommend to keep the state checking
        //     ON all the time. Switch it OFF only in rare cases when you require maximum speed.
        public bool InstrumentStatusChecking
        {
            get
            {
                return _core.IO.QueryInstrumentStatus;
            }
            set
            {
                _core.IO.QueryInstrumentStatus = value;
            }
        }

        //
        // Сводка:
        //     Sets / Gets Instrument *OPC? query sending after each settings. When true, (default
        //     is false) the driver sends *OPC? every time a write command is performed. For
        //     queries, the *OPC? is skipped. Use this if you want to make sure your sequence
        //     is performed command-after-command.
        public bool OpcQueryAfterEachSetting
        {
            get
            {
                return _core.IO.OpcQueryAfterEachSetting;
            }
            set
            {
                _core.IO.OpcQueryAfterEachSetting = value;
            }
        }

        //
        // Сводка:
        //     Timeout in milliseconds for all the operations that use OPC synchronization
        public int OpcTimeout
        {
            get
            {
                return _core.IO.OpcTimeoutMs;
            }
            set
            {
                _core.IO.OpcTimeoutMs = value;
            }
        }

        //
        // Сводка:
        //     VISA session timeout in milliseconds
        public int VisaTimeout
        {
            get
            {
                return _core.IO.VisaTimeoutMs;
            }
            set
            {
                _core.IO.VisaTimeoutMs = value;
            }
        }

        //
        // Сводка:
        //     Sets/Gets size of one transferred data segment
        public int IoSegmentSize
        {
            get
            {
                return _core.IO.IoSegmentSize;
            }
            set
            {
                _core.IO.IoSegmentSize = value;
            }
        }

        //
        // Сводка:
        //     Utility functions common for all the instrument drivers
        internal RsSmab_Utilities(Core core)
        {
            _core = core;
            _InitInterfaces();
        }

        private void _InitInterfaces()
        {
            Binary = new BinaryGroup(_core);
            Events = new EventsGroup(_core);
            File = new FileGroup(_core);
            Identification = new IdnGroup(_core);
            Logging = new LoggingGroup(_core);
        }

        //
        // Сводка:
        //     SCPI Command: *OPC? Queries the instrument's OPC bit and hence it waits until
        //     the instrument reports operation complete.
        //     Exceptions: VisaException, VisaTimeoutException
        public bool QueryOpc()
        {
            return _core.IO.QueryOpc();
        }

        //
        // Сводка:
        //     SCPI Command: *OPC? Queries the instrument's OPC bit and hence it waits until
        //     the instrument reports operation complete. You can define the visaTimeout which
        //     is set only for this call.
        //     Exceptions: VisaException, VisaTimeoutException
        public bool QueryOpc(int visaTimeout)
        {
            return _core.IO.QueryOpc(visaTimeout);
        }

        //
        // Сводка:
        //     Clears instrument's status system, the session's I/O buffers and the instrument's
        //     error queue.
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException
        public void ClearStatus()
        {
            _core.IO.ClearStatus();
        }

        //
        // Сводка:
        //     SCPI command: SYSTem:ERRor? Queries and deletes the oldest error in the instrument's
        //     error queue. Returns the oldest error that occurred. If no error is present,
        //     the method returns {code=0, msg='No Error'}
        //     Exceptions: VisaException, VisaTimeoutException
        public string QueryOldestError()
        {
            return _core.IO.QueryOldestError();
        }

        //
        // Сводка:
        //     SCPI command: SYSTem:ERRor? Queries and clears the errors from the instrument's
        //     error queue. The errors are ordered from the oldest ones to the newest one. The
        //     method calls the 'SYSTem:ERRor?' in a loop until the error queue is empty.
        //     Exceptions: VisaException, VisaTimeoutException
        public IEnumerable<string> QueryAllErrors()
        {
            return _core.IO.QueryErrorsAll();
        }

        //
        // Сводка:
        //     Throws InstrumentStatusException in case of an error in the instrument's error
        //     queue.
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public void CheckStatus()
        {
            _core.IO.CheckStatus(forceCheck: true);
        }

        //
        // Сводка:
        //     SCPI command: *RST Sends *RST command + calls the ClearStatus()
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public void Reset()
        {
            _core.IO.ClearStatus();
            _core.IO.Reset();
            DefaultInstrumentSetup();
        }

        //
        // Сводка:
        //     Custom steps performed at the init and at the Reset()
        public void DefaultInstrumentSetup()
        {
        }

        //
        // Сводка:
        //     SCPI command: *TST? Performs instrument's selftest and returns null if the selftest
        //     passed
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public int SelfTest()
        {
            return _core.IO.SelfTest();
        }

        //
        // Сводка:
        //     SCPI command: *TST? Performs instrument's selftest and returns null if the selftest
        //     passed You can define the custom timeout in milliseconds
        //     Exceptions: VisaException, VisaTimeoutException, RsSmabException, InstrumentStatusException
        public int SelfTest(int selftestTimeout)
        {
            return _core.IO.SelfTest(selftestTimeout);
        }

        //
        // Сводка:
        //     SCPI Command: *WAI Stops further commands processing until all commands sent
        //     before *WAI have been executed.
        //     Exceptions: VisaException, RsSmabException, InstrumentStatusException
        public void ProcessAllPreviousCommands()
        {
            _core.IO.Write("*WAI");
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as boolean
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public bool QueryBool(string query)
        {
            return _core.IO.QueryBoolean(query);
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as a boolean List.
        //     Boolean array is converted from the csv-response.
        public List<bool> QueryBooleanList(string query)
        {
            return _core.IO.QueryAsciiBooleanArray(query).ToList();
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as boolean
        //     If timeoutMs is null, -1 or 0, the current Opc Timeout is used
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public bool QueryBooleanWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryBooleanWithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as a boolean
        //     List. If timeoutMs is null, -1 or 0, the current Opc Timeout is used.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public List<bool> QueryBooleanListWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryStringWithOpc(query, timeoutMs).ToBooleanArray().ToList();
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as string The response
        //     is trimmed of any trailing TermChars and has no length limit.
        public string QueryString(string query)
        {
            return _core.IO.QueryString(query);
        }

        //
        // Сводка:
        //     Alias to the method QueryString(). Sends the query to the instrument and returns
        //     the response as string The response is trimmed of any trailing TermChars and
        //     has no length limit.
        public string Query(string query)
        {
            return _core.IO.QueryString(query);
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as string list of
        //     unlimited length. Each element is trimmed for paired quotes and trailing spaces.
        //     If the response is empty, the method returns 0-length List.
        public List<string> QueryStringList(string query)
        {
            return _core.IO.QueryStringArray(query).ToStringList();
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as string.
        //     The response is trimmed of any trailing TermChars and has no length limit. If
        //     timeoutMs is null, -1 or 0, the current Opc Timeout is used.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public string QueryStringWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryStringWithOpc(query, allowCheckStatus: true, timeoutMs);
        }

        //
        // Сводка:
        //     Alias to the method QueryStringWithOpc(). Sends the opc-synced query to the instrument
        //     and returns the response as string. The response is trimmed of any trailing TermChars
        //     and has no length limit. If timeoutMs is null, -1 or 0, the current Opc Timeout
        //     is used.
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public string QueryWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryStringWithOpc(query, allowCheckStatus: true, timeoutMs);
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as string
        //     list of unlimited length. Each element is trimmed for paired quotes and trailing
        //     spaces. If timeoutMs is null, -1 or 0, the current Opc Timeout is used. If the
        //     response is empty, the method returns 0-length List.
        public List<string> QueryStringListWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryStringArrayWithOpc(query, timeoutMs).ToStringList();
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as double
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public double QueryDouble(string query)
        {
            return _core.IO.QueryDouble(query);
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as double
        //     If timeoutMs is null, -1 or 0, the current Opc Timeout is used
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public double QueryDoubleWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryDoubleWithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Sends the query to the instrument and returns the response as integer
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public int QueryInteger(string query)
        {
            return _core.IO.QueryInt32(query);
        }

        //
        // Сводка:
        //     Sends the opc-synced query to the instrument and returns the response as integer
        //     If timeoutMs is null, -1 or 0, the current Opc Timeout is used
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public int QueryIntegerWithOpc(string query, int? timeoutMs = null)
        {
            return _core.IO.QueryInt32WithOpc(query, timeoutMs);
        }

        //
        // Сводка:
        //     Writes command to the instrument
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public void WriteString(string command)
        {
            _core.IO.Write(command);
        }

        //
        // Сводка:
        //     Alias to the method WriteString(). Writes command to the instrument
        //     Exceptions: VisaException, VisaTimeoutException, InstrumentStatusException
        public void Write(string command)
        {
            _core.IO.Write(command);
        }

        //
        // Сводка:
        //     Writes command to the instrument and wait for it to be executed If timeoutMs
        //     is null, -1 or 0, the current Opc Timeout is used
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public void WriteStringWithOpc(string command, int? timeoutMs = null)
        {
            _core.IO.WriteWithOpc(command, timeoutMs);
        }

        //
        // Сводка:
        //     Alias to the method WriteStringWithOpc(). Writes command to the instrument and
        //     wait for it to be executed If timeoutMs is null, -1 or 0, the current Opc Timeout
        //     is used
        //     Exceptions: VisaException, VisaTimeoutException, OperationTimeoutException, InstrumentStatusException
        public void WriteWithOpc(string command, int? timeoutMs = null)
        {
            _core.IO.WriteWithOpc(command, timeoutMs);
        }

        //
        // Сводка:
        //     Returns true, if the instrument has the entered option installed
        public bool HasOptionInstalled(string option)
        {
            return _core.IsOptionAvailable(option);
        }

        //
        // Сводка:
        //     Assigns new locking object. Use it to synchronise between multiple Instrument
        //     objects
        public void AssignLock(object locker)
        {
            if (locker == null)
            {
                throw new ArgumentException("locker");
            }

            _core.IO.AssignLock(locker);
        }

        //
        // Сводка:
        //     Returns locking object. Use it to synchronise between multiple Instrument objects
        public object GetLock()
        {
            return _core.IO.GetLock();
        }
    }
}
