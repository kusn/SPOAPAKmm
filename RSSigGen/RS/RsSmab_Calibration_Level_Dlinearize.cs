using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Dlinearize commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_Dlinearize
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:DLINearize:MODE
        //     No additional help available
        public CalPowDetLinModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:DLINearize:MODE?").ToScpiEnum<CalPowDetLinModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:DLINearize:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Level_Dlinearize(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dlinearize", core, parent);
        }
    }
}
