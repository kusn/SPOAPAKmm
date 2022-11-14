using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_List_Source commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Trigger_List_Source
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_List_Source_Advanced _advanced;

        //
        // Сводка:
        //     Advanced commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_List_Source_Advanced Advanced => _advanced ?? (_advanced = new RsSmab_Trigger_List_Source_Advanced(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_List_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_List_Source Clone()
        {
            RsSmab_Trigger_List_Source rsSmab_Trigger_List_Source = new RsSmab_Trigger_List_Source(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_List_Source);
            return rsSmab_Trigger_List_Source;
        }
    }
}
