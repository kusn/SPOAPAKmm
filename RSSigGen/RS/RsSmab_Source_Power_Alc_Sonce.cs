using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Alc_Sonce commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Power_Alc_Sonce
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Power_Alc_Sonce(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sonce", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:SONCe
        //     Activates level control for correction purposes temporarily.
        public void Set()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:POWer:ALC:SONCe");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:POWer:ALC:SONCe", opcTimeoutMs);
        }
    }
}
