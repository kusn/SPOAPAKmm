using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Combined_Execute commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Combined_Execute
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Sweep_Combined_Execute(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Execute", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:EXECute
        //     Executes an RF frequency / level sweep cycle. The command triggers one single
        //     sweep manually. Therefore, you can use it in manual sweep mode, selected with
        //     the command [:SOURce<hw>]:SWEep:COMBined:MODE > MANual.
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:SWEep:COMBined:EXECute");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:EXECute
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:COMBined:EXECute
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:SWEep:COMBined:EXECute", opcTimeoutMs);
        }
    }
}
