using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Dme_Analysis_Time commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Dme_Analysis_Time
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:TIME:OK
        //     No additional help available
        public bool Ok
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:TIME:OK?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:TIME:OK " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:DME:ANALysis:TIME:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:DME:ANALysis:TIME:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:DME:ANALysis:TIME:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Dme_Analysis_Time(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Time", core, parent);
        }
    }
}
