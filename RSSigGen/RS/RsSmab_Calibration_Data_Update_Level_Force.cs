using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data_Update_Level_Force commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Data_Update_Level_Force
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calibration_Data_Update_Level_Force(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Force", core, parent);
        }

        //
        // Сводка:
        //     CALibration<HW>:DATA:UPDate:LEVel:FORCe
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("CALibration<HwInstance>:DATA:UPDate:LEVel:FORCe");
        }

        //
        // Сводка:
        //     CALibration<HW>:DATA:UPDate:LEVel:FORCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     CALibration<HW>:DATA:UPDate:LEVel:FORCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("CALibration<HwInstance>:DATA:UPDate:LEVel:FORCe", opcTimeoutMs);
        }
    }
}
