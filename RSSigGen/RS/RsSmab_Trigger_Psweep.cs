using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_Psweep commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Trigger_Psweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_Psweep_Source _source;

        private RsSmab_Trigger_Psweep_Immediate _immediate;

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trigger_Psweep_Source Source => _source ?? (_source = new RsSmab_Trigger_Psweep_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Immediate commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_Psweep_Immediate Immediate => _immediate ?? (_immediate = new RsSmab_Trigger_Psweep_Immediate(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_Psweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Psweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_Psweep Clone()
        {
            RsSmab_Trigger_Psweep rsSmab_Trigger_Psweep = new RsSmab_Trigger_Psweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_Psweep);
            return rsSmab_Trigger_Psweep;
        }
    }
}
