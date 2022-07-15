using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Tpoint_Catalog commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Profiling_Tpoint_Catalog
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Profiling_Tpoint_Catalog(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Catalog", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:TPOint:CATalog
        //     No additional help available
        public List<string> Get(string name)
        {
            return _grpBase.IO.QueryStringArray("SYSTem:PROFiling:TPOint:CATalog? " + name.EncloseByQuotes()).ToStringList();
        }
    }
}
