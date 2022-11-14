using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lreference", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:LREFerence
        //     Queries the lower medial threshold level of the overall pulse level. The proximal
        //     power defines the start of the rising edge and the end of the falling edge of
        //     the pulse. Note: This parameter is only avalaible in time measurement mode and
        //     R&S NRP-Z81 power sensors.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   lreference:
        //     float Range: 0.0 to 100.0
        public void Set(double lreference)
        {
            Set(lreference, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:LREFerence
        //     Queries the lower medial threshold level of the overall pulse level. The proximal
        //     power defines the start of the rising edge and the end of the falling edge of
        //     the pulse. Note: This parameter is only avalaible in time measurement mode and
        //     R&S NRP-Z81 power sensors.
        //
        // Параметры:
        //   lreference:
        //     float Range: 0.0 to 100.0
        //
        //   trace:
        //     Repeated capability selector
        public void Set(double lreference, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:LREFerence " + lreference.ToDoubleString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:LREFerence
        //     Queries the lower medial threshold level of the overall pulse level. The proximal
        //     power defines the start of the rising edge and the end of the falling edge of
        //     the pulse. Note: This parameter is only avalaible in time measurement mode and
        //     R&S NRP-Z81 power sensors.
        //     lreference: float Range: 0.0 to 100.0
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public double Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:LREFerence
        //     Queries the lower medial threshold level of the overall pulse level. The proximal
        //     power defines the start of the rising edge and the end of the falling edge of
        //     the pulse. Note: This parameter is only avalaible in time measurement mode and
        //     R&S NRP-Z81 power sensors.
        //     lreference: float Range: 0.0 to 100.0
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public double Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:LREFerence?");
        }
    }
}
