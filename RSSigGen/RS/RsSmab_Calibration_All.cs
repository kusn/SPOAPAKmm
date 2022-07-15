using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_All commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Calibration_All
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_All_Measure _measure;

        //
        // Сводка:
        //     Measure commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_All_Measure Measure => _measure ?? (_measure = new RsSmab_Calibration_All_Measure(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_All(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("All", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_All Clone()
        {
            RsSmab_Calibration_All rsSmab_Calibration_All = new RsSmab_Calibration_All(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_All);
            return rsSmab_Calibration_All;
        }
    }
}
