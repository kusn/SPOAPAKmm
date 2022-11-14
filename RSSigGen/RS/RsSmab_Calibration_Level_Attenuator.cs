using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Attenuator commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Calibration_Level_Attenuator
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration<HW>:LEVel:ATTenuator:MODE
        //     No additional help available
        public CalPowAttModeEnum Mode => _grpBase.IO.QueryString("CALibration<HwInstance>:LEVel:ATTenuator:MODE?").ToScpiEnum<CalPowAttModeEnum>();

        //
        // Сводка:
        //     CALibration<HW>:LEVel:ATTenuator:STAGe
        //     No additional help available
        public int Stage
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration<HwInstance>:LEVel:ATTenuator:STAGe?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration<HwInstance>:LEVel:ATTenuator:STAGe {value}");
            }
        }

        internal RsSmab_Calibration_Level_Attenuator(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Attenuator", core, parent);
        }
    }
}
