using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme_Analysis_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Dme_Analysis_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:POWer:OK
        //     No additional help available
        public bool Ok
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:POWer:OK?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:POWer:OK " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:POWer:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:POWer:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:POWer:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Dme_Analysis_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
