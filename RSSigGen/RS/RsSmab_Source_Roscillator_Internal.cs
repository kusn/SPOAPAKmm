using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Internal commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Source_Roscillator_Internal
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Roscillator_Internal_Tuning _tuning;

        private RsSmab_Source_Roscillator_Internal_Adjust _adjust;

        //
        // Сводка:
        //     Tuning commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Roscillator_Internal_Tuning Tuning => _tuning ?? (_tuning = new RsSmab_Source_Roscillator_Internal_Tuning(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Adjust commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Roscillator_Internal_Adjust Adjust => _adjust ?? (_adjust = new RsSmab_Source_Roscillator_Internal_Adjust(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Roscillator_Internal(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Internal", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Roscillator_Internal Clone()
        {
            RsSmab_Source_Roscillator_Internal rsSmab_Source_Roscillator_Internal = new RsSmab_Source_Roscillator_Internal(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Roscillator_Internal);
            return rsSmab_Source_Roscillator_Internal;
        }
    }
}
