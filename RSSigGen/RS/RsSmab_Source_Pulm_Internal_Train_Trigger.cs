using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Internal_Train_Trigger commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Pulm_Internal_Train_Trigger
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate _immediate;

        //
        // Сводка:
        //     Immediate commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate Immediate => _immediate ?? (_immediate = new RsSmab_Source_Pulm_Internal_Train_Trigger_Immediate(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Pulm_Internal_Train_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Internal_Train_Trigger Clone()
        {
            RsSmab_Source_Pulm_Internal_Train_Trigger rsSmab_Source_Pulm_Internal_Train_Trigger = new RsSmab_Source_Pulm_Internal_Train_Trigger(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Internal_Train_Trigger);
            return rsSmab_Source_Pulm_Internal_Train_Trigger;
        }
    }
}
