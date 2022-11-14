using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Undo_Hclear commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Undo_Hclear
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Undo_Hclear(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hclear", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:UNDO:HCLear
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:UNDO:HCLear");
        }

        //
        // Сводка:
        //     SYSTem:UNDO:HCLear
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:UNDO:HCLear
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:UNDO:HCLear", opcTimeoutMs);
        }
    }
}
