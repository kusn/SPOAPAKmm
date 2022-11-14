using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Serror_Set commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Test_Serror_Set
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Test_Serror_Set(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Set", core, parent);
        }

        //
        // Сводка:
        //     TEST:SERRor:SET
        //     No additional help available
        public void Set(int errCode, int path)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(errCode, 0, DataType.Integer), new ArgSingle(path, 1, DataType.Integer));
            _grpBase.IO.Write("TEST:SERRor:SET " + text);
        }
    }
}
