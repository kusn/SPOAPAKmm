using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Ukey_Add
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Display_Ukey_Add(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Add", core, parent);
        }

        //
        // Сводка:
        //     DISPlay:UKEY:ADD
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("DISPlay:UKEY:ADD");
        }

        //
        // Сводка:
        //     DISPlay:UKEY:ADD
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     DISPlay:UKEY:ADD
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DISPlay:UKEY:ADD", opcTimeoutMs);
        }
    }
}
