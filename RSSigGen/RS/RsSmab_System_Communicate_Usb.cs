using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Usb commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Usb
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:USB:RESource
        //     Queries the visa resource string for remote control via the USB interface.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:USB:RESource?").TrimStringResponse();

        internal RsSmab_System_Communicate_Usb(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Usb", core, parent);
        }
    }
}
