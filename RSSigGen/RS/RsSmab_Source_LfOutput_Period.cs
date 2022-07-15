using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Period commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Period
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Period(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Period", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:PERiod
        //     Queries the repetition frequency of the sine signal.
        //     lfSinePeriod: float Range: 1E-6 to 100, Unit: s
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:PERiod
        //     Queries the repetition frequency of the sine signal.
        //     lfSinePeriod: float Range: 1E-6 to 100, Unit: s
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":PERiod?");
        }
    }
}
