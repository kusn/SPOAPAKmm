using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Device_Settings_Restore
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Device_Settings_Restore(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Restore", core, parent);
        }

        //
        // Сводка:
        //     DEVice:SETTings:RESTore
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("DEVice:SETTings:RESTore");
        }

        //
        // Сводка:
        //     DEVice:SETTings:RESTore
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     DEVice:SETTings:RESTore
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DEVice:SETTings:RESTore", opcTimeoutMs);
        }
    }
}
