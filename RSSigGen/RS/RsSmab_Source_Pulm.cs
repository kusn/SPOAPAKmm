using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm commands group definition
    //     Sub-classes count: 4
    //     Commands count: 10
    //     Total commands count: 46
    public class RsSmab_Source_Pulm
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Double _double;

        private RsSmab_Source_Pulm_Train _train;

        private RsSmab_Source_Pulm_Trigger _trigger;

        private RsSmab_Source_Pulm_Internal _internal;

        //
        // Сводка:
        //     Double commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Pulm_Double Double => _double ?? (_double = new RsSmab_Source_Pulm_Double(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Train commands group
        //     Sub-classes count: 5
        //     Commands count: 3
        //     Total commands count: 30
        public RsSmab_Source_Pulm_Train Train => _train ?? (_train = new RsSmab_Source_Pulm_Train(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_Pulm_Trigger(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Internal commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Pulm_Internal Internal => _internal ?? (_internal = new RsSmab_Source_Pulm_Internal(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:DELay
        //     Sets the pulse delay.
        //     delay: float
        public double Delay
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:DELay?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:DELay " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:IMPedance
        //     Sets the impedance for the external pulse trigger and pulse modulation input.
        //     impedance: G50| G10K
        public InpImpRfEnum Impedance
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:IMPedance?").ToScpiEnum<InpImpRfEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:IMPedance " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:MODE
        //     Selects the mode for the pulse modulation.
        //     mode: SINGle| DOUBle | PTRain SINGle Generates a single pulse. DOUBle Generates
        //     two pulses within one pulse period. PTRain Generates a user-defined pulse train.
        //     Specify the pulse sequence with the commands: PULM:TRAin:ONTime PULM:TRAin:OFFTime
        //     PULM:TRAin:REPetition
        public PulsModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:MODE?").ToScpiEnum<PulsModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:PERiod
        //     Sets the period of the generated pulse, that means the repetition frequency of
        //     the internally generated modulation signal.
        //     period: float The minimum value depends on the installed options R&S SMAB-K22
        //     or R&S SMAB-K23 Range: 20E-9 to 100
        public double Period
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:PERiod?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:PERiod " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:POLarity
        //     Sets the polarity of the externally applied modulation signal.
        //     polarity: NORMal| INVerted NORMal Suppresses the RF signal during the pulse pause.
        //     INVerted Suppresses the RF signal during the pulse.
        public NormalInvertedEnum Polarity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:POLarity?").ToScpiEnum<NormalInvertedEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:POLarity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:SOURce
        //     Selects between the internal (pulse generator) or an external pulse signal for
        //     the modulation.
        //     source: INTernal| EXTernal
        public SourceIntEnum Source
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:SOURce?").ToScpiEnum<SourceIntEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:SOURce " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:STATe
        //     Activates pulse modulation.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:PULM:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:THReshold
        //     Sets the threshold for the input signal at the [Pulse Ext] connector.
        //     threshold: float Range: 0 to 2, Unit: V
        public double Threshold
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:THReshold?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:THReshold " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TTYPe
        //     Sets the transition mode for the pulse signal.
        //     source: SMOothed| FAST SMOothed flattens the slew rate, resulting in longer rise/fall
        //     times. FAST enables fast transitions with shortest rise and fall times.
        public PulsTransTypeEnum Ttype
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TTYPe?").ToScpiEnum<PulsTransTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TTYPe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:WIDTh
        //     Sets the width of the generated pulse, that means the pulse length. It must be
        //     at least 20ns less than the set pulse period.
        //     width: float Range: 20E-9 to 100
        public double Width
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:WIDTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:WIDTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Pulm(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulm", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm Clone()
        {
            RsSmab_Source_Pulm rsSmab_Source_Pulm = new RsSmab_Source_Pulm(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm);
            return rsSmab_Source_Pulm;
        }
    }
}
