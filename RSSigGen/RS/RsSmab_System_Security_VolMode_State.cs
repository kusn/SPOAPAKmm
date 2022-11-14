using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_VolMode_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Security_VolMode_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Security_VolMode_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:VOLMode:[STATe]
        //     Activates volatile mode, so that no user data can be written to the internal
        //     memory permanently. To enable volatile mode, reboot the instrument. Otherwise
        //     the change has no effect.
        //
        // Параметры:
        //   secPassWord:
        //     string Current security password The default password is 123456.
        //
        //   mmemProtState:
        //     0| 1| OFF| ON
        public void Set(string secPassWord, bool mmemProtState)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(secPassWord, 0, DataType.String), new ArgSingle(mmemProtState, 1, DataType.Boolean));
            _grpBase.IO.Write("SYSTem:SECurity:VOLMode:STATe " + text);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:VOLMode:[STATe]
        //     Activates volatile mode, so that no user data can be written to the internal
        //     memory permanently. To enable volatile mode, reboot the instrument. Otherwise
        //     the change has no effect.
        //     mmemProtState: 0| 1| OFF| ON
        public bool Get()
        {
            return _grpBase.IO.QueryBoolean("SYSTem:SECurity:VOLMode:STATe?");
        }
    }
}
