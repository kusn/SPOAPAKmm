using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security commands group definition
    //     Sub-classes count: 6
    //     Commands count: 1
    //     Total commands count: 17
    public class RsSmab_System_Security
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Security_Mmem _mmem;

        private RsSmab_System_Security_Network _network;

        private RsSmab_System_Security_Sanitize _sanitize;

        private RsSmab_System_Security_SuPolicy _suPolicy;

        private RsSmab_System_Security_UsbStorage _usbStorage;

        private RsSmab_System_Security_VolMode _volMode;

        //
        // Сводка:
        //     Mmem commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Mmem Mmem => _mmem ?? (_mmem = new RsSmab_System_Security_Mmem(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Network commands group
        //     Sub-classes count: 11
        //     Commands count: 0
        //     Total commands count: 11
        public RsSmab_System_Security_Network Network => _network ?? (_network = new RsSmab_System_Security_Network(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sanitize commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Sanitize Sanitize => _sanitize ?? (_sanitize = new RsSmab_System_Security_Sanitize(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SuPolicy commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Security_SuPolicy SuPolicy => _suPolicy ?? (_suPolicy = new RsSmab_System_Security_SuPolicy(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     UsbStorage commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_UsbStorage UsbStorage => _usbStorage ?? (_usbStorage = new RsSmab_System_Security_UsbStorage(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     VolMode commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_VolMode VolMode => _volMode ?? (_volMode = new RsSmab_System_Security_VolMode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:SECurity:[STATe]
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:SECurity:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SECurity:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Security(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Security", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Security Clone()
        {
            RsSmab_System_Security rsSmab_System_Security = new RsSmab_System_Security(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Security);
            return rsSmab_System_Security;
        }
    }
}
