using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Pulse_Period commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Pulse_Period
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Pulse_Period(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Period", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:PERiod
        //     Sets the period of the generated pulse. The period determines the repetition
        //     frequency of the internal signal.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   period:
        //     float Range: 1E-6 to 100
        public void Set(double period)
        {
            Set(period, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:PERiod
        //     Sets the period of the generated pulse. The period determines the repetition
        //     frequency of the internal signal.
        //
        // Параметры:
        //   period:
        //     float Range: 1E-6 to 100
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double period, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:PERiod " + period.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:PERiod
        //     Sets the period of the generated pulse. The period determines the repetition
        //     frequency of the internal signal.
        //     period: float Range: 1E-6 to 100
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:PULSe:PERiod
        //     Sets the period of the generated pulse. The period determines the repetition
        //     frequency of the internal signal.
        //     period: float Range: 1E-6 to 100
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:PULSe:PERiod?");
        }
    }
}
