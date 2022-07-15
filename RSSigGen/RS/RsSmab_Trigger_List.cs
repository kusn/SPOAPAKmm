using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_List commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Trigger_List
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_List_Source _source;

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trigger_List_Source Source => _source ?? (_source = new RsSmab_Trigger_List_Source(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_List(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("List", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_List Clone()
        {
            RsSmab_Trigger_List rsSmab_Trigger_List = new RsSmab_Trigger_List(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_List);
            return rsSmab_Trigger_List;
        }
    }
}
