using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_LffSweep_Immediate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trigger_LffSweep_Immediate
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trigger_LffSweep_Immediate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Immediate", core, parent);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:IMMediate
        //     Table Header: Performs a single sweep and immediately starts the activated, corresponding
        //     sweep: - FSWeep - RF frequency, - PSWeep - RF level, - LFFSweep - LF frequency,
        //     - SWEep - all sweepsTable Header: Effective in the following configuration: -
        //     TRIG:FSW|LFFS|PSW|[:SWE]:SOURSING, - SOUR:SWE:FREQ|POW:MODEAUTO or SOUR:LFO:SWE:[FREQ:]MODEAUTO
        //     Alternatively, you can use the IMMediate command instead of the respective SWEep:[FREQ:]|POW:EXECute
        //     command.
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public void Set(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("TRIGger" + repCapCmdValue + ":LFFSweep:IMMediate");
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(InputIxRepCap inputIx)
        {
            SetAndWait(inputIx, -1);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(InputIxRepCap inputIx, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.WriteWithOpc("TRIGger" + repCapCmdValue + ":LFFSweep:IMMediate", opcTimeoutMs);
        }
    }
}
