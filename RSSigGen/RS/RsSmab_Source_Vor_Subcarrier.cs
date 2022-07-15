using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor_Subcarrier commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Vor_Subcarrier
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:SUBCarrier:DEPTh
        //     Sets the AM modulation depth of the FM carrier.
        //     depth: float Range: 0 to 100
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:SUBCarrier:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:SUBCarrier:DEPTh " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:SUBCarrier:[FREQuency]
        //     Sets the frequency of the FM carrier.
        //     frequency: float Range: 5E3 to 15E3
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:SUBCarrier:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:SUBCarrier:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Vor_Subcarrier(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Subcarrier", core, parent);
        }
    }
}
