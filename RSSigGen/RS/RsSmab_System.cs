using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System commands group definition
    //     Sub-classes count: 35
    //     Commands count: 29
    //     Total commands count: 184
    public class RsSmab_System
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Beeper _beeper;

        private RsSmab_System_Bios _bios;

        private RsSmab_System_Communicate _communicate;

        private RsSmab_System_Date _date;

        private RsSmab_System_Device _device;

        private RsSmab_System_Dexchange _dexchange;

        private RsSmab_System_DeviceFootprint _deviceFootprint;

        private RsSmab_System_Error _error;

        private RsSmab_System_ExtDevices _extDevices;

        private RsSmab_System_Files _files;

        private RsSmab_System_FpFpga _fpFpga;

        private RsSmab_System_Fpreset _fpreset;

        private RsSmab_System_Generic _generic;

        private RsSmab_System_Help _help;

        private RsSmab_System_Identification _identification;

        private RsSmab_System_Information _information;

        private RsSmab_System_Linux _linux;

        private RsSmab_System_Lock _lock;

        private RsSmab_System_MassMemory _massMemory;

        private RsSmab_System_Ntp _ntp;

        private RsSmab_System_Package _package;

        private RsSmab_System_PciFpga _pciFpga;

        private RsSmab_System_Profiling _profiling;

        private RsSmab_System_Protect _protect;

        private RsSmab_System_Reboot _reboot;

        private RsSmab_System_Restart _restart;

        private RsSmab_System_Security _security;

        private RsSmab_System_Shutdown _shutdown;

        private RsSmab_System_Specification _specification;

        private RsSmab_System_SrData _srData;

        private RsSmab_System_Srexec _srexec;

        private RsSmab_System_Srtime _srtime;

        private RsSmab_System_Startup _startup;

        private RsSmab_System_Time _time;

        private RsSmab_System_Undo _undo;

        //
        // Сводка:
        //     Beeper commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Beeper Beeper => _beeper ?? (_beeper = new RsSmab_System_Beeper(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Bios commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Bios Bios => _bios ?? (_bios = new RsSmab_System_Bios(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Communicate commands group
        //     Sub-classes count: 7
        //     Commands count: 0
        //     Total commands count: 23
        public RsSmab_System_Communicate Communicate => _communicate ?? (_communicate = new RsSmab_System_Communicate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Date commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_System_Date Date => _date ?? (_date = new RsSmab_System_Date(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Device Device => _device ?? (_device = new RsSmab_System_Device(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dexchange commands group
        //     Sub-classes count: 3
        //     Commands count: 5
        //     Total commands count: 12
        public RsSmab_System_Dexchange Dexchange => _dexchange ?? (_dexchange = new RsSmab_System_Dexchange(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     DeviceFootprint commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_System_DeviceFootprint DeviceFootprint => _deviceFootprint ?? (_deviceFootprint = new RsSmab_System_DeviceFootprint(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Error commands group
        //     Sub-classes count: 2
        //     Commands count: 3
        //     Total commands count: 7
        public RsSmab_System_Error Error => _error ?? (_error = new RsSmab_System_Error(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     ExtDevices commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_System_ExtDevices ExtDevices => _extDevices ?? (_extDevices = new RsSmab_System_ExtDevices(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Files commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Files Files => _files ?? (_files = new RsSmab_System_Files(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     FpFpga commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_FpFpga FpFpga => _fpFpga ?? (_fpFpga = new RsSmab_System_FpFpga(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Fpreset commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Fpreset Fpreset => _fpreset ?? (_fpreset = new RsSmab_System_Fpreset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Generic commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Generic Generic => _generic ?? (_generic = new RsSmab_System_Generic(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Help commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_System_Help Help => _help ?? (_help = new RsSmab_System_Help(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Identification commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Identification Identification => _identification ?? (_identification = new RsSmab_System_Identification(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Information commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Information Information => _information ?? (_information = new RsSmab_System_Information(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Linux commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Linux Linux => _linux ?? (_linux = new RsSmab_System_Linux(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Lock commands group
        //     Sub-classes count: 5
        //     Commands count: 1
        //     Total commands count: 10
        public RsSmab_System_Lock Lock => _lock ?? (_lock = new RsSmab_System_Lock(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     MassMemory commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_System_MassMemory MassMemory => _massMemory ?? (_massMemory = new RsSmab_System_MassMemory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ntp commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Ntp Ntp => _ntp ?? (_ntp = new RsSmab_System_Ntp(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Package commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_System_Package Package => _package ?? (_package = new RsSmab_System_Package(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     PciFpga commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_System_PciFpga PciFpga => _pciFpga ?? (_pciFpga = new RsSmab_System_PciFpga(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Profiling commands group
        //     Sub-classes count: 6
        //     Commands count: 1
        //     Total commands count: 18
        public RsSmab_System_Profiling Profiling => _profiling ?? (_profiling = new RsSmab_System_Profiling(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Protect commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        //     Repeated Capability: LevelRepCap, default value after init: LevelRepCap.Nr1
        public RsSmab_System_Protect Protect => _protect ?? (_protect = new RsSmab_System_Protect(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Reboot commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Reboot Reboot => _reboot ?? (_reboot = new RsSmab_System_Reboot(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Restart commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Restart Restart => _restart ?? (_restart = new RsSmab_System_Restart(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Security commands group
        //     Sub-classes count: 6
        //     Commands count: 1
        //     Total commands count: 17
        public RsSmab_System_Security Security => _security ?? (_security = new RsSmab_System_Security(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Shutdown commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Shutdown Shutdown => _shutdown ?? (_shutdown = new RsSmab_System_Shutdown(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Specification commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_System_Specification Specification => _specification ?? (_specification = new RsSmab_System_Specification(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SrData commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_SrData SrData => _srData ?? (_srData = new RsSmab_System_SrData(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Srexec commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Srexec Srexec => _srexec ?? (_srexec = new RsSmab_System_Srexec(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Srtime commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_System_Srtime Srtime => _srtime ?? (_srtime = new RsSmab_System_Srtime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Startup commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Startup Startup => _startup ?? (_startup = new RsSmab_System_Startup(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Time commands group
        //     Sub-classes count: 3
        //     Commands count: 3
        //     Total commands count: 11
        public RsSmab_System_Time Time => _time ?? (_time = new RsSmab_System_Time(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Undo commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 5
        public RsSmab_System_Undo Undo => _undo ?? (_undo = new RsSmab_System_Undo(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:CRASh
        //     No additional help available
        public double Crash
        {
            set
            {
                _grpBase.IO.Write("SYSTem:CRASh " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SYSTem:DFPR
        //     Queries the device footprint of the instrument. The retrieved information is
        //     in machine-readable form suitable for automatic further processing.
        //     deviceFootprint: string Information on the instrument type, device identification
        //     and details on the installed FW version, hardware and software options.
        public string Dfpr => _grpBase.IO.QueryString("SYSTem:DFPR?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:DID
        //     No additional help available
        public string Did => _grpBase.IO.QueryString("SYSTem:DID?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:DLOCk
        //     Disables the manual operation via the display, including the front panel keyboard
        //     of the instrument and the Local key.
        //     dispLockStat: 0| 1| OFF| ON
        public bool Dlock
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:DLOCk?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DLOCk " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SYSTem:IRESponse
        //     Defines the user defined identification string for *IDN. Note: While working
        //     in an emulation mode, the instrument's specific command set is disabled, i.e.
        //     the SCPI command method RsSmab.System.Iresponse is discarded.
        //     idnResponse: string
        public string Iresponse
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:IRESponse?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:IRESponse " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:KLOCk
        //     Disables the front panel keyboard of the instrument including the Local key.
        //     state: 0| 1| OFF| ON
        public bool Klock
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:KLOCk?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:KLOCk " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SYSTem:LANGuage
        //     Sets the remote control command set.
        //     language: string
        public string Language
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:LANGuage?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:LANGuage " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:ORESponse
        //     Defines the user defined response string for *OPT. Note: While working in an
        //     emulation mode, the instrument's specific command set is disabled, i.e. the SCPI
        //     command method RsSmab.System.Oresponse is discarded.
        //     oresponse: string
        public string Oresponse
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:ORESponse?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:ORESponse " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:OSYStem
        //     Queries the operating system of the instrument.
        //     operSystem: string
        public string Osystem => _grpBase.IO.QueryString("SYSTem:OSYStem?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:SIMulation
        //     No additional help available
        public bool Simulation => _grpBase.IO.QueryBoolean("SYSTem:SIMulation?");

        //
        // Сводка:
        //     SYSTem:SRCat
        //     No additional help available
        public List<string> SrCat => _grpBase.IO.QueryStringArray("SYSTem:SRCat?").ToStringList();

        //
        // Сводка:
        //     SYSTem:SREStore
        //     No additional help available
        public int Srestore
        {
            set
            {
                _grpBase.IO.Write($"SYSTem:SREStore {value}");
            }
        }

        //
        // Сводка:
        //     SYSTem:SRMode
        //     No additional help available
        public RecScpiCmdModeEnum SrMode
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:SRMode?").ToScpiEnum<RecScpiCmdModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SRMode " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:SRSel
        //     No additional help available
        public string SrSel
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:SRSel?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SRSel " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:SSAVe
        //     No additional help available
        public int Ssave
        {
            set
            {
                _grpBase.IO.Write($"SYSTem:SSAVe {value}");
            }
        }

        //
        // Сводка:
        //     SYSTem:TZONe
        //     No additional help available
        public string Tzone
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TZONe?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TZONe " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:ULOCk
        //     Locks or unlocks the user interface of the instrument.
        //     mode: ENABled| DONLy| DISabled| TOFF| VNConly ENABled Unlocks the display, the
        //     touchscreen and all controls for the manual operation. DONLy Locks the touchscreen
        //     and controls for the manual operation of the instrument. The display shows the
        //     current settings. VNConly Locks the touchscreen and controls for the manual operation,
        //     and enables remote operation over VNC. The display shows the current settings.
        //     TOFF Locks the touchscreen for the manual operation of the instrument. The display
        //     shows the current settings. DISabled Locks the display, the touchscreen and all
        //     controls for the manual operation.
        public DispKeybLockModeEnum Ulock
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:ULOCk?").ToScpiEnum<DispKeybLockModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:ULOCk " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:UPTime
        //     Queries the up time of the operating system.
        //     upTime: "ddd.hh:mm:ss"
        public string UpTime => _grpBase.IO.QueryString("SYSTem:UPTime?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:VERSion
        //     Queries the SCPI version the instrument's command set complies with.
        //     version: string
        public string Version => _grpBase.IO.QueryString("SYSTem:VERSion?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:WAIT
        //     Delays the execution of the subsequent remote command by the specified time.
        //     This function is useful, for example to execute an SCPI sequence automatically
        //     but with a defined time delay between some commands. See "How to Assign Actions
        //     to the [★ (User) ] Key".
        //     TimeMs: integer Wait time in ms Range: 0 to 10000
        public int Wait
        {
            set
            {
                _grpBase.IO.Write($"SYSTem:WAIT {value}");
            }
        }

        internal RsSmab_System(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("System", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System Clone()
        {
            RsSmab_System rsSmab_System = new RsSmab_System(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System);
            return rsSmab_System;
        }

        //
        // Сводка:
        //     SYSTem:IMPort
        //     No additional help available
        public void Import(string filename)
        {
            _grpBase.IO.Write("SYSTem:IMPort " + filename.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:PRESet
        //     Table Header: Triggers an instrument reset. It has the same effect as: - The
        //     [Preset] key. However, the command does not close open GUI dialogs like the key
        //     does., - The *RST command For an overview of the settings affected by the preset
        //     function, see Table "Key parameters affected by preset and factory preset"
        //
        // Параметры:
        //   pseudoString:
        //     No help available
        public void Preset(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:PRESet " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:PRESet:ALL
        //     No additional help available
        public void PresetAll(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:PRESet:ALL " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:PRESet:BASE
        //     No additional help available
        public void PresetBase(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:PRESet:BASE " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:RCL
        //     Loads a file with previously saved R&S SMA100B settings. Loads the selected file
        //     with previously saved R&S SMA100B settings from the default or the specified
        //     directory. Loaded are files with extension *.savrcltxt.
        //
        // Параметры:
        //   pathName:
        //     string
        public void Recall(string pathName)
        {
            _grpBase.IO.Write("SYSTem:RCL " + pathName.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:RESet
        //     No additional help available
        public void Reset(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:RESet " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:RESet:ALL
        //     No additional help available
        public void ResetAll(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:RESet:ALL " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:RESet:BASE
        //     No additional help available
        public void ResetBase(string pseudoString)
        {
            _grpBase.IO.Write("SYSTem:RESet:BASE " + pseudoString.EncloseByQuotes());
        }

        //
        // Сводка:
        //     SYSTem:SAV
        //     Saves the current R&S SMA100B settings into a file with defined filename and
        //     into a specified directory. The file extension (*.savrcltxt) is assigned automatically.
        //
        // Параметры:
        //   pathName:
        //     string
        public void Save(string pathName)
        {
            _grpBase.IO.Write("SYSTem:SAV " + pathName.EncloseByQuotes());
        }
    }
}
