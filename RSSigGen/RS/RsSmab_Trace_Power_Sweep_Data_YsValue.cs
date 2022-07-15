using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Data_YsValue commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Data_YsValue
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Data_YsValue(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("YsValue", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:YSValue
        //     For a given x-axis value, queries the measurement (y-axis) value of the selected
        //     trace of the current power analysis.
        //     ysValue: float
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   xvalue:
        //     float
        public double Get(double xvalue)
        {
            return Get(xvalue, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:YSValue
        //     For a given x-axis value, queries the measurement (y-axis) value of the selected
        //     trace of the current power analysis.
        //     ysValue: float
        //
        // Параметры:
        //   xvalue:
        //     float
        //
        //   trace:
        //     Repeated capability selector
        public double Get(double xvalue, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:DATA:YSValue? " + xvalue.ToDoubleString());
        }
    }
}
