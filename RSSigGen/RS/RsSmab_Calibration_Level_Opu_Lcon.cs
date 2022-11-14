using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Opu_Lcon commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_Opu_Lcon
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:OPU:LCON:MODE
        //     No additional help available
        public CalPowOpuLconModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:OPU:LCON:MODE?").ToScpiEnum<CalPowOpuLconModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:OPU:LCON:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Level_Opu_Lcon(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lcon", core, parent);
        }
    }
}
