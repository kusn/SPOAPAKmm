using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Internal commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Pulm_Internal
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Internal_Train _train;

        //
        // Сводка:
        //     Train commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Pulm_Internal_Train Train => _train ?? (_train = new RsSmab_Source_Pulm_Internal_Train(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Pulm_Internal(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Internal", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Internal Clone()
        {
            RsSmab_Source_Pulm_Internal rsSmab_Source_Pulm_Internal = new RsSmab_Source_Pulm_Internal(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Internal);
            return rsSmab_Source_Pulm_Internal;
        }
    }
}
