using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency commands group definition
    //     Sub-classes count: 5
    //     Commands count: 4
    //     Total commands count: 19
    public class RsSmab_Sense_Power_Sweep_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Frequency_Reference _reference;

        private RsSmab_Sense_Power_Sweep_Frequency_Spacing _spacing;

        private RsSmab_Sense_Power_Sweep_Frequency_Timing _timing;

        private RsSmab_Sense_Power_Sweep_Frequency_Yscale _yscale;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor _sensor;

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Frequency_Reference Reference => _reference ?? (_reference = new RsSmab_Sense_Power_Sweep_Frequency_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Spacing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Spacing Spacing => _spacing ?? (_spacing = new RsSmab_Sense_Power_Sweep_Frequency_Spacing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Timing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Timing Timing => _timing ?? (_timing = new RsSmab_Sense_Power_Sweep_Frequency_Timing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Yscale commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Frequency_Yscale Yscale => _yscale ?? (_yscale = new RsSmab_Sense_Power_Sweep_Frequency_Yscale(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Sense_Power_Sweep_Frequency_Sensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:RMODe
        //     Selects single or continuous mode for measurement mode frequency in power analysis.
        //     rmode: SINGle| CONTinuous
        public RepeatModeEnum Rmode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:FREQuency:RMODe?").ToScpiEnum<RepeatModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:RMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:STARt
        //     Sets the start frequency for the frequency mode.
        //     start: float Range: 0 to 1E12
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:FREQuency:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:STEPs
        //     Sets the number of measurement steps for the frequency mode.
        //     steps: integer Range: 10 to 1000
        public int Steps
        {
            get
            {
                return _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:FREQuency:STEPs?");
            }
            set
            {
                _grpBase.IO.Write($"SENSe:POWer:SWEep:FREQuency:STEPs {value}");
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:STOP
        //     Sets the stop frequency for the frequency mode.
        //     stop: float Range: 0 to 1E12
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:FREQuency:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Frequency Clone()
        {
            RsSmab_Sense_Power_Sweep_Frequency rsSmab_Sense_Power_Sweep_Frequency = new RsSmab_Sense_Power_Sweep_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Frequency);
            return rsSmab_Sense_Power_Sweep_Frequency;
        }
    }
}
