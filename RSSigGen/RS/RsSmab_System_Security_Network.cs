using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_Network commands group definition
    //     Sub-classes count: 11
    //     Commands count: 0
    //     Total commands count: 11
    public class RsSmab_System_Security_Network
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Security_Network_Avahi _avahi;

        private RsSmab_System_Security_Network_Ftp _ftp;

        private RsSmab_System_Security_Network_Http _http;

        private RsSmab_System_Security_Network_Raw _raw;

        private RsSmab_System_Security_Network_Rpc _rpc;

        private RsSmab_System_Security_Network_Smb _smb;

        private RsSmab_System_Security_Network_Soe _soe;

        private RsSmab_System_Security_Network_Ssh _ssh;

        private RsSmab_System_Security_Network_SwUpdate _swUpdate;

        private RsSmab_System_Security_Network_Vnc _vnc;

        private RsSmab_System_Security_Network_State _state;

        //
        // Сводка:
        //     Avahi commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Avahi Avahi => _avahi ?? (_avahi = new RsSmab_System_Security_Network_Avahi(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ftp commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Ftp Ftp => _ftp ?? (_ftp = new RsSmab_System_Security_Network_Ftp(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Http commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Http Http => _http ?? (_http = new RsSmab_System_Security_Network_Http(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Raw commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Raw Raw => _raw ?? (_raw = new RsSmab_System_Security_Network_Raw(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Rpc commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Rpc Rpc => _rpc ?? (_rpc = new RsSmab_System_Security_Network_Rpc(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Smb commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Smb Smb => _smb ?? (_smb = new RsSmab_System_Security_Network_Smb(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Soe commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Soe Soe => _soe ?? (_soe = new RsSmab_System_Security_Network_Soe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ssh commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Ssh Ssh => _ssh ?? (_ssh = new RsSmab_System_Security_Network_Ssh(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SwUpdate commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_SwUpdate SwUpdate => _swUpdate ?? (_swUpdate = new RsSmab_System_Security_Network_SwUpdate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Vnc commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Vnc Vnc => _vnc ?? (_vnc = new RsSmab_System_Security_Network_Vnc(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Security_Network_State State => _state ?? (_state = new RsSmab_System_Security_Network_State(_grpBase.Core, _grpBase));

        internal RsSmab_System_Security_Network(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Network", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Security_Network Clone()
        {
            RsSmab_System_Security_Network rsSmab_System_Security_Network = new RsSmab_System_Security_Network(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Security_Network);
            return rsSmab_System_Security_Network;
        }
    }
}
