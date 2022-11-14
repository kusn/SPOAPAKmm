using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Network_IpAddress commands group definition
    //     Sub-classes count: 1
    //     Commands count: 4
    //     Total commands count: 5
    public class RsSmab_System_Communicate_Network_IpAddress
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Communicate_Network_IpAddress_Subnet _subnet;

        //
        // Сводка:
        //     Subnet commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Network_IpAddress_Subnet Subnet => _subnet ?? (_subnet = new RsSmab_System_Communicate_Network_IpAddress_Subnet(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:IPADdress:MODE
        //     Selects manual or automatic setting of the IP address.
        //     mode: AUTO| STATic
        public NetModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:IPADdress:MODE?").ToScpiEnum<NetModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:IPADdress:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[IPADdress]:DNS
        //     Determines or queries the network DNS server to resolve the name.
        //     dns: string
        public string Dns
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:IPADdress:DNS?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:IPADdress:DNS " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[IPADdress]:GATeway
        //     Sets the IP address of the default gateway.
        //     gateway: string Range: 0.0.0.0 to ff.ff.ff.ff
        public string Gateway
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:IPADdress:GATeway?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:IPADdress:GATeway " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:IPADdress
        //     Sets the IP address.
        //     ipAddress: string Range: 0.0.0.0. to ff.ff.ff.ff
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:IPADdress?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:IPADdress " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Communicate_Network_IpAddress(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("IpAddress", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Communicate_Network_IpAddress Clone()
        {
            RsSmab_System_Communicate_Network_IpAddress rsSmab_System_Communicate_Network_IpAddress = new RsSmab_System_Communicate_Network_IpAddress(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Communicate_Network_IpAddress);
            return rsSmab_System_Communicate_Network_IpAddress;
        }
    }
}
