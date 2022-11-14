using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Specification_Identification commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Specification_Identification
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:SPECification:IDENtification:CATalog
        //     Queries the parameter identifiers (<Id>) available in the data sheet.
        //     idList: string Comma-separated string of the parameter identifiers (Id)
        public string Catalog => _grpBase.IO.QueryString("SYSTem:SPECification:IDENtification:CATalog?").TrimStringResponse();

        internal RsSmab_System_Specification_Identification(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Identification", core, parent);
        }
    }
}
