using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Debug_Page
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Debug_Page(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Page", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:DEBug:PAGE
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("DIAGnostic<HwInstance>:DEBug:PAGE");
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:DEBug:PAGE
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:DEBug:PAGE
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DIAGnostic<HwInstance>:DEBug:PAGE", opcTimeoutMs);
        }
    }
}
