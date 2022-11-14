using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Localizer_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Ils_Localizer_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:FREQuency:MODE
        //     Sets the mode for the carrier frequency of the signal.
        public AvionicCarrFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:FREQuency:MODE?").ToScpiEnum<AvionicCarrFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:FREQuency:STEP
        //     No additional help available
        public AvionicCarrFreqModeEnum Step
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:FREQuency:STEP?").ToScpiEnum<AvionicCarrFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:FREQuency:STEP " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:FREQuency
        //     Sets the carrier frequency of the signal.
        //     carrierFreq: float Range: 100E3 to 6E9
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Localizer_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
