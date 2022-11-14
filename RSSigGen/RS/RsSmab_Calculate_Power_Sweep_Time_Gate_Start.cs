using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate_Start
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Gate_Start(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Start", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STARt
        //     Sets the start time of the selected gate. Insert value and unit.
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        //
        // Параметры:
        //   start:
        //     float
        public void Set(double start)
        {
            Set(start, GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STARt
        //     Sets the start time of the selected gate. Insert value and unit.
        //
        // Параметры:
        //   start:
        //     float
        //
        //   gate:
        //     Repeated capability selector
        public void Set(double start, GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STARt " + start.ToDoubleString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STARt
        //     Sets the start time of the selected gate. Insert value and unit.
        //     start: No help available
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        public double Get()
        {
            return Get(GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:STARt
        //     Sets the start time of the selected gate. Insert value and unit.
        //     start: No help available
        //
        // Параметры:
        //   gate:
        //     Repeated capability selector
        public double Get(GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            return _grpBase.IO.QueryDouble("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":STARt?");
        }
    }
}
