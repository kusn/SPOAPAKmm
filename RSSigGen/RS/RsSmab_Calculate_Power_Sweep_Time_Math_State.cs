using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Math_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Math_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:MATH<CH>:STATe
        //     Activates the trace mathematics mode for "Time" measurement. This feature enables
        //     you to calculate the difference between the measurement values of two traces.
        //     For further calculation, a math result can also be assigned to a trace.
        //     Used Repeated Capabilities default values:
        //     MathRepCap.Nr1 (settable in the interface "Math")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, MathRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:MATH<CH>:STATe
        //     Activates the trace mathematics mode for "Time" measurement. This feature enables
        //     you to calculate the difference between the measurement values of two traces.
        //     For further calculation, a math result can also be assigned to a trace.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   math:
        //     Repeated capability selector
        public void Set(bool state, MathRepCap math)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(math);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:TIME:MATH" + repCapCmdValue + ":STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:MATH<CH>:STATe
        //     Activates the trace mathematics mode for "Time" measurement. This feature enables
        //     you to calculate the difference between the measurement values of two traces.
        //     For further calculation, a math result can also be assigned to a trace.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     MathRepCap.Nr1 (settable in the interface "Math")
        public bool Get()
        {
            return Get(MathRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:MATH<CH>:STATe
        //     Activates the trace mathematics mode for "Time" measurement. This feature enables
        //     you to calculate the difference between the measurement values of two traces.
        //     For further calculation, a math result can also be assigned to a trace.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   math:
        //     Repeated capability selector
        public bool Get(MathRepCap math)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(math);
            return _grpBase.IO.QueryBoolean("CALCulate:POWer:SWEep:TIME:MATH" + repCapCmdValue + ":STATe?");
        }
    }
}
