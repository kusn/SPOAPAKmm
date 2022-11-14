using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LffSweep commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_LffSweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LffSweep_Trigger _trigger;

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_LffSweep_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_LffSweep_Trigger(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LffSweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("LffSweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LffSweep Clone()
        {
            RsSmab_Source_LffSweep rsSmab_Source_LffSweep = new RsSmab_Source_LffSweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LffSweep);
            return rsSmab_Source_LffSweep;
        }
    }
}
