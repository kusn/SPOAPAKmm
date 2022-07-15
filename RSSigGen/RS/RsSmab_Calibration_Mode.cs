using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Mode commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Calibration_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:MODE:CONFiguration
        //     No additional help available
        public string Configuration
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:MODE:CONFiguration?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("CALibration:MODE:CONFiguration " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     CALibration:MODE
        //     No additional help available
        public CalAdjModeEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:MODE?").ToScpiEnum<CalAdjModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
