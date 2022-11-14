using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_LfOutput commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_LfOutput
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LFOutput:[MEASure]
        //     No additional help available
        public bool Measure => _grpBase.IO.QueryBoolean("CALibration:LFOutput:MEASure?");

        internal RsSmab_Calibration_LfOutput(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("LfOutput", core, parent);
        }
    }
}
