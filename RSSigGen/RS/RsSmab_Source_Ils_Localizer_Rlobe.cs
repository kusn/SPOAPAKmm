using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Localizer_Rlobe commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Ils_Localizer_Rlobe
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:RLOBe:[FREQuency]
        //     Sets the modulation frequency of the antenna lobe arranged at the right viewed
        //     from the air plane.
        //     frequency: float Range: 100 to 200
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:RLOBe:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:RLOBe:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Localizer_Rlobe(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Rlobe", core, parent);
        }
    }
}
