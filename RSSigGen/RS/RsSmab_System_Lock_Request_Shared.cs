using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Request_Shared commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Lock_Request_Shared
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Lock_Request_Shared(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Shared", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:LOCK:REQuest:SHARed
        //     No additional help available
        public int Get(string name, int timeoutMs)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(name, 0, DataType.String), new ArgSingle(timeoutMs, 1, DataType.Integer));
            return _grpBase.IO.QueryInt32("SYSTem:LOCK:REQuest:SHARed? " + text);
        }
    }
}
