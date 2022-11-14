using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_ExtDevices_Update_Needed commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_ExtDevices_Update_Needed
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:EXTDevices:UPDate:NEEDed:[STATe]
        //     No additional help available
        public bool State => _grpBase.IO.QueryBoolean("SYSTem:EXTDevices:UPDate:NEEDed:STATe?");

        internal RsSmab_System_ExtDevices_Update_Needed(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Needed", core, parent);
        }
    }
}
