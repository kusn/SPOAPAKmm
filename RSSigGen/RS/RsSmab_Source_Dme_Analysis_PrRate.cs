using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme_Analysis_PrRate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Dme_Analysis_PrRate
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:PRRate:OK
        //     No additional help available
        public bool Ok
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:PRRate:OK?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:PRRate:OK " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:PRRate:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:PRRate:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:PRRate:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Dme_Analysis_PrRate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("PrRate", core, parent);
        }
    }
}
