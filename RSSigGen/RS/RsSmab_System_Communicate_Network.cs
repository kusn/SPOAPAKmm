using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Network commands group definition
    //     Sub-classes count: 3
    //     Commands count: 3
    //     Total commands count: 12
    public class RsSmab_System_Communicate_Network
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Communicate_Network_IpAddress _ipAddress;

        private RsSmab_System_Communicate_Network_Restart _restart;

        private RsSmab_System_Communicate_Network_Common _common;

        //
        // Сводка:
        //     IpAddress commands group
        //     Sub-classes count: 1
        //     Commands count: 4
        //     Total commands count: 5
        public RsSmab_System_Communicate_Network_IpAddress IpAddress => _ipAddress ?? (_ipAddress = new RsSmab_System_Communicate_Network_IpAddress(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Restart commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Network_Restart Restart => _restart ?? (_restart = new RsSmab_System_Communicate_Network_Restart(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Common commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_System_Communicate_Network_Common Common => _common ?? (_common = new RsSmab_System_Communicate_Network_Common(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:MACaddress
        //     Queries the MAC address of the network adapter. This is a password-protected
        //     function. Unlock the protection level 1 to access it. See SYSTem.
        //     macAddress: string
        public string MacAddress
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:MACaddress?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:MACaddress " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:RESource
        //     Queries the visa resource string for Ethernet instruments.
        //     resource: string
        public string Resource => _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:RESource?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:STATus
        //     Queries the network configuration state.
        //     state: 0| 1| OFF| ON
        public bool Status => _grpBase.IO.QueryBoolean("SYSTem:COMMunicate:NETWork:STATus?");

        internal RsSmab_System_Communicate_Network(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Network", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Communicate_Network Clone()
        {
            RsSmab_System_Communicate_Network rsSmab_System_Communicate_Network = new RsSmab_System_Communicate_Network(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Communicate_Network);
            return rsSmab_System_Communicate_Network;
        }
    }
}
