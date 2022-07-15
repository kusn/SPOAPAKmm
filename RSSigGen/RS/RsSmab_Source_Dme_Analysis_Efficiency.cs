using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme_Analysis_Efficiency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Dme_Analysis_Efficiency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:EFFiciency:OK
        //     No additional help available
        public bool Ok
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:EFFiciency:OK?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:EFFiciency:OK " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:EFFiciency:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:EFFiciency:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:EFFiciency:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Dme_Analysis_Efficiency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Efficiency", core, parent);
        }
    }
}
