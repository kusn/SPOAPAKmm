using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Tselected commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Calibration_Tselected
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:TSELected:CATalog
        //     No additional help available
        public string Catalog => _grpBase.IO.QueryString("CALibration:TSELected:CATalog?").TrimStringResponse();

        //
        // Сводка:
        //     CALibration:TSELected:STEP
        //     No additional help available
        public string Step
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:TSELected:STEP?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("CALibration:TSELected:STEP " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     CALibration:TSELected:[MEASure]
        //     No additional help available
        public bool Measure => _grpBase.IO.QueryBoolean("CALibration:TSELected:MEASure?");

        internal RsSmab_Calibration_Tselected(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Tselected", core, parent);
        }
    }
}
