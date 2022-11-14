using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Ntp commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Ntp
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:NTP:HOSTname
        //     Sets the address of the NTP server. You can enter the IP address, or the hostname
        //     of the time server, or even set up an own vendor zone. See the Internet for more
        //     information on NTP.
        //     ntpName: string
        public string Hostname
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:NTP:HOSTname?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:NTP:HOSTname " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:NTP:STATe
        //     Activates clock synchronization via NTP.
        //     useNtpState: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:NTP:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:NTP:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Ntp(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ntp", core, parent);
        }
    }
}
