using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display _display;

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display Display => _display ?? (_display = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Top", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top);
            return rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top;
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP
        //     The above listed commands query the measured pulse parameter values. Note: These
        //     commands are only available in time measurement mode and with R&S NRP-Z81 power
        //     sensors.
        //     top: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public double Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP
        //     The above listed commands query the measured pulse parameter values. Note: These
        //     commands are only available in time measurement mode and with R&S NRP-Z81 power
        //     sensors.
        //     top: float Range: 0 to 100
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public double Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:MEASurement:POWer:PULSe:TOP?");
        }
    }
}
