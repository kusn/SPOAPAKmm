using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Detector commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Calibration_Detector
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Detector_RfLevel _rfLevel;

        //
        // Сводка:
        //     RfLevel commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Calibration_Detector_RfLevel RfLevel => _rfLevel ?? (_rfLevel = new RsSmab_Calibration_Detector_RfLevel(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Detector(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Detector", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Detector Clone()
        {
            RsSmab_Calibration_Detector rsSmab_Calibration_Detector = new RsSmab_Calibration_Detector(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Detector);
            return rsSmab_Calibration_Detector;
        }
    }
}
