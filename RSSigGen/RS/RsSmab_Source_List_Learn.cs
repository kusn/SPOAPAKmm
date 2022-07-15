using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Learn commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_List_Learn
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_List_Learn(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Learn", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:LEARn
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:LIST:LEARn");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:LEARn
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:LEARn
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:LIST:LEARn", opcTimeoutMs);
        }
    }
}
