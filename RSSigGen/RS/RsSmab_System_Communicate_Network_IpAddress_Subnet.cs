using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Network_IpAddress_Subnet commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Network_IpAddress_Subnet
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:NETWork:[IPADdress]:SUBNet:MASK
        //     Sets the subnet mask.
        //     mask: string
        public string Mask
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:COMMunicate:NETWork:IPADdress:SUBNet:MASK?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:COMMunicate:NETWork:IPADdress:SUBNet:MASK " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Communicate_Network_IpAddress_Subnet(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Subnet", core, parent);
        }
    }
}
