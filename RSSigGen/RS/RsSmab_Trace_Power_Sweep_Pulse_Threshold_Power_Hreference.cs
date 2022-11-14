using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hreference", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:HREFerence
        //     Queries the upper threshold level of the overall pulse level. The distal power
        //     defines the end of the rising edge and the start of the falling edge of the pulse.
        //     Note: This parameter is only avalaible in time measurement mode and R&S NRP-Z81
        //     power sensors.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   hreference:
        //     float Range: 0.0 to 100.0
        public void Set(double hreference)
        {
            Set(hreference, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:HREFerence
        //     Queries the upper threshold level of the overall pulse level. The distal power
        //     defines the end of the rising edge and the start of the falling edge of the pulse.
        //     Note: This parameter is only avalaible in time measurement mode and R&S NRP-Z81
        //     power sensors.
        //
        // Параметры:
        //   hreference:
        //     float Range: 0.0 to 100.0
        //
        //   trace:
        //     Repeated capability selector
        public void Set(double hreference, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:HREFerence " + hreference.ToDoubleString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:HREFerence
        //     Queries the upper threshold level of the overall pulse level. The distal power
        //     defines the end of the rising edge and the start of the falling edge of the pulse.
        //     Note: This parameter is only avalaible in time measurement mode and R&S NRP-Z81
        //     power sensors.
        //     hreference: float Range: 0.0 to 100.0
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public double Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:HREFerence
        //     Queries the upper threshold level of the overall pulse level. The distal power
        //     defines the end of the rising edge and the start of the falling edge of the pulse.
        //     Note: This parameter is only avalaible in time measurement mode and R&S NRP-Z81
        //     power sensors.
        //     hreference: float Range: 0.0 to 100.0
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public double Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:HREFerence?");
        }
    }
}
