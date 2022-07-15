using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep commands group definition
    //     Sub-classes count: 4
    //     Commands count: 4
    //     Total commands count: 95
    public class RsSmab_Sense_Power_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Frequency _frequency;

        private RsSmab_Sense_Power_Sweep_HardCopy _hardCopy;

        private RsSmab_Sense_Power_Sweep_Power _power;

        private RsSmab_Sense_Power_Sweep_Time _time;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 5
        //     Commands count: 4
        //     Total commands count: 19
        public RsSmab_Sense_Power_Sweep_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Sense_Power_Sweep_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HardCopy commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 24
        public RsSmab_Sense_Power_Sweep_HardCopy HardCopy => _hardCopy ?? (_hardCopy = new RsSmab_Sense_Power_Sweep_HardCopy(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 5
        //     Commands count: 4
        //     Total commands count: 18
        public RsSmab_Sense_Power_Sweep_Power Power => _power ?? (_power = new RsSmab_Sense_Power_Sweep_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Time commands group
        //     Sub-classes count: 5
        //     Commands count: 5
        //     Total commands count: 30
        public RsSmab_Sense_Power_Sweep_Time Time => _time ?? (_time = new RsSmab_Sense_Power_Sweep_Time(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:MODE
        //     Selects power versus frequency measurement (frequency response) , power vs power
        //     measurement (power sweep, AM/AM) or power vs. time measurement.
        //     mode: FREQuency| POWer| TIME
        public MeasRespModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:MODE?").ToScpiEnum<MeasRespModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:RMODe
        //     Selects single or continuous mode for power analysis (all measurement modes)
        //     .
        //     rmode: SINGle| CONTinuous
        public RepeatModeEnum Rmode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:RMODe?").ToScpiEnum<RepeatModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:RMODe " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep Clone()
        {
            RsSmab_Sense_Power_Sweep rsSmab_Sense_Power_Sweep = new RsSmab_Sense_Power_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep);
            return rsSmab_Sense_Power_Sweep;
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:ABORt
        //     Aborts the power analysis with NRP power sensors.
        //
        // Параметры:
        //   rfPowSensMeasRespMeasEvent:
        //     No help available
        public void Abort(bool rfPowSensMeasRespMeasEvent)
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:ABORt " + rfPowSensMeasRespMeasEvent.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:INITiate
        //     Starts the power analysis with NRP power sensor.
        //
        // Параметры:
        //   rfPowSensMeasRespMeasEvent:
        //     No help available
        public void Initiate(bool rfPowSensMeasRespMeasEvent)
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:INITiate " + rfPowSensMeasRespMeasEvent.ToBooleanString());
        }
    }
}
