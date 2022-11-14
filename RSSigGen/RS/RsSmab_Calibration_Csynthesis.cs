using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Csynthesis commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Csynthesis
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:CSYNthesis:[MEASure]
        //     No additional help available
        public bool Measure => _grpBase.IO.QueryBoolean("CALibration:CSYNthesis:MEASure?");

        internal RsSmab_Calibration_Csynthesis(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Csynthesis", core, parent);
        }
    }
}
