using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Trapeze_High commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Trapeze_High
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Trapeze_High(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("High", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:HIGH
        //     Sets the high time for the trapezoid signal of the LF generator.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   high:
        //     float Range: 1E-6 to 100
        public void Set(double high)
        {
            Set(high, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:HIGH
        //     Sets the high time for the trapezoid signal of the LF generator.
        //
        // Параметры:
        //   high:
        //     float Range: 1E-6 to 100
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double high, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRAPeze:HIGH " + high.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:HIGH
        //     Sets the high time for the trapezoid signal of the LF generator.
        //     high: float Range: 1E-6 to 100
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:HIGH
        //     Sets the high time for the trapezoid signal of the LF generator.
        //     high: float Range: 1E-6 to 100
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRAPeze:HIGH?");
        }
    }
}
