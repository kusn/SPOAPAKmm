using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Power commands group definition
    //     Sub-classes count: 4
    //     Commands count: 6
    //     Total commands count: 11
    public class RsSmab_Source_Sweep_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Power_Execute _execute;

        private RsSmab_Source_Sweep_Power_Mode _mode;

        private RsSmab_Source_Sweep_Power_Spacing _spacing;

        private RsSmab_Source_Sweep_Power_Step _step;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Power_Execute Execute => _execute ?? (_execute = new RsSmab_Source_Sweep_Power_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Sweep_Power_Mode Mode => _mode ?? (_mode = new RsSmab_Source_Sweep_Power_Mode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Spacing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Power_Spacing Spacing => _spacing ?? (_spacing = new RsSmab_Source_Sweep_Power_Spacing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Power_Step Step => _step ?? (_step = new RsSmab_Source_Sweep_Power_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:AMODe
        //     No additional help available
        public PowAttModeEnum Amode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:POWer:AMODe?").ToScpiEnum<PowAttModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:AMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:DWELl
        //     Sets the dwell time for a level sweep step.
        //     dwell: float Range: 0.001 to 100
        public double Dwell
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:POWer:DWELl?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:DWELl " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:POINts
        //     Sets the number of steps within the RF level sweep range. See "Correlating Parameters
        //     in Sweep Mode".
        //     points: integer Range: 2 to Max
        public int Points
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:SWEep:POWer:POINts?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:SWEep:POWer:POINts {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:RETRace
        //     Activates that the signal changes to the start frequency value while it is waiting
        //     for the next trigger event. You can enable this feature, when you are working
        //     with sawtooth shapes in sweep mode "Single" or "External Single".
        //     state: 0| 1| OFF| ON
        public bool Retrace
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:POWer:RETRace?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:RETRace " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:RUNNing
        //     Queries the current sweep state.
        //     state: 0| 1| OFF| ON
        public bool Running => _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:POWer:RUNNing?");

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:SHAPe
        //     Determines the waveform shape for a frequency sweep sequence.
        //     shape: SAWTooth| TRIangle
        public SweCyclModeEnum Shape
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:POWer:SHAPe?").ToScpiEnum<SweCyclModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:SHAPe " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep_Power Clone()
        {
            RsSmab_Source_Sweep_Power rsSmab_Source_Sweep_Power = new RsSmab_Source_Sweep_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep_Power);
            return rsSmab_Source_Sweep_Power;
        }
    }
}
