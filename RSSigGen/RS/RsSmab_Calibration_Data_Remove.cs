using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data_Remove commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Data_Remove
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calibration_Data_Remove(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Remove", core, parent);
        }

        //
        // Сводка:
        //     CALibration:DATA:REMove
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("CALibration:DATA:REMove");
        }

        //
        // Сводка:
        //     CALibration:DATA:REMove
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     CALibration:DATA:REMove
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("CALibration:DATA:REMove", opcTimeoutMs);
        }
    }
}
