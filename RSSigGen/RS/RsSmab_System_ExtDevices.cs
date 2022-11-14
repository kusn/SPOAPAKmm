using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_ExtDevices commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_System_ExtDevices
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_ExtDevices_Update _update;

        //
        // Сводка:
        //     Update commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 5
        public RsSmab_System_ExtDevices_Update Update => _update ?? (_update = new RsSmab_System_ExtDevices_Update(_grpBase.Core, _grpBase));

        internal RsSmab_System_ExtDevices(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("ExtDevices", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_ExtDevices Clone()
        {
            RsSmab_System_ExtDevices rsSmab_System_ExtDevices = new RsSmab_System_ExtDevices(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_ExtDevices);
            return rsSmab_System_ExtDevices;
        }
    }
}
