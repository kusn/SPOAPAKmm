using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Sweep_Frequency commands group definition
    //     Sub-classes count: 3
    //     Commands count: 7
    //     Total commands count: 12
    public class RsSmab_Source_LfOutput_Sweep_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Sweep_Frequency_Execute _execute;

        private RsSmab_Source_LfOutput_Sweep_Frequency_Mode _mode;

        private RsSmab_Source_LfOutput_Sweep_Frequency_Step _step;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Sweep_Frequency_Execute Execute => _execute ?? (_execute = new RsSmab_Source_LfOutput_Sweep_Frequency_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_LfOutput_Sweep_Frequency_Mode Mode => _mode ?? (_mode = new RsSmab_Source_LfOutput_Sweep_Frequency_Mode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_LfOutput_Sweep_Frequency_Step Step => _step ?? (_step = new RsSmab_Source_LfOutput_Sweep_Frequency_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:DWELl
        //     Sets the dwell time for each frequency step of the sweep.
        //     dwell: float Range: 0.001 to 100, Unit: s
        public double Dwell
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:DWELl?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:DWELl " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput:SWEep:[FREQuency]:LFSource
        //     No additional help available
        public LfSweepSourceEnum LfSource
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:LFOutput:SWEep:FREQuency:LFSource?").ToScpiEnum<LfSweepSourceEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:LFOutput:SWEep:FREQuency:LFSource " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:POINts
        //     Sets the number of steps in an LF sweep. For information on how the value is
        //     calculated and the interdependency with other parameters, see "Correlating Parameters
        //     in Sweep Mode"
        //     points: integer Range: 2 to POINts
        public int Points
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:POINts?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:LFOutput:SWEep:FREQuency:POINts {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:RETRace
        //     Activates that the signal changes to the start frequency value while it is waiting
        //     for the next trigger event. You can enable this feature, when you are working
        //     with sawtooth shapes in sweep mode "Single" or "External Single".
        //     state: 0| 1| OFF| ON
        public bool Retrace
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:RETRace?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:RETRace " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:RUNNing
        //     Queries the current status of the LF frequency sweep mode.
        //     state: 0| 1| OFF| ON
        public bool Running => _grpBase.IO.QueryBoolean("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:RUNNing?");

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:SHAPe
        //     Sets the cycle mode for a sweep sequence (shape) .
        //     shape: SAWTooth| TRIangle
        public SweCyclModeEnum Shape
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:SHAPe?").ToScpiEnum<SweCyclModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:SHAPe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:SPACing
        //     Selects linear or logarithmic sweep spacing.
        //     spacing: LINear| LOGarithmic
        public SpacingEnum Spacing
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:SPACing?").ToScpiEnum<SpacingEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:SPACing " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_LfOutput_Sweep_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Sweep_Frequency Clone()
        {
            RsSmab_Source_LfOutput_Sweep_Frequency rsSmab_Source_LfOutput_Sweep_Frequency = new RsSmab_Source_LfOutput_Sweep_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Sweep_Frequency);
            return rsSmab_Source_LfOutput_Sweep_Frequency;
        }
    }
}
