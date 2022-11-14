using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate commands group definition
    //     Sub-classes count: 7
    //     Commands count: 0
    //     Total commands count: 23
    public class RsSmab_System_Communicate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Communicate_Gpib _gpib;

        private RsSmab_System_Communicate_Hislip _hislip;

        private RsSmab_System_Communicate_Network _network;

        private RsSmab_System_Communicate_Scpi _scpi;

        private RsSmab_System_Communicate_Serial _serial;

        private RsSmab_System_Communicate_Socket _socket;

        private RsSmab_System_Communicate_Usb _usb;

        //
        // Сводка:
        //     Gpib commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 3
        public RsSmab_System_Communicate_Gpib Gpib => _gpib ?? (_gpib = new RsSmab_System_Communicate_Gpib(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hislip commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Hislip Hislip => _hislip ?? (_hislip = new RsSmab_System_Communicate_Hislip(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Network commands group
        //     Sub-classes count: 3
        //     Commands count: 3
        //     Total commands count: 12
        public RsSmab_System_Communicate_Network Network => _network ?? (_network = new RsSmab_System_Communicate_Network(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Scpi commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Communicate_Scpi Scpi => _scpi ?? (_scpi = new RsSmab_System_Communicate_Scpi(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Serial commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_System_Communicate_Serial Serial => _serial ?? (_serial = new RsSmab_System_Communicate_Serial(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Socket commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Socket Socket => _socket ?? (_socket = new RsSmab_System_Communicate_Socket(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Usb commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Communicate_Usb Usb => _usb ?? (_usb = new RsSmab_System_Communicate_Usb(_grpBase.Core, _grpBase));

        internal RsSmab_System_Communicate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Communicate", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Communicate Clone()
        {
            RsSmab_System_Communicate rsSmab_System_Communicate = new RsSmab_System_Communicate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Communicate);
            return rsSmab_System_Communicate;
        }
    }
}
