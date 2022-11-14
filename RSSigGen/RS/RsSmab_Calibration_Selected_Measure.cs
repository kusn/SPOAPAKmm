using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Selected_Measure commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Selected_Measure
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calibration_Selected_Measure(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measure", core, parent);
        }

        //
        // Сводка:
        //     CALibration:SELected:[MEASure]
        //     No additional help available
        public TestCalSelectedEnum Get(string toTestArgs)
        {
            return _grpBase.IO.QueryString("CALibration:SELected:MEASure? " + toTestArgs.EncloseByQuotes()).ToScpiEnum<TestCalSelectedEnum>();
        }
    }
}
