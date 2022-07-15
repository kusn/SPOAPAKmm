using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Module commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Profiling_Module
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PROFiling:MODule:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:PROFiling:MODule:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:PROFiling:MODule:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:PROFiling:MODule:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:MODule:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Profiling_Module(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Module", core, parent);
        }
    }
}
