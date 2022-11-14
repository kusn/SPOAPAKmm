using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_Execute
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_HardCopy_Execute(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Execute", core, parent);
        }

        //
        // Сводка:
        //     HCOPy:[EXECute]
        //     Generates a hard copy of the current display. The output destination is a file.
        public void Set()
        {
            _grpBase.IO.Write("HCOPy:EXECute");
        }

        //
        // Сводка:
        //     HCOPy:[EXECute]
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     HCOPy:[EXECute]
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("HCOPy:EXECute", opcTimeoutMs);
        }
    }
}
