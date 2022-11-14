using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Device_Settings_Backup
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Device_Settings_Backup(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Backup", core, parent);
        }

        //
        // Сводка:
        //     DEVice:SETTings:BACKup
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("DEVice:SETTings:BACKup");
        }

        //
        // Сводка:
        //     DEVice:SETTings:BACKup
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     DEVice:SETTings:BACKup
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DEVice:SETTings:BACKup", opcTimeoutMs);
        }
    }
}
