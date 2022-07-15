using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Error_History commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Error_History
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:ERRor:HISTory
        //     No additional help available
        public string Value => _grpBase.IO.QueryString("SYSTem:ERRor:HISTory?").TrimStringResponse();

        internal RsSmab_System_Error_History(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("History", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:ERRor:HISTory:CLEar
        //     Clears the error history.
        public void Clear()
        {
            _grpBase.IO.Write("SYSTem:ERRor:HISTory:CLEar");
        }

        //
        // Сводка:
        //     SYSTem:ERRor:HISTory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAndWait()
        {
            ClearAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:ERRor:HISTory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:ERRor:HISTory:CLEar", opcTimeoutMs);
        }
    }
}
