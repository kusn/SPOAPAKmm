using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Calibration_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:FREQuency:SWPoints
        //     No additional help available
        public string SwPoints
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:FREQuency:SWPoints?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("CALibration:FREQuency:SWPoints " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     CALibration<HW>:FREQuency:[MEASure]
        //     No additional help available
        public bool Measure => _grpBase.IO.QueryBoolean("CALibration<HwInstance>:FREQuency:MEASure?");

        internal RsSmab_Calibration_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
