using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time_Zone commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Time_Zone
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:TIME:ZONE:CATalog
        //     Querys the list of available timezones.
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:TIME:ZONE:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:TIME:ZONE
        //     Sets the timezone. You can query the list of the available timezones with method
        //     RsSmab.System.Time.Zone.Catalog.
        //     timeZone: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:ZONE?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:ZONE " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time_Zone(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Zone", core, parent);
        }
    }
}
