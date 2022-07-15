using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_DeviceFootprint commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_System_DeviceFootprint
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_DeviceFootprint_History _history;

        //
        // Сводка:
        //     History commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_DeviceFootprint_History History => _history ?? (_history = new RsSmab_System_DeviceFootprint_History(_grpBase.Core, _grpBase));

        internal RsSmab_System_DeviceFootprint(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("DeviceFootprint", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_DeviceFootprint Clone()
        {
            RsSmab_System_DeviceFootprint rsSmab_System_DeviceFootprint = new RsSmab_System_DeviceFootprint(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_DeviceFootprint);
            return rsSmab_System_DeviceFootprint;
        }
    }
}
