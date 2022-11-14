using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Combined commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Source_Combined
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Combined_Frequency _frequency;

        private RsSmab_Source_Combined_Power _power;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Combined_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Combined_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Combined_Power Power => _power ?? (_power = new RsSmab_Source_Combined_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Combined(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Combined", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Combined Clone()
        {
            RsSmab_Source_Combined rsSmab_Source_Combined = new RsSmab_Source_Combined(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Combined);
            return rsSmab_Source_Combined;
        }
    }
}
