using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_Mmem_Protect_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Security_Mmem_Protect_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Security_Mmem_Protect_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:MMEM:PROTect:[STATe]
        //     No additional help available
        public void Set(string secPassWord, bool mmemProtState)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(secPassWord, 0, DataType.String), new ArgSingle(mmemProtState, 1, DataType.Boolean));
            _grpBase.IO.Write("SYSTem:SECurity:MMEM:PROTect:STATe " + text);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:MMEM:PROTect:[STATe]
        //     No additional help available
        public bool Get()
        {
            return _grpBase.IO.QueryBoolean("SYSTem:SECurity:MMEM:PROTect:STATe?");
        }
    }
}
