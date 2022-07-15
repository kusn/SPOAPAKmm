using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Mbeacon commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Mbeacon
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:MBEacon:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:MBEacon:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:MBEacon:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Mbeacon(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mbeacon", core, parent);
        }
    }
}
