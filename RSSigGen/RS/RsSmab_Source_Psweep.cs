using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Psweep commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Psweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Psweep_Trigger _trigger;

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Psweep_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_Psweep_Trigger(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Psweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Psweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Psweep Clone()
        {
            RsSmab_Source_Psweep rsSmab_Source_Psweep = new RsSmab_Source_Psweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Psweep);
            return rsSmab_Source_Psweep;
        }
    }
}
