using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Data_Xvalues commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Data_Xvalues
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Data_Xvalues(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Xvalues", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:XVALues
        //     Queries the x-axis values - frequency, power or time values - of the selected
        //     trace of the current power analysis.
        //     xvalues: string
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public List<double> Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:DATA:XVALues
        //     Queries the x-axis values - frequency, power or time values - of the selected
        //     trace of the current power analysis.
        //     xvalues: string
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public List<double> Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryBinaryOrAsciiFloatArray("TRACe" + repCapCmdValue + ":POWer:SWEep:DATA:XVALues?").ToList();
        }
    }
}
