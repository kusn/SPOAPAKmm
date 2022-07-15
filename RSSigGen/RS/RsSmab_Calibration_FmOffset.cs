using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_FmOffset commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_FmOffset
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration<HW>:FMOFfset:[MEASure]
        //     No additional help available
        public bool Measure => _grpBase.IO.QueryBoolean("CALibration<HwInstance>:FMOFfset:MEASure?");

        internal RsSmab_Calibration_FmOffset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("FmOffset", core, parent);
        }
    }
}
