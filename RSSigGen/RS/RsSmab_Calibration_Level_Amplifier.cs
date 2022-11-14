using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Amplifier commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Calibration_Level_Amplifier
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Level_Amplifier_Stage _stage;

        //
        // Сводка:
        //     Stage commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Calibration_Level_Amplifier_Stage Stage => _stage ?? (_stage = new RsSmab_Calibration_Level_Amplifier_Stage(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Level_Amplifier(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Amplifier", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Level_Amplifier Clone()
        {
            RsSmab_Calibration_Level_Amplifier rsSmab_Calibration_Level_Amplifier = new RsSmab_Calibration_Level_Amplifier(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Level_Amplifier);
            return rsSmab_Calibration_Level_Amplifier;
        }
    }
}
