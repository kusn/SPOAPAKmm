using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_Execute commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_HardCopy_Execute
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_HardCopy_Execute(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Execute", core, parent);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:[EXECute]
        //     Triggers the generation of a hardcopy of the current measurement diagram. The
        //     data is written into the file selected/created with the SWEep:HCOPy command.
        public void Set()
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:EXECute");
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:[EXECute]
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:[EXECute]
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SENSe:POWer:SWEep:HCOPy:EXECute", opcTimeoutMs);
        }
    }
}
