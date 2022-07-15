using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Opu_Stage commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Calibration_Level_Opu_Stage
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:OPU:STAGe:MODE
        //     No additional help available
        public StagModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:OPU:STAGe:MODE?").ToScpiEnum<StagModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:OPU:STAGe:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CALibration:LEVel:OPU:STAGe:SUB
        //     No additional help available
        public int Sub
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:LEVel:OPU:STAGe:SUB?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:LEVel:OPU:STAGe:SUB {value}");
            }
        }

        //
        // Сводка:
        //     CALibration:LEVel:OPU:STAGe
        //     No additional help available
        public int Value
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:LEVel:OPU:STAGe?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:LEVel:OPU:STAGe {value}");
            }
        }

        internal RsSmab_Calibration_Level_Opu_Stage(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Stage", core, parent);
        }
    }
}
