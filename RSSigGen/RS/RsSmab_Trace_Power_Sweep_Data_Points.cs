using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Data_Points commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Data_Points
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Data_Points(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Points", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:POINts
        //     Queries the number of measurement points of the selected trace of the current
        //     power analysis.
        //     points: integer Range: 10 to 1000
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public int Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:POINts
        //     Queries the number of measurement points of the selected trace of the current
        //     power analysis.
        //     points: integer Range: 10 to 1000
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public int Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryInt32("TRACe" + repCapCmdValue + ":POWer:SWEep:DATA:POINts?");
        }
    }
}
