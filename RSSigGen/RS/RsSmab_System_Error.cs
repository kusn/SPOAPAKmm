using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Error commands group definition
    //     Sub-classes count: 2
    //     Commands count: 3
    //     Total commands count: 7
    public class RsSmab_System_Error
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Error_Code _code;

        private RsSmab_System_Error_History _history;

        //
        // Сводка:
        //     Code commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Error_Code Code => _code ?? (_code = new RsSmab_System_Error_Code(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     History commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Error_History History => _history ?? (_history = new RsSmab_System_Error_History(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:ERRor:ALL
        //     Queries the error/event queue for all unread items and removes them from the
        //     queue.
        //     all: string Error/event_number,"Error/event_description[;Device-dependent info]"
        //     A comma separated list of error number and a short description of the error in
        //     FIFO order. If the queue is empty, the response is 0,"No error" Positive error
        //     numbers are instrument-dependent. Negative error numbers are reserved by the
        //     SCPI standard. Volatile errors are reported once, at the time they appear. Identical
        //     errors are reported repeatedly only if the original error has already been retrieved
        //     from (and hence not any more present in) the error queue.
        public string All => _grpBase.IO.QueryString("SYSTem:ERRor:ALL?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:ERRor:COUNt
        //     Queries the number of entries in the error queue.
        //     count: integer 0 The error queue is empty.
        public string Count => _grpBase.IO.QueryString("SYSTem:ERRor:COUNt?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:ERRor:STATic
        //     Returns a list of all errors existing at the time when the query is started.
        //     This list corresponds to the display on the info page under manual control.
        //     staticErrors: string
        public string Static => _grpBase.IO.QueryString("SYSTem:ERRor:STATic?").TrimStringResponse();

        internal RsSmab_System_Error(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Error", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Error Clone()
        {
            RsSmab_System_Error rsSmab_System_Error = new RsSmab_System_Error(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Error);
            return rsSmab_System_Error;
        }
    }
}
