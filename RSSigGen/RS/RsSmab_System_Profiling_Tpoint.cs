using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Tpoint commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_System_Profiling_Tpoint
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Profiling_Tpoint_Catalog _catalog;

        //
        // Сводка:
        //     Catalog commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Profiling_Tpoint_Catalog Catalog => _catalog ?? (_catalog = new RsSmab_System_Profiling_Tpoint_Catalog(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:PROFiling:TPOint:RESTart
        //     No additional help available
        public List<string> Restart
        {
            get
            {
                return _grpBase.IO.QueryStringArray("SYSTem:PROFiling:TPOint:RESTart?").ToStringList();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:TPOint:RESTart " + value.ToCsvString());
            }
        }

        internal RsSmab_System_Profiling_Tpoint(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Tpoint", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Profiling_Tpoint Clone()
        {
            RsSmab_System_Profiling_Tpoint rsSmab_System_Profiling_Tpoint = new RsSmab_System_Profiling_Tpoint(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Profiling_Tpoint);
            return rsSmab_System_Profiling_Tpoint;
        }
    }
}
