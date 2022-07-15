using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Detector_RfLevel commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Calibration_Detector_RfLevel
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:DETector:RFLevel:EXPected
        //     No additional help available
        public double Expected => _grpBase.IO.QueryDouble("CALibration:DETector:RFLevel:EXPected?");

        //
        // Сводка:
        //     CALibration:DETector:RFLevel
        //     No additional help available
        public double Value => _grpBase.IO.QueryDouble("CALibration:DETector:RFLevel?");

        internal RsSmab_Calibration_Detector_RfLevel(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("RfLevel", core, parent);
        }
    }
}
