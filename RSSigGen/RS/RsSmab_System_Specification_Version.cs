using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Specification_Version commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_System_Specification_Version
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:SPECification:VERSion:CATalog
        //     Queries all data sheet versions stored in the instrument.
        //     versCatalog: string
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:SPECification:VERSion:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:SPECification:VERSion:FACTory
        //     Queries the data sheet version of the factory setting.
        //     version: string
        public string Factory => _grpBase.IO.QueryString("SYSTem:SPECification:VERSion:FACTory?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:SPECification:VERSion:SFACtory
        //     No additional help available
        public string Sfactory
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:SPECification:VERSion:SFACtory?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SPECification:VERSion:SFACtory " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:SPECification:VERSion
        //     Selects a data sheet version from the data sheets saved on the instrument. Further
        //     queries regarding the data sheet parameters (<Id>) and their values refer to
        //     the selected data sheet. To query the list of data sheet versions, use the command
        //     method RsSmab.System.Specification.Version.Catalog.
        //     version: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:SPECification:VERSion?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SPECification:VERSion " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Specification_Version(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Version", core, parent);
        }
    }
}
