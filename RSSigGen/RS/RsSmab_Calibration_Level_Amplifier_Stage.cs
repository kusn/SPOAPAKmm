using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Amplifier_Stage commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Calibration_Level_Amplifier_Stage
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:AMPLifier:STAGe:FREQuenz
        //     No additional help available
        public int Frequency
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:LEVel:AMPLifier:STAGe:FREQuenz?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:LEVel:AMPLifier:STAGe:FREQuenz {value}");
            }
        }

        //
        // Сводка:
        //     CALibration:LEVel:AMPLifier:STAGe:MODE
        //     No additional help available
        public StagModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:AMPLifier:STAGe:MODE?").ToScpiEnum<StagModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:AMPLifier:STAGe:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CALibration:LEVel:AMPLifier:STAGe:SUB
        //     No additional help available
        public int Sub
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:LEVel:AMPLifier:STAGe:SUB?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:LEVel:AMPLifier:STAGe:SUB {value}");
            }
        }

        //
        // Сводка:
        //     CALibration:LEVel:AMPLifier:STAGe
        //     No additional help available
        public int Value
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:LEVel:AMPLifier:STAGe?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:LEVel:AMPLifier:STAGe {value}");
            }
        }

        internal RsSmab_Calibration_Level_Amplifier_Stage(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Stage", core, parent);
        }
    }
}
