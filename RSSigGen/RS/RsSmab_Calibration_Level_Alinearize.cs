using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Alinearize commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_Alinearize
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:ALINearize:MODE
        //     No additional help available
        public CalPowActorLinModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:ALINearize:MODE?").ToScpiEnum<CalPowActorLinModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:ALINearize:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Level_Alinearize(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Alinearize", core, parent);
        }
    }
}
