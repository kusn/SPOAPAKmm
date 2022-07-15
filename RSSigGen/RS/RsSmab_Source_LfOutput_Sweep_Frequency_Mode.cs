using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Sweep_Frequency_Mode commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_LfOutput_Sweep_Frequency_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:MODE:ADVanced
        //     No additional help available
        public AutoManualModeEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:MODE:ADVanced?").ToScpiEnum<AutoManualModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:MODE:ADVanced " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:MODE
        //     Sets the cycle mode of the LF sweep.
        //     mode: AUTO| MANual| STEP AUTO Performs a complete sweep cycle from the start
        //     to the end value when a trigger event occurs. The dwell time determines the time
        //     period until the signal switches to the next step. MANual Performs a single sweep
        //     step when a manual trigger event occurs. The trigger system is not active. To
        //     trigger each frequency step of the sweep individually, use the command LFOutput:FREQuency:MANual.
        //     STEP Each trigger command triggers one sweep step only. The frequency increases
        //     by the value set with the coammnds: LFOutput (linear spacing) LFOutput:STEP:LOGarithmic(logarithmic
        //     spacing)
        public AutoManStepEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:MODE?").ToScpiEnum<AutoManStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_LfOutput_Sweep_Frequency_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
