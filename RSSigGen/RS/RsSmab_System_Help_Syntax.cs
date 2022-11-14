using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Help_Syntax commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Help_Syntax
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:HELP:SYNTax:ALL
        //     No additional help available
        public string All => _grpBase.IO.QueryString("SYSTem:HELP:SYNTax:ALL?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:HELP:SYNTax
        //     No additional help available
        public string Value => _grpBase.IO.QueryString("SYSTem:HELP:SYNTax?").TrimStringResponse();

        internal RsSmab_System_Help_Syntax(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Syntax", core, parent);
        }
    }
}
