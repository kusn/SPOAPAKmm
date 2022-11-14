using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Fpreset commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Fpreset
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Fpreset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Fpreset", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:FPReset
        //     Triggers an instrument reset to the original state of delivery.
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:FPReset");
        }

        //
        // Сводка:
        //     SYSTem:FPReset
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:FPReset
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:FPReset", opcTimeoutMs);
        }
    }
}
