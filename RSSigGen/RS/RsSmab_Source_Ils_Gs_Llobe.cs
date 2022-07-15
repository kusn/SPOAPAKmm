using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gs_Llobe commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Ils_Gs_Llobe
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:LLOBe:[FREQuency]
        //     Sets the modulation frequency of the antenna lobe arranged at the bottom viewed
        //     from the air plane for the ILS glide slope modulation signal.
        //     frequency: float Range: 100 to 200
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:LLOBe:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:LLOBe:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gs_Llobe(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Llobe", core, parent);
        }
    }
}
