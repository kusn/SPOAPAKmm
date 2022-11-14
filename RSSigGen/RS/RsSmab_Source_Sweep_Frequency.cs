using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency commands group definition
    //     Sub-classes count: 4
    //     Commands count: 7
    //     Total commands count: 15
    public class RsSmab_Source_Sweep_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Frequency_Execute _execute;

        private RsSmab_Source_Sweep_Frequency_Marker _marker;

        private RsSmab_Source_Sweep_Frequency_Mode _mode;

        private RsSmab_Source_Sweep_Frequency_Step _step;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Frequency_Execute Execute => _execute ?? (_execute = new RsSmab_Source_Sweep_Frequency_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Marker commands group
        //     Sub-classes count: 2
        //     Commands count: 1
        //     Total commands count: 3
        //     Repeated Capability: MarkerRepCap, default value after init: MarkerRepCap.Nr0
        public RsSmab_Source_Sweep_Frequency_Marker Marker => _marker ?? (_marker = new RsSmab_Source_Sweep_Frequency_Marker(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Sweep_Frequency_Mode Mode => _mode ?? (_mode = new RsSmab_Source_Sweep_Frequency_Mode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Sweep_Frequency_Step Step => _step ?? (_step = new RsSmab_Source_Sweep_Frequency_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:DWELl
        //     Sets the dwell time for a frequency sweep step.
        //     dwell: float Range: 0.001 to 100
        public double Dwell
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:FREQuency:DWELl?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:DWELl " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:POINts
        //     Sets the number of steps within the RF frequency sweep range. See "Correlating
        //     Parameters in Sweep Mode". Two separate POINts values are used for linear or
        //     logarithmic sweep spacing (LIN | LOG) . The command always affects the currently
        //     set sweep spacing.
        //     points: integer Range: 2 to Max
        public int Points
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:SWEep:FREQuency:POINts?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:SWEep:FREQuency:POINts {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:RETRace
        //     Activates that the signal changes to the start frequency value while it is waiting
        //     for the next trigger event. You can enable this feature, when you are working
        //     with sawtooth shapes in sweep mode "Single" or "External Single".
        //     state: 0| 1| OFF| ON
        public bool Retrace
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:FREQuency:RETRace?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:RETRace " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:RUNNing
        //     Queries the current sweep state.
        //     state: 0| 1| OFF| ON
        public bool Running => _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:FREQuency:RUNNing?");

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:SHAPe
        //     Determines the waveform shape for a frequency sweep sequence.
        //     shape: SAWTooth| TRIangle
        public SweCyclModeEnum Shape
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:FREQuency:SHAPe?").ToScpiEnum<SweCyclModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:SHAPe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:SPACing
        //     Selects the mode for the calculation of the frequency intervals, with which the
        //     current frequency at each step is increased or decreased. The keyword [:FREQuency]
        //     can be omitted; then the command is SCPI-compliant.
        //     spacing: LINear| LOGarithmic LINear Sets a fixed frequency value as step width
        //     and adds it to the current frequency. The linear step width is entered in Hz,
        //     see [:​SOURcehw]:​SWEep[:​FREQuency]:​STEP[:​LINear]. LOGarithmic Sets a constant
        //     fraction of the current frequency as step width and adds it to the current frequency.
        //     The logarithmic step width is entered in %, see STEP:LOGarithmic.
        public SpacingEnum Spacing
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:FREQuency:SPACing?").ToScpiEnum<SpacingEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:SPACing " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:TIME
        //     Sets the duration of a frequency ramp sweep step.
        //     time: float Range: 0.01 to 100, Unit: s
        public double Time
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:FREQuency:TIME?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:TIME " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Sweep_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep_Frequency Clone()
        {
            RsSmab_Source_Sweep_Frequency rsSmab_Source_Sweep_Frequency = new RsSmab_Source_Sweep_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep_Frequency);
            return rsSmab_Source_Sweep_Frequency;
        }
    }
}
