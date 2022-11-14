using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Immediate", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:PULM:[INTernal]:[TRAin]:TRIGger:IMMediate
        //     If PULM:TRIGger:MODESINGle, triggers the pulse generator.
        public void Set()
        {
            _grpBase.IO.Write("SOURce:PULM:INTernal:TRAin:TRIGger:IMMediate");
        }

        //
        // Сводка:
        //     [SOURce]:PULM:[INTernal]:[TRAin]:TRIGger:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce]:PULM:[INTernal]:[TRAin]:TRIGger:IMMediate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce:PULM:INTernal:TRAin:TRIGger:IMMediate", opcTimeoutMs);
        }
    }
}
