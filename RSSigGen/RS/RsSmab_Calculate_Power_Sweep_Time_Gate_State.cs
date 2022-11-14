using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Gate_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STATe
        //     Activates the gate settings for the selected trace. The measurement is started
        //     with command SENS:POW:INIT. Both gates are active at one time.
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STATe
        //     Activates the gate settings for the selected trace. The measurement is started
        //     with command SENS:POW:INIT. Both gates are active at one time.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   gate:
        //     Repeated capability selector
        public void Set(bool state, GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STATe
        //     Activates the gate settings for the selected trace. The measurement is started
        //     with command SENS:POW:INIT. Both gates are active at one time.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        public bool Get()
        {
            return Get(GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STATe
        //     Activates the gate settings for the selected trace. The measurement is started
        //     with command SENS:POW:INIT. Both gates are active at one time.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   gate:
        //     Repeated capability selector
        public bool Get(GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            return _grpBase.IO.QueryBoolean("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STATe?");
        }
    }
}
