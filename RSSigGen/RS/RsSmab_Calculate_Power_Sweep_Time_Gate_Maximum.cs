using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate_Maximum
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Gate_Maximum(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Maximum", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:MAXimum
        //     Queries the average power value of the time gated measurement.
        //     maximum: float Range: -1000 to 1000
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        public double Get()
        {
            return Get(GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:MAXimum
        //     Queries the average power value of the time gated measurement.
        //     maximum: float Range: -1000 to 1000
        //
        // Параметры:
        //   gate:
        //     Repeated capability selector
        public double Get(GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            return _grpBase.IO.QueryDouble("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":MAXimum?");
        }
    }
}
