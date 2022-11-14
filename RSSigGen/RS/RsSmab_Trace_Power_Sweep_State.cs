using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:STATe
        //     Activates the selected trace.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   state:
        //     OFF| ON| HOLD
        public void Set(MeasRespTraceStateEnum state)
        {
            Set(state, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:STATe
        //     Activates the selected trace.
        //
        // Параметры:
        //   state:
        //     OFF| ON| HOLD
        //
        //   trace:
        //     Repeated capability selector
        public void Set(MeasRespTraceStateEnum state, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:STATe " + state.ToScpiString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:STATe
        //     Activates the selected trace.
        //     state: OFF| ON| HOLD
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public MeasRespTraceStateEnum Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:STATe
        //     Activates the selected trace.
        //     state: OFF| ON| HOLD
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public MeasRespTraceStateEnum Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryString("TRACe" + repCapCmdValue + ":POWer:SWEep:STATe?").ToScpiEnum<MeasRespTraceStateEnum>();
        }
    }
}
