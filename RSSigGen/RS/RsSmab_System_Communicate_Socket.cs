using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Socket commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Socket
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:SOCKet:RESource
        //     Queries the visa resource string for remote control via LAN interface, using
        //     TCP/IP socket protocol.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:SOCKet:RESource?").TrimStringResponse();

        internal RsSmab_System_Communicate_Socket(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Socket", core, parent);
        }
    }
}
