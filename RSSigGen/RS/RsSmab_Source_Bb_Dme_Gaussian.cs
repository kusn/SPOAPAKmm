using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Dme_Gaussian commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Bb_Dme_Gaussian
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Bb_Dme_Gaussian(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gaussian", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:DME:GAUSsian
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:DME:GAUSsian");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:DME:GAUSsian
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:DME:GAUSsian
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:BB:DME:GAUSsian", opcTimeoutMs);
        }
    }
}
