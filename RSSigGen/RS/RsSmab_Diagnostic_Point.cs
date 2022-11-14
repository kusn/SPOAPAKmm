using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Point
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Point_Configuration _configuration;

        //
        // Сводка:
        //     Configuration commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Point_Configuration Configuration => _configuration ?? (_configuration = new RsSmab_Diagnostic_Point_Configuration(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     DIAGnostic<HW>:POINt:CATalog
        //     Queries the test points available in the instrument. For more information, see
        //     R&S SMA100B Service Manual.
        //     catalog: string List of comma-separated values, each representing a test point
        public List<string> Catalog => _grpBase.IO.QueryStringArray("DIAGnostic<HwInstance>:POINt:CATalog?").ToStringList();

        internal RsSmab_Diagnostic_Point(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Point", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Point Clone()
        {
            RsSmab_Diagnostic_Point rsSmab_Diagnostic_Point = new RsSmab_Diagnostic_Point(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Point);
            return rsSmab_Diagnostic_Point;
        }
    }
}
