using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Device commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Test_Device
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Test_Device_Internal _internal;

        //
        // Сводка:
        //     Internal commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Test_Device_Internal Internal => _internal ?? (_internal = new RsSmab_Test_Device_Internal(_grpBase.Core, _grpBase));

        internal RsSmab_Test_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Test_Device Clone()
        {
            RsSmab_Test_Device rsSmab_Test_Device = new RsSmab_Test_Device(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Test_Device);
            return rsSmab_Test_Device;
        }
    }
}
