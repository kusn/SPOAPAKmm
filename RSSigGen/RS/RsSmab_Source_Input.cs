using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Input commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Source_Input
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Input_Modext _modext;

        private RsSmab_Source_Input_Trigger _trigger;

        //
        // Сводка:
        //     Modext commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Source_Input_Modext Modext => _modext ?? (_modext = new RsSmab_Source_Input_Modext(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Input_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_Input_Trigger(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Input(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Input", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Input Clone()
        {
            RsSmab_Source_Input rsSmab_Source_Input = new RsSmab_Source_Input(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Input);
            return rsSmab_Source_Input;
        }
    }
}
