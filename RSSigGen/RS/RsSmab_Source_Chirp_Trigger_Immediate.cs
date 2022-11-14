using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp_Trigger_Immediate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Chirp_Trigger_Immediate
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Chirp_Trigger_Immediate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Immediate", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:TRIGger:IMMediate
        //     Immediately starts the chirp signal generation.
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:TRIGger:IMMediate");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:TRIGger:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:TRIGger:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:CHIRp:TRIGger:IMMediate", opcTimeoutMs);
        }
    }
}
