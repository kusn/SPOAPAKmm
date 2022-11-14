using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Reboot commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Reboot
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Reboot(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reboot", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:REBoot
        //     Reboots the instrument including the operating system.
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:REBoot");
        }

        //
        // Сводка:
        //     SYSTem:REBoot
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:REBoot
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:REBoot", opcTimeoutMs);
        }
    }
}
