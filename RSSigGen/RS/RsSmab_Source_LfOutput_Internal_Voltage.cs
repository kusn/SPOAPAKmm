using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Internal_Voltage commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_Internal_Voltage
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_Internal_Voltage(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Voltage", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:INTernal:VOLTage
        //     Sets the output voltage for the LF generators. The sum of both values must not
        //     exceed the overall output voltage, set with command [:SOURce]:LFOutput:VOLTage.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   voltage:
        //     float Range: 0 to 4
        public void Set(double voltage)
        {
            Set(voltage, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:INTernal:VOLTage
        //     Sets the output voltage for the LF generators. The sum of both values must not
        //     exceed the overall output voltage, set with command [:SOURce]:LFOutput:VOLTage.
        //
        // Параметры:
        //   voltage:
        //     float Range: 0 to 4
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(double voltage, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce:LFOutput" + repCapCmdValue + ":INTernal:VOLTage " + voltage.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:INTernal:VOLTage
        //     Sets the output voltage for the LF generators. The sum of both values must not
        //     exceed the overall output voltage, set with command [:SOURce]:LFOutput:VOLTage.
        //     voltage: float Range: 0 to 4
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public double Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:INTernal:VOLTage
        //     Sets the output voltage for the LF generators. The sum of both values must not
        //     exceed the overall output voltage, set with command [:SOURce]:LFOutput:VOLTage.
        //     voltage: float Range: 0 to 4
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public double Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryDouble("SOURce:LFOutput" + repCapCmdValue + ":INTernal:VOLTage?");
        }
    }
}
