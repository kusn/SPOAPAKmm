using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Status commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Status
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Status_Device _device;

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Status_Device Device => _device ?? (_device = new RsSmab_Sense_Power_Status_Device(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Status(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Status", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Status Clone()
        {
            RsSmab_Sense_Power_Status rsSmab_Sense_Power_Status = new RsSmab_Sense_Power_Status(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Status);
            return rsSmab_Sense_Power_Status;
        }
    }
}
