using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate_Psweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Initiate_Psweep_Continuous _continuous;

        //
        // Сводка:
        //     Continuous commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Initiate_Psweep_Continuous Continuous => _continuous ?? (_continuous = new RsSmab_Initiate_Psweep_Continuous(_grpBase.Core, _grpBase));

        internal RsSmab_Initiate_Psweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Psweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Initiate_Psweep Clone()
        {
            RsSmab_Initiate_Psweep rsSmab_Initiate_Psweep = new RsSmab_Initiate_Psweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Initiate_Psweep);
            return rsSmab_Initiate_Psweep;
        }
    }
}
