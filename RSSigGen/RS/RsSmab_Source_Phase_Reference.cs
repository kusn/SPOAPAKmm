using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Phase_Reference commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Phase_Reference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Phase_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PHASe:REFerence
        //     Assigns the value set with command PHASe as the reference phase.
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:PHASe:REFerence");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PHASe:REFerence
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PHASe:REFerence
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:PHASe:REFerence", opcTimeoutMs);
        }
    }
}
