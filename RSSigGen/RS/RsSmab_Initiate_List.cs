using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate_List
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Initiate_List_Mode _mode;

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Initiate_List_Mode Mode => _mode ?? (_mode = new RsSmab_Initiate_List_Mode(_grpBase.Core, _grpBase));

        internal RsSmab_Initiate_List(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("List", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Initiate_List Clone()
        {
            RsSmab_Initiate_List rsSmab_Initiate_List = new RsSmab_Initiate_List(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Initiate_List);
            return rsSmab_Initiate_List;
        }
    }
}
