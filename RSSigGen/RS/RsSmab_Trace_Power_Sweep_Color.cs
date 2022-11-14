using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Color commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Color
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Color(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Color", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COLor
        //     Defines the color of a trace.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   color:
        //     INVers| GRAY| YELLow| BLUE| GREen| RED| MAGenta
        public void Set(MeasRespTraceColorEnum color)
        {
            Set(color, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COLor
        //     Defines the color of a trace.
        //
        // Параметры:
        //   color:
        //     INVers| GRAY| YELLow| BLUE| GREen| RED| MAGenta
        //
        //   trace:
        //     Repeated capability selector
        public void Set(MeasRespTraceColorEnum color, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:COLor " + color.ToScpiString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COLor
        //     Defines the color of a trace.
        //     color: INVers| GRAY| YELLow| BLUE| GREen| RED| MAGenta
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public MeasRespTraceColorEnum Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COLor
        //     Defines the color of a trace.
        //     color: INVers| GRAY| YELLow| BLUE| GREen| RED| MAGenta
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public MeasRespTraceColorEnum Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryString("TRACe" + repCapCmdValue + ":POWer:SWEep:COLor?").ToScpiEnum<MeasRespTraceColorEnum>();
        }
    }
}
