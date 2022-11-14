using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Firmware_Update commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Frequency_Multiplier_External_Firmware_Update
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Frequency_Multiplier_External_Firmware_Update(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Update", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:UPDate
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:UPDate");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:UPDate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:FIRMware:UPDate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:FIRMware:UPDate", opcTimeoutMs);
        }
    }
}
