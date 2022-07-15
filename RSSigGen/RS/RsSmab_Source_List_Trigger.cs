using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Trigger commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Source_List_Trigger
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_List_Trigger_Execute _execute;

        private RsSmab_Source_List_Trigger_Source _source;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_List_Trigger_Execute Execute => _execute ?? (_execute = new RsSmab_Source_List_Trigger_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_List_Trigger_Source Source => _source ?? (_source = new RsSmab_Source_List_Trigger_Source(_grpBase.Core, _grpBase));

        internal RsSmab_Source_List_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_List_Trigger Clone()
        {
            RsSmab_Source_List_Trigger rsSmab_Source_List_Trigger = new RsSmab_Source_List_Trigger(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_List_Trigger);
            return rsSmab_Source_List_Trigger;
        }
    }
}
