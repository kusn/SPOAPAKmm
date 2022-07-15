using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Trapeze_Fall commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Trapeze_Fall
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Trapeze_Fall(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Fall", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:FALL
        //     Selects the fall time for the trapezoid shape of the LF generator.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   fall:
        //     float Range: 1E-6 to 100
        public void Set(double fall)
        {
            Set(fall, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:FALL
        //     Selects the fall time for the trapezoid shape of the LF generator.
        //
        // Параметры:
        //   fall:
        //     float Range: 1E-6 to 100
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double fall, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRAPeze:FALL " + fall.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:FALL
        //     Selects the fall time for the trapezoid shape of the LF generator.
        //     fall: float Range: 1E-6 to 100
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRAPeze:FALL
        //     Selects the fall time for the trapezoid shape of the LF generator.
        //     fall: float Range: 1E-6 to 100
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRAPeze:FALL?");
        }
    }
}
