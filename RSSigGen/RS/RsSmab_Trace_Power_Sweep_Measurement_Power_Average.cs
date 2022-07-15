﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power_Average commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Trace_Power_Sweep_Measurement_Power_Average
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Average_Display _display;

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Average_Display Display => _display ?? (_display = new RsSmab_Trace_Power_Sweep_Measurement_Power_Average_Display(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Power_Average(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Average", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Average Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Power_Average rsSmab_Trace_Power_Sweep_Measurement_Power_Average = new RsSmab_Trace_Power_Sweep_Measurement_Power_Average(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Power_Average);
            return rsSmab_Trace_Power_Sweep_Measurement_Power_Average;
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:AVERage
        //     The above listed commands query the measured pulse parameter values. Note: These
        //     commands are only available in time measurement mode and with R&S NRP-Z81 power
        //     sensors.
        //     average: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public double Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:AVERage
        //     The above listed commands query the measured pulse parameter values. Note: These
        //     commands are only available in time measurement mode and with R&S NRP-Z81 power
        //     sensors.
        //     average: float Range: 0 to 100
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public double Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryDouble("TRACe" + repCapCmdValue + ":POWer:SWEep:MEASurement:POWer:AVERage?");
        }
    }
}
