using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gslope_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Ils_Gslope_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:FREQuency:MODE
        //     Sets the mode for the carrier frequency of the signal.
        //     mode: USER| ICAO DECimal Activates user-defined variation of the carrier frequency.
        //     ICAO Activates variation in predefined steps according to standard ILS transmitting
        //     frequencies (see Table "ILS glide slope and localizer ICAO standard frequencies
        //     (MHz) and channels") .
        public AvionicCarrFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GSLope:FREQuency:MODE?").ToScpiEnum<AvionicCarrFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:FREQuency:STEP
        //     No additional help available
        public AvionicKnobStepEnum Step
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GSLope:FREQuency:STEP?").ToScpiEnum<AvionicKnobStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:FREQuency:STEP " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:FREQuency
        //     Sets the carrier frequency of the signal.
        //     carrierFreq: float Range: 100E3 to 6E9
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GSLope:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gslope_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
