using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate_Stop
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Gate_Stop(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Stop", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STOP
        //     Sets the start time of the selected gate. Insert value and unit.
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        //
        // Параметры:
        //   stop:
        //     float
        public void Set(double stop)
        {
            Set(stop, GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STOP
        //     Sets the start time of the selected gate. Insert value and unit.
        //
        // Параметры:
        //   stop:
        //     float
        //
        //   gate:
        //     Repeated capability selector
        public void Set(double stop, GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STOP " + stop.ToDoubleString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STOP
        //     Sets the start time of the selected gate. Insert value and unit.
        //     stop: float
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        public double Get()
        {
            return Get(GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STOP
        //     Sets the start time of the selected gate. Insert value and unit.
        //     stop: float
        //
        // Параметры:
        //   gate:
        //     Repeated capability selector
        public double Get(GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            return _grpBase.IO.QueryDouble("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STOP?");
        }
    }
}
