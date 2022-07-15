using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Network_Common commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_System_Communicate_Network_Common
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[COMMon]:DOMain
        //     Determines the primary suffix of the network domain.
        //     domain: string
        public string Domain
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:COMMon:DOMain?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:COMMon:DOMain " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[COMMon]:HOSTname
        //     Sets an individual hostname for the Signal Generator. Note:We recommend that
        //     you do not change the hostname to avoid problems with the network connection.
        //     If you change the hostname, be sure to use a unique name. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //     hostname: string
        public string Hostname
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:COMMon:HOSTname?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:COMMon:HOSTname " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[COMMon]:WORKgroup
        //     Sets an individual workgroup name for the instrument.
        //     workgroup: string
        public string Workgroup
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:COMMon:WORKgroup?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:COMMon:WORKgroup " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Communicate_Network_Common(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Common", core, parent);
        }
    }
}
