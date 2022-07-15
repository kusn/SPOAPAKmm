using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_Sensitivity commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Source_Am_Sensitivity
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Am_Sensitivity_Exponential _exponential;

        private RsSmab_Source_Am_Sensitivity_Linear _linear;

        //
        // Сводка:
        //     Exponential commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_Sensitivity_Exponential Exponential => _exponential ?? (_exponential = new RsSmab_Source_Am_Sensitivity_Exponential(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Linear commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_Sensitivity_Linear Linear => _linear ?? (_linear = new RsSmab_Source_Am_Sensitivity_Linear(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Am_Sensitivity(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sensitivity", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Am_Sensitivity Clone()
        {
            RsSmab_Source_Am_Sensitivity rsSmab_Source_Am_Sensitivity = new RsSmab_Source_Am_Sensitivity(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Am_Sensitivity);
            return rsSmab_Source_Am_Sensitivity;
        }
    }
}
