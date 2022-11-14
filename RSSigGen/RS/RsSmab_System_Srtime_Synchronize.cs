using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Srtime_Synchronize commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Srtime_Synchronize
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Srtime_Synchronize(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Synchronize", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SRTime:SYNChronize
        //     No additional help available
        public string Get(string time)
        {
            return _grpBase.IO.QueryString("SYSTem:SRTime:SYNChronize? " + time.EncloseByQuotes()).TrimStringResponse();
        }
    }
}
