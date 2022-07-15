using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Dexchange_Transaction commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Dexchange_Transaction
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DEXChange:TRANsaction:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:DEXChange:TRANsaction:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:TRANsaction:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Dexchange_Transaction(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Transaction", core, parent);
        }
    }
}
