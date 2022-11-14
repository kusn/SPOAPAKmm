using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Opu commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Calibration_Level_Opu
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Level_Opu_Lcon _lcon;

        private RsSmab_Calibration_Level_Opu_Stage _stage;

        //
        // Сводка:
        //     Lcon commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_Opu_Lcon Lcon => _lcon ?? (_lcon = new RsSmab_Calibration_Level_Opu_Lcon(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Stage commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Calibration_Level_Opu_Stage Stage => _stage ?? (_stage = new RsSmab_Calibration_Level_Opu_Stage(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Level_Opu(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Opu", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Level_Opu Clone()
        {
            RsSmab_Calibration_Level_Opu rsSmab_Calibration_Level_Opu = new RsSmab_Calibration_Level_Opu(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Level_Opu);
            return rsSmab_Calibration_Level_Opu;
        }
    }
}
