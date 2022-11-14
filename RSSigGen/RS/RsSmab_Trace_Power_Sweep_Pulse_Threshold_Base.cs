using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse_Threshold_Base commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Pulse_Threshold_Base
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Pulse_Threshold_Base(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Base", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:BASE
        //     Queries how the threshold parameters are calculated. Note: This parameter is
        //     only avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //     baseX: VOLTage| POWer
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public MeasRespPulsThrBaseEnum Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:PULSe:THReshold:BASE
        //     Queries how the threshold parameters are calculated. Note: This parameter is
        //     only avalaible in time measurement mode and R&S NRP-Z81 power sensors.
        //     baseX: VOLTage| POWer
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public MeasRespPulsThrBaseEnum Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryString("TRACe" + repCapCmdValue + ":POWer:SWEep:PULSe:THReshold:BASE?").ToScpiEnum<MeasRespPulsThrBaseEnum>();
        }
    }
}
