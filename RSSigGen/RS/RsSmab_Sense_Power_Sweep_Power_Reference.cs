using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power_Reference commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_Power_Reference
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Power_Reference_Data _data;

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Power_Reference_Data Data => _data ?? (_data = new RsSmab_Sense_Power_Sweep_Power_Reference_Data(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Power_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Power_Reference Clone()
        {
            RsSmab_Sense_Power_Sweep_Power_Reference rsSmab_Sense_Power_Sweep_Power_Reference = new RsSmab_Sense_Power_Sweep_Power_Reference(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Power_Reference);
            return rsSmab_Sense_Power_Sweep_Power_Reference;
        }
    }
}
