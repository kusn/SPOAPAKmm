using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_DetAtt commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_DetAtt
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:DETatt:MODE
        //     No additional help available
        public CalPowAmpDetModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:DETatt:MODE?").ToScpiEnum<CalPowAmpDetModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:DETatt:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Level_DetAtt(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("DetAtt", core, parent);
        }
    }
}
