using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_Network_Http commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_System_Security_Network_Http
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Security_Network_Http_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Security_Network_Http_State State => _state ?? (_state = new RsSmab_System_Security_Network_Http_State(_grpBase.Core, _grpBase));

        internal RsSmab_System_Security_Network_Http(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Http", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Security_Network_Http Clone()
        {
            RsSmab_System_Security_Network_Http rsSmab_System_Security_Network_Http = new RsSmab_System_Security_Network_Http(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Security_Network_Http);
            return rsSmab_System_Security_Network_Http;
        }
    }
}
