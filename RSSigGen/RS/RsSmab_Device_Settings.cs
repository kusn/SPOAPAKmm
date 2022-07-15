using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Device_Settings
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Device_Settings_Backup _backup;

        private RsSmab_Device_Settings_Restore _restore;

        //
        // Сводка:
        //     Backup commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Device_Settings_Backup Backup => _backup ?? (_backup = new RsSmab_Device_Settings_Backup(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Restore commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Device_Settings_Restore Restore => _restore ?? (_restore = new RsSmab_Device_Settings_Restore(_grpBase.Core, _grpBase));

        internal RsSmab_Device_Settings(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Settings", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Device_Settings Clone()
        {
            RsSmab_Device_Settings rsSmab_Device_Settings = new RsSmab_Device_Settings(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Device_Settings);
            return rsSmab_Device_Settings;
        }
    }
}
