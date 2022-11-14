using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Name commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Lock_Name
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:LOCK:NAME:DETailed
        //     No additional help available
        public string Detailed => _grpBase.IO.QueryString("SYSTem:LOCK:NAME:DETailed?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:LOCK:NAME
        //     No additional help available
        public string Value => _grpBase.IO.QueryString("SYSTem:LOCK:NAME?").TrimStringResponse();

        internal RsSmab_System_Lock_Name(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Name", core, parent);
        }
    }
}
