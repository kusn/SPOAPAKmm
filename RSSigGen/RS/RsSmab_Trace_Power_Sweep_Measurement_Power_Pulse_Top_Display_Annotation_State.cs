using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display_Annotation_State
    //     commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display_Annotation_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top_Display_Annotation_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:[STATe]
        //     The above listed commands select the pulse parameters which are indicated in
        //     the display and hardcopy file. Only six parameters can be indicated at a time.
        //     Note: These commands are only available in time measurement mode and with R&S
        //     NRP-Z81 power sensors.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:[STATe]
        //     The above listed commands select the pulse parameters which are indicated in
        //     the display and hardcopy file. Only six parameters can be indicated at a time.
        //     Note: These commands are only available in time measurement mode and with R&S
        //     NRP-Z81 power sensors.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   trace:
        //     Repeated capability selector
        public void Set(bool state, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:[STATe]
        //     The above listed commands select the pulse parameters which are indicated in
        //     the display and hardcopy file. Only six parameters can be indicated at a time.
        //     Note: These commands are only available in time measurement mode and with R&S
        //     NRP-Z81 power sensors.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public bool Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:[STATe]
        //     The above listed commands select the pulse parameters which are indicated in
        //     the display and hardcopy file. Only six parameters can be indicated at a time.
        //     Note: These commands are only available in time measurement mode and with R&S
        //     NRP-Z81 power sensors.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public bool Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryBoolean("TRACe" + repCapCmdValue + ":POWer:SWEep:MEASurement:POWer:PULSe:TOP:DISPlay:ANNotation:STATe?");
        }
    }
}
