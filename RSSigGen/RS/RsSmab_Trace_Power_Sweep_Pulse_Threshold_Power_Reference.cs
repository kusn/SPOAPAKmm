using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:REFerence
        //     Queries the medial threshold level of the overall pulse level. This level is
        //     used to define the pulse width and pulse period. Note: This parameter is only
        //     avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   reference:
        //     float Range: 0.0 to 100.0
        public void Set(double reference)
        {
            Set(reference, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:REFerence
        //     Queries the medial threshold level of the overall pulse level. This level is
        //     used to define the pulse width and pulse period. Note: This parameter is only
        //     avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //
        // Параметры:
        //   reference:
        //     float Range: 0.0 to 100.0
        //
        //   trace:
        //     Repeated capability selector
        public void Set(double reference, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:REFerence " + reference.ToDoubleString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:REFerence
        //     Queries the medial threshold level of the overall pulse level. This level is
        //     used to define the pulse width and pulse period. Note: This parameter is only
        //     avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //     reference: float Range: 0.0 to 100.0
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public double Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:POWer:REFerence
        //     Queries the medial threshold level of the overall pulse level. This level is
        //     used to define the pulse width and pulse period. Note: This parameter is only
        //     avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //     reference: float Range: 0.0 to 100.0
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public double Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:POWer:REFerence?");
        }
    }
}
