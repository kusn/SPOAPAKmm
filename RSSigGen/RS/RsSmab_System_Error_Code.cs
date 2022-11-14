using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Error_Code commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Error_Code
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:ERRor:CODE:ALL
        //     Queries the error numbers of all entries in the error queue and then deletes
        //     them.
        //     all: string Returns the error numbers. To retrieve the entire error text, send
        //     the command method RsSmab.System.Error.All. 0 "No error", i.e. the error queue
        //     is empty Positive value Positive error numbers denote device-specific errors
        //     Negative value Negative error numbers denote error messages defined by SCPI.
        public string All => _grpBase.IO.QueryString("SYSTem:ERRor:CODE:ALL?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:ERRor:CODE:[NEXT]
        //     Queries the error number of the oldest entry in the error queue and then deletes
        //     it.
        //     next: string Returns the error number. To retrieve the entire error text, send
        //     the command method RsSmab.System.Error.All. 0 "No error", i.e. the error queue
        //     is empty Positive value Positive error numbers denote device-specific errors
        //     Negative value Negative error numbers denote error messages defined by SCPI.
        public string Next => _grpBase.IO.QueryString("SYSTem:ERRor:CODE:NEXT?").TrimStringResponse();

        internal RsSmab_System_Error_Code(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Code", core, parent);
        }
    }
}
