using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Sweep commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 12
    public class RsSmab_Source_LfOutput_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Sweep_Frequency _frequency;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 3
        //     Commands count: 7
        //     Total commands count: 12
        public RsSmab_Source_LfOutput_Sweep_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_LfOutput_Sweep_Frequency(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LfOutput_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Sweep Clone()
        {
            RsSmab_Source_LfOutput_Sweep rsSmab_Source_LfOutput_Sweep = new RsSmab_Source_LfOutput_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Sweep);
            return rsSmab_Source_LfOutput_Sweep;
        }
    }
}
