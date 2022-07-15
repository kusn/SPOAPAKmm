using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gslope_Llobe commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Ils_Gslope_Llobe
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:LLOBe:[FREQuency]
        //     Sets the modulation frequency of the antenna lobe arranged at the bottom viewed
        //     from the air plane for the ILS glide slope modulation signal.
        //     frequency: float Range: 100 to 200
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GSLope:LLOBe:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:LLOBe:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gslope_Llobe(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Llobe", core, parent);
        }
    }
}
