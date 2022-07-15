using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Hislip commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Hislip
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:HISLip:RESource
        //     Queries the VISA resource string. This string is used for remote control of the
        //     instrument with HiSLIP protocol.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:HISLip:RESource?").TrimStringResponse();

        internal RsSmab_System_Communicate_Hislip(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hislip", core, parent);
        }
    }
}
