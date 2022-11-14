using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Triangle_Rise commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Shape_Triangle_Rise
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Shape_Triangle_Rise(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Rise", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRIangle:RISE
        //     Selects the rise time for the triangle single of the LF generator.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   rise:
        //     float Range: 1E-6 to 100
        public void Set(double rise)
        {
            Set(rise, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRIangle:RISE
        //     Selects the rise time for the triangle single of the LF generator.
        //
        // Параметры:
        //   rise:
        //     float Range: 1E-6 to 100
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double rise, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRIangle:RISE " + rise.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRIangle:RISE
        //     Selects the rise time for the triangle single of the LF generator.
        //     rise: float Range: 1E-6 to 100
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe:TRIangle:RISE
        //     Selects the rise time for the triangle single of the LF generator.
        //     rise: float Range: 1E-6 to 100
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe:TRIangle:RISE?");
        }
    }
}
