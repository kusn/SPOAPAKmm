using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_SuPolicy commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Security_SuPolicy
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Security_SuPolicy(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("SuPolicy", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:SUPolicy
        //     Configures the automatic signature verification for firmware installation.
        //
        // Параметры:
        //   secPassWord:
        //     string
        //
        //   updatePolicy:
        //     STRict| CONFirm| IGNore
        public void Set(string secPassWord, UpdPolicyModeEnum updatePolicy)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(secPassWord, 0, DataType.String), new ArgSingle(updatePolicy, 1, DataType.Enum));
            _grpBase.IO.Write("SYSTem:SECurity:SUPolicy " + text);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:SUPolicy
        //     Configures the automatic signature verification for firmware installation.
        //     updatePolicy: STRict| CONFirm| IGNore
        public UpdPolicyModeEnum Get()
        {
            return _grpBase.IO.QueryString("SYSTem:SECurity:SUPolicy?").ToScpiEnum<UpdPolicyModeEnum>();
        }
    }
}
