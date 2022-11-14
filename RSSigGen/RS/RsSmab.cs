using System;
using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab : IDisposable
    {
        private readonly Core _core;

        private readonly CommandsGroup _grpBase;

        private const string DriverOptions = "SupportedInstrModels = SMA/SMAB/SMCV/SMB, SupportedIdnPatterns = SMA/SMCV/SMB, SimulationIdnString = 'Rohde&Schwarz,SMA100B,100001,4.70.300.0036'";

        private const string DriverSourceInfo = "Generated with the InstrumentDriverGenerator Version 3.0.0";

        //
        // Сводка:
        //     Custom Driver Property Utilities
        public RsSmab_Utilities Utilities;

        private RsSmab_Calculate _calculate;

        private RsSmab_Calibration _calibration;

        private RsSmab_Csynthesis _csynthesis;

        private RsSmab_Device _device;

        private RsSmab_Diagnostic _diagnostic;

        private RsSmab_Display _display;

        private RsSmab_Format _format;

        private RsSmab_HardCopy _hardCopy;

        private RsSmab_Initiate _initiate;

        private RsSmab_Kboard _kboard;

        private RsSmab_Memory _memory;

        private RsSmab_MassMemory _massMemory;

        private RsSmab_Output _output;

        private RsSmab_Read _read;

        private RsSmab_Sense _sense;

        private RsSmab_Slist _slist;

        private RsSmab_Source _source;

        private RsSmab_Status _status;

        private RsSmab_Sweep _sweep;

        private RsSmab_System _system;

        private RsSmab_Test _test;

        private RsSmab_Trace _trace;

        private RsSmab_Trigger _trigger;

        private RsSmab_Unit _unit;

        //
        // Сводка:
        //     Session handle to give over to a constructor of another driver. Use that in case
        //     you want to reuse the existing VISA session with another driver
        public byte[] Session => _core.IO.Session;

        //
        // Сводка:
        //     Global Repeated capability HwInstance Default value after init: HwInstanceRepCap.InstA
        public HwInstanceRepCap RepCapHwInstance
        {
            get
            {
                return (HwInstanceRepCap)_core.IO.GetGlobalRepCapValue("<HwInstance>");
            }
            set
            {
                _core.IO.SetGlobalRepCapValue("<HwInstance>", value);
            }
        }

        //
        // Сводка:
        //     Calculate commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_Calculate Calculate => _calculate ?? (_calculate = new RsSmab_Calculate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Calibration commands group
        //     Sub-classes count: 12
        //     Commands count: 2
        //     Total commands count: 40
        public RsSmab_Calibration Calibration => _calibration ?? (_calibration = new RsSmab_Calibration(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Csynthesis commands group
        //     Sub-classes count: 4
        //     Commands count: 3
        //     Total commands count: 13
        public RsSmab_Csynthesis Csynthesis => _csynthesis ?? (_csynthesis = new RsSmab_Csynthesis(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_Device Device => _device ?? (_device = new RsSmab_Device(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Diagnostic commands group
        //     Sub-classes count: 7
        //     Commands count: 0
        //     Total commands count: 20
        public RsSmab_Diagnostic Diagnostic => _diagnostic ?? (_diagnostic = new RsSmab_Diagnostic(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 6
        //     Commands count: 4
        //     Total commands count: 19
        public RsSmab_Display Display => _display ?? (_display = new RsSmab_Display(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Format commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Format Format => _format ?? (_format = new RsSmab_Format(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HardCopy commands group
        //     Sub-classes count: 4
        //     Commands count: 2
        //     Total commands count: 17
        public RsSmab_HardCopy HardCopy => _hardCopy ?? (_hardCopy = new RsSmab_HardCopy(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Initiate commands group
        //     Sub-classes count: 5
        //     Commands count: 0
        //     Total commands count: 5
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Initiate Initiate => _initiate ?? (_initiate = new RsSmab_Initiate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Kboard commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Kboard Kboard => _kboard ?? (_kboard = new RsSmab_Kboard(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Memory commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Memory Memory => _memory ?? (_memory = new RsSmab_Memory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     MassMemory commands group
        //     Sub-classes count: 4
        //     Commands count: 8
        //     Total commands count: 14
        public RsSmab_MassMemory MassMemory => _massMemory ?? (_massMemory = new RsSmab_MassMemory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Output commands group
        //     Sub-classes count: 7
        //     Commands count: 2
        //     Total commands count: 12
        public RsSmab_Output Output => _output ?? (_output = new RsSmab_Output(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Read commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Read Read => _read ?? (_read = new RsSmab_Read(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sense commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 120
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Sense Sense => _sense ?? (_sense = new RsSmab_Sense(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Slist commands group
        //     Sub-classes count: 4
        //     Commands count: 2
        //     Total commands count: 9
        public RsSmab_Slist Slist => _slist ?? (_slist = new RsSmab_Slist(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 29
        //     Commands count: 1
        //     Total commands count: 499
        public RsSmab_Source Source => _source ?? (_source = new RsSmab_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Status commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 22
        public RsSmab_Status Status => _status ?? (_status = new RsSmab_Status(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Sweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     System commands group
        //     Sub-classes count: 35
        //     Commands count: 29
        //     Total commands count: 184
        public RsSmab_System System => _system ?? (_system = new RsSmab_System(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Test commands group
        //     Sub-classes count: 7
        //     Commands count: 3
        //     Total commands count: 14
        public RsSmab_Test Test => _test ?? (_test = new RsSmab_Test(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trace commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 55
        //     Repeated Capability: TraceRepCap, default value after init: TraceRepCap.Nr1
        public RsSmab_Trace Trace => _trace ?? (_trace = new RsSmab_Trace(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 6
        //     Commands count: 0
        //     Total commands count: 14
        //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
        public RsSmab_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Trigger(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Unit commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Unit Unit => _unit ?? (_unit = new RsSmab_Unit(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Driver constructor with all parameters
        //
        // Параметры:
        //   resourceName:
        //     VISA resource to open the instrument
        //
        //   idQuery:
        //     Check Identification query and throw an exception if the instrument does not
        //     fit the supported instruments
        //
        //   resetDevice:
        //     Perform a reset
        //
        //   optionString:
        //     Additional options, comma-separated tokens. Examples:
        //     'Simulate = True' - starts the session in simulation mode. Default: False
        //     'PreferRsVisa = True' - selects RohdeSchwarz Visa if present. Otherwise selects
        //     default VISA. Default: False
        //     'QueryInstrumentStatus = False' - same as driver.utilities.instrument_status_checking
        //     = False. Default: True
        //     'WriteDelay = 20, ReadDelay = 5' - Introduces delay of 20ms before each write
        //     and 5ms before each read. Default: 0ms for both
        //     'OpcWaitMode = OpcQuery' - mode for all the opc-synchronised write/reads. Other
        //     modes: ServiceRequest, StbPolling, StbPollingSlow, StbPollingSuperSlow. Default:
        //     StbPolling
        //     'AddTermCharToWriteBinData = True' - Adds one additional LF to the end of the
        //     binary data (some instruments require that). Default: False
        //     'AssureWriteWithLf = True' - Makes sure each command/query is terminated with
        //     linefeed character. Default: Interface dependent
        //     'IoSegmentSize = 10E3' - Maximum size of one write/read segment. If transferred
        //     data is bigger, it is split to more segments. Default: 1E6 bytes
        //     'OpcTimeout = 10000' - same as driver.utilities.opc_timeout = 10000. Default:
        //     30000ms
        //     'VisaTimeout = 5000' - same as driver.utilities.visa_timeout = 5000. Default:
        //     10000ms
        //     'ViClearExeMode = 255' - Binary combination where 1 means performing viClear()
        //     on a certain interface as the very first command in init
        //     'OpcQueryAfterWrite = True' - same as driver.utilities.opc_query_after_write
        //     = True. Default: False
        public RsSmab(string resourceName, bool idQuery, bool resetDevice, string optionString)
        {
            _core = new Core(resourceName, idQuery, resetDevice, "SupportedInstrModels = SMA/SMAB/SMCV/SMB, SupportedIdnPatterns = SMA/SMCV/SMB, SimulationIdnString = 'Rohde&Schwarz,SMA100B,100001,4.70.300.0036'", optionString);
            _core.DriverVersion = new Version("4.70.300");
            _core.Owner = this;
            _grpBase = new CommandsGroup("ROOT", _core, null);
            _AddAllGlobalRepCaps();
            _CustomPropertiesInit();
            Utilities.DefaultInstrumentSetup();
        }

        //
        // Сводка:
        //     Opens a new session with the given 'resourceName' Checks the *IDN? response,
        //     but does not perform Reset
        //
        // Параметры:
        //   resourceName:
        //     VISA resource to open the instrument
        public RsSmab(string resourceName)
            : this(resourceName, idQuery: true, resetDevice: false, "")
        {
        }

        //
        // Сводка:
        //     Opens a new session with the given 'resourceName' with the option to check the
        //     IDN string and reset the instrument
        //
        // Параметры:
        //   resourceName:
        //     VISA resource to open the instrument
        //
        //   idQuery:
        //     Check Identification query and throw an exception if the instrument does not
        //     fit the supported instruments
        //
        //   resetDevice:
        //     Perform a reset
        public RsSmab(string resourceName, bool idQuery, bool resetDevice)
            : this(resourceName, idQuery, resetDevice, "")
        {
        }

        //
        // Сводка:
        //     Creates a new driver object with using the existing session from another driver
        //     Does not check the *IDN? response, and does not perform Reset
        //
        // Параметры:
        //   directSession:
        //     If not null, a new session will not be opened, but the directSession will be
        //     reused
        public RsSmab(byte[] directSession)
        {
            _core = new Core(directSession, "SupportedInstrModels = SMA/SMAB/SMCV, SupportedIdnPatterns = SMA/SMCV, SimulationIdnString = 'Rohde&Schwarz,SMA100B,100001,4.70.300.0036'");
            _core.DriverVersion = new Version("4.70.300");
            _core.Owner = this;
            _grpBase = new CommandsGroup("ROOT", _core, null);
            _AddAllGlobalRepCaps();
            _CustomPropertiesInit();
            Utilities.DefaultInstrumentSetup();
        }

        //
        // Сводка:
        //     Returns all the resource names fitting the entered expression
        public static IEnumerable<string> FindResources(string expression, bool vxi11, bool lxi, string plugin)
        {
            VisaPlugin num = VisaC.StringToPlugin(plugin);
            if (num == VisaPlugin.Unknown)
            {
                throw new RsSmabException(expression, "Visa Plugin '" + plugin + "' is invalid.");
            }

            VisaC visaC = new VisaC(num);
            VisaResourceManager visaResourceManager = new VisaResourceManager(expression, visaC);
            visaResourceManager.Open();
            try
            {
                IEnumerable<string> result = visaResourceManager.FindResources(expression, vxi11, lxi);
                visaResourceManager.Close();
                return result;
            }
            catch (VisaException ex)
            {
                visaResourceManager.Close();
                throw new RsSmabException("", ex.Message);
            }
        }

        //
        // Сводка:
        //     Returns all the resources fitting the expression for the default plugin
        public static IEnumerable<string> FindResources(string expression, bool vxi11, bool lxi)
        {
            return FindResources(expression, vxi11, lxi, null);
        }

        //
        // Сводка:
        //     Returns all the resources ('?*') available for the default plugin
        public static IEnumerable<string> FindResources(bool vxi11, bool lxi)
        {
            return FindResources("?*", vxi11, lxi, null);
        }

        //
        // Сводка:
        //     Returns all the resources ('?*') available for the default plugin
        public static IEnumerable<string> FindResources()
        {
            return FindResources("?*", vxi11: false, lxi: false, null);
        }

        //
        // Сводка:
        //     Returns all the resources fitting the expression for the default plugin, no VXI-11
        //     or LXI
        public static IEnumerable<string> FindResources(string expression)
        {
            return FindResources(expression, vxi11: false, lxi: false, null);
        }

        //
        // Сводка:
        //     Disposing of the driver object. Also closes the connection to the instrument
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        //
        // Сводка:
        //     Disposing of the driver object. Also closes the connection to the instrument
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _core.Dispose();
            }
        }

        //
        // Сводка:
        //     Creates a deep copy of the RsSmab object Also copies: - All the existing Global
        //     repeated capability values - All the default group repeated capabilities setting
        //     After cloning, you can set all the repeated capabilities settings independentely
        //     from the original group. Does not check the *IDN? response, and does not perform
        //     Reset Calling Dispose on the new object does not close the original VISA session
        public RsSmab Clone()
        {
            RsSmab rsSmab = new RsSmab(Session);
            _grpBase.SynchroniseRepCaps(rsSmab);
            rsSmab.RepCapHwInstance = RepCapHwInstance;
            return rsSmab;
        }

        //
        // Сводка:
        //     Sets all the Group and Global RepCaps to their initial values
        public void RestoreAllRepCapsToDefault()
        {
            _grpBase.RestoreRepCaps();
            RepCapHwInstance = HwInstanceRepCap.InstA;
        }

        private void _AddAllGlobalRepCaps()
        {
            _core.IO.AddGlobalRepCap("<HwInstance>", new RepeatedCapability(typeof(HwInstanceRepCap), "ROOT", "RepCapHwInstance", HwInstanceRepCap.InstA));
        }

        private void _CustomPropertiesInit()
        {
            Utilities = new RsSmab_Utilities(_core);
        }
    }
}
