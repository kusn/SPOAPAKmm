using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Pll commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Frequency_Pll
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:PLL:MODE
        //     Selects the PLL (Phase Locked Loop) bandwidth of the main synthesizer.
        //     mode: NORMal| NARRow NORMal Maximum modulation bandwidth and FM/PhiM deviation.
        //     NARRow Narrow PLL bandwidth
        public FreqPllModeFenum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:PLL:MODE?").ToScpiEnum<FreqPllModeFenum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:PLL:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Frequency_Pll(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pll", core, parent);
        }
    }
}
