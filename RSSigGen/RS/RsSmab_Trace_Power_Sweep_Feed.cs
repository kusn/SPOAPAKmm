using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Feed commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Feed
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trace_Power_Sweep_Feed(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Feed", core, parent);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:FEED
        //     Selects the source for the trace data.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   feed:
        //     SENS1| SENS2| SENS3| REFerence| NONE| SENSor1| SENSor2| SENSor3| SENS4| SENSor4
        public void Set(MeasRespTraceFeedEnum feed)
        {
            Set(feed, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:FEED
        //     Selects the source for the trace data.
        //
        // Параметры:
        //   feed:
        //     SENS1| SENS2| SENS3| REFerence| NONE| SENSor1| SENSor2| SENSor3| SENS4| SENSor4
        //
        //   trace:
        //     Repeated capability selector
        public void Set(MeasRespTraceFeedEnum feed, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:FEED " + feed.ToScpiString());
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:FEED
        //     Selects the source for the trace data.
        //     feed: SENS1| SENS2| SENS3| REFerence| NONE| SENSor1| SENSor2| SENSor3| SENS4|
        //     SENSor4
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        public MeasRespTraceFeedEnum Get()
        {
            return Get(TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:FEED
        //     Selects the source for the trace data.
        //     feed: SENS1| SENS2| SENS3| REFerence| NONE| SENSor1| SENSor2| SENSor3| SENS4|
        //     SENSor4
        //
        // Параметры:
        //   trace:
        //     Repeated capability selector
        public MeasRespTraceFeedEnum Get(TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            return _grpBase.IO.QueryString("TRACe" + repCapCmdValue + ":POWer:SWEep:FEED?").ToScpiEnum<MeasRespTraceFeedEnum>();
        }
    }
}
