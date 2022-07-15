﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_ExtDevices_Update_Check commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_ExtDevices_Update_Check
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_ExtDevices_Update_Check(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Check", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:EXTDevices:UPDate:CHECk
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:EXTDevices:UPDate:CHECk");
        }

        //
        // Сводка:
        //     SYSTem:EXTDevices:UPDate:CHECk
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:EXTDevices:UPDate:CHECk
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:EXTDevices:UPDate:CHECk", opcTimeoutMs);
        }
    }
}
