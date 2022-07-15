using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Dexchange_Template commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_System_Dexchange_Template
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Dexchange_Template_Predefined _predefined;

        private RsSmab_System_Dexchange_Template_User _user;

        //
        // Сводка:
        //     Predefined commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Dexchange_Template_Predefined Predefined => _predefined ?? (_predefined = new RsSmab_System_Dexchange_Template_Predefined(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     User commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_System_Dexchange_Template_User User => _user ?? (_user = new RsSmab_System_Dexchange_Template_User(_grpBase.Core, _grpBase));

        internal RsSmab_System_Dexchange_Template(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Template", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Dexchange_Template Clone()
        {
            RsSmab_System_Dexchange_Template rsSmab_System_Dexchange_Template = new RsSmab_System_Dexchange_Template(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Dexchange_Template);
            return rsSmab_System_Dexchange_Template;
        }
    }
}
