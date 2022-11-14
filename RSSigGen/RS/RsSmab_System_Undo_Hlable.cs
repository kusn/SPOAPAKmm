using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Undo_Hlable commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Undo_Hlable
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:UNDO:HLABle:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:UNDO:HLABle:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:UNDO:HLABle:SELect
        //     No additional help available
        public string Select
        {
            set
            {
                _grpBase.IO.Write("SYSTem:UNDO:HLABle:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Undo_Hlable(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hlable", core, parent);
        }
    }
}
