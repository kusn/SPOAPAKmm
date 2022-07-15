using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Shared commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Lock_Shared
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:LOCK:SHARed:STRing
        //     No additional help available
        public string String => _grpBase.IO.QueryString("SYSTem:LOCK:SHARed:STRing?").TrimStringResponse();

        internal RsSmab_System_Lock_Shared(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Shared", core, parent);
        }
    }
}
