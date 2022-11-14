using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Dexchange_Execute commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Pulm_Train_Dexchange_Execute
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Pulm_Train_Dexchange_Execute(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Execute", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:EXECute
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DEXChange:EXECute");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:EXECute
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:EXECute
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:PULM:TRAin:DEXChange:EXECute", opcTimeoutMs);
        }
    }
}
