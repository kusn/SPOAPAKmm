using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Clear_Lan commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Slist_Clear_Lan
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Slist_Clear_Lan(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lan", core, parent);
        }

        //
        // Сводка:
        //     SLISt:CLEar:LAN
        //     Removes all R&S NRP power sensors connected in the LAN from the list.
        public void Set()
        {
            _grpBase.IO.Write("SLISt:CLEar:LAN");
        }

        //
        // Сводка:
        //     SLISt:CLEar:LAN
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SLISt:CLEar:LAN
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SLISt:CLEar:LAN", opcTimeoutMs);
        }
    }
}
