using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Data_Yvalues commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Data_Yvalues
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Data_Yvalues(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Yvalues", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:YVALues
        //     Queries the measurement (y-axis) values of the selected trace of the current
        //     power analysis.
        //     yvalues: string
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public List<double> Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:YVALues
        //     Queries the measurement (y-axis) values of the selected trace of the current
        //     power analysis.
        //     yvalues: string
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public List<double> Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryBinaryOrAsciiFloatArray("TRACe" + repCapCmdValue + ":POWer:SWEep:DATA:YVALues?").ToList();
        }
    }
}
