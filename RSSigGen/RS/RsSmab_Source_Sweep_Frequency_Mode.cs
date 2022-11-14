using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency_Mode commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Sweep_Frequency_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MODE:ADVanced
        //     No additional help available
        public AutoManualModeEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:FREQuency:MODE:ADVanced?").ToScpiEnum<AutoManualModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:MODE:ADVanced " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MODE
        //     Sets the cycle mode for the frequency sweep.
        //     mode: AUTO| MANual| STEP AUTO Each trigger event triggers exactly one complete
        //     sweep. MANual The trigger system is not active. You can trigger every step individually
        //     by input of the frequencies with the command FREQuency:MANual. STEP Each trigger
        //     event triggers one sweep step. The frequency increases by the value entered with
        //     [:​SOURcehw]:​SWEep[:​FREQuency]:​STEP[:​LINear] (linear spacing) or STEP:LOGarithmic
        //     (logarithmic spacing) .
        public AutoManStepEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:FREQuency:MODE?").ToScpiEnum<AutoManStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Frequency_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
