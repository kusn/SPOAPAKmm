using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Roscillator_Data commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Calibration_Roscillator_Data
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:ROSCillator:DATA:MODE
        //     No additional help available
        public CalDataModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:ROSCillator:DATA:MODE?").ToScpiEnum<CalDataModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:ROSCillator:DATA:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CALibration:ROSCillator:[DATA]
        //     No additional help available
        public int Value
        {
            get
            {
                return _grpBase.IO.QueryInt32("CALibration:ROSCillator:DATA?");
            }
            set
            {
                _grpBase.IO.Write($"CALibration:ROSCillator:DATA {value}");
            }
        }

        internal RsSmab_Calibration_Roscillator_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }
    }
}
