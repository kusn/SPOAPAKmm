using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gs_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Ils_Gs_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:FREQuency:MODE
        //     Sets the mode for the carrier frequency of the signal.
        //     mode: USER| ICAO DECimal Activates user-defined variation of the carrier frequency.
        //     ICAO Activates variation in predefined steps according to standard ILS transmitting
        //     frequencies (see Table "ILS glide slope and localizer ICAO standard frequencies
        //     (MHz) and channels") .
        public AvionicCarrFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:FREQuency:MODE?").ToScpiEnum<AvionicCarrFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:FREQuency:STEP
        //     No additional help available
        public AvionicKnobStepEnum Step
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:FREQuency:STEP?").ToScpiEnum<AvionicKnobStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:FREQuency:STEP " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:FREQuency
        //     Sets the carrier frequency of the signal.
        //     carrierFreq: float Range: 100E3 to 6E9
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gs_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
