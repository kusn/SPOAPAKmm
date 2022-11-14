using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Phase_Reference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Csynthesis_Phase_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }

        //
        // Сводка:
        //     CSYNthesis:PHASe:REFerence
        //     Resets the delta phase value.
        public void Set()
        {
            _grpBase.IO.Write("CSYNthesis:PHASe:REFerence");
        }

        //
        // Сводка:
        //     CSYNthesis:PHASe:REFerence
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     CSYNthesis:PHASe:REFerence
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("CSYNthesis:PHASe:REFerence", opcTimeoutMs);
        }
    }
}
