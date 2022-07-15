using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Owner commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Lock_Owner
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:LOCK:OWNer:DETailed
        //     No additional help available
        public string Detailed => _grpBase.IO.QueryString("SYSTem:LOCK:OWNer:DETailed?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:LOCK:OWNer
        //     Queries the sessions that have locked the instrument currently. If an exclusive
        //     lock is set, the query returns the owner of this exclusive lock, otherwise it
        //     returns NONE.
        //     owner: string
        public string Value => _grpBase.IO.QueryString("SYSTem:LOCK:OWNer?").TrimStringResponse();

        internal RsSmab_System_Lock_Owner(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Owner", core, parent);
        }
    }
}
