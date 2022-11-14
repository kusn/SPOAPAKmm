using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Scan commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 3
    public class RsSmab_Slist_Scan
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Slist_Scan_Usensor _usensor;

        //
        // Сводка:
        //     Usensor commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Slist_Scan_Usensor Usensor => _usensor ?? (_usensor = new RsSmab_Slist_Scan_Usensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SLISt:SCAN:LSENsor
        //     Scans for R&S NRP power sensors connected in the LAN.
        //     Ip: string
        public string Lsensor
        {
            set
            {
                _grpBase.IO.Write("SLISt:SCAN:LSENsor " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SLISt:SCAN:[STATe]
        //     Starts the search for R&S NRP power sensors, connected in the LAN or via the
        //     USBTMC protocol.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SLISt:SCAN:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SLISt:SCAN:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Slist_Scan(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Scan", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Slist_Scan Clone()
        {
            RsSmab_Slist_Scan rsSmab_Slist_Scan = new RsSmab_Slist_Scan(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Slist_Scan);
            return rsSmab_Slist_Scan;
        }
    }
}
