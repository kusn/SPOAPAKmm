using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Modulation commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Modulation
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Modulation_All _all;

        //
        // Сводка:
        //     All commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Modulation_All All => _all ?? (_all = new RsSmab_Source_Modulation_All(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Modulation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Modulation", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Modulation Clone()
        {
            RsSmab_Source_Modulation rsSmab_Source_Modulation = new RsSmab_Source_Modulation(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Modulation);
            return rsSmab_Source_Modulation;
        }
    }
}
