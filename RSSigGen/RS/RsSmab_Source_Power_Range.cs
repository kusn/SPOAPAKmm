using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Range commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Source_Power_Range
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:RANGe:LOWer
        //     Queries the current interruption-free range of the level.
        //     lower: float Unit: dBm
        public double Lower => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:RANGe:LOWer?");

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:RANGe:MAX
        //     No additional help available
        public double Max => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:RANGe:MAX?");

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:RANGe:MIN
        //     No additional help available
        public double Min => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:RANGe:MIN?");

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:RANGe:UPPer
        //     Queries the current interruption-free range of the level.
        //     upper: float Unit: dBm
        public double Upper => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:RANGe:UPPer?");

        internal RsSmab_Source_Power_Range(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Range", core, parent);
        }
    }
}
