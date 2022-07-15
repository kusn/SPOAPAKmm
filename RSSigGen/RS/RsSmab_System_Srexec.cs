using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Srexec commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Srexec
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Srexec(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Srexec", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SREXec
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:SREXec");
        }

        //
        // Сводка:
        //     SYSTem:SREXec
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:SREXec
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:SREXec", opcTimeoutMs);
        }
    }
}
