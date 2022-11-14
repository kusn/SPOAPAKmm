using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_Sweep commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Trigger_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_Sweep_Source _source;

        private RsSmab_Trigger_Sweep_Immediate _immediate;

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_Sweep_Source Source => _source ?? (_source = new RsSmab_Trigger_Sweep_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Immediate commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_Sweep_Immediate Immediate => _immediate ?? (_immediate = new RsSmab_Trigger_Sweep_Immediate(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_Sweep Clone()
        {
            RsSmab_Trigger_Sweep rsSmab_Trigger_Sweep = new RsSmab_Trigger_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_Sweep);
            return rsSmab_Trigger_Sweep;
        }
    }
}
