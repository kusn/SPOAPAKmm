using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate_Feed
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calculate_Power_Sweep_Time_Gate_Feed(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Feed", core, parent);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:FEED
        //     Selects the trace for time gated measurement. Both gates are assigned to the
        //     same trace.
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        //
        // Параметры:
        //   feed:
        //     TRAC1| TRAC2| TRAC3| TRACe1| TRACe2| TRACe3| TRAC4| TRACe4
        public void Set(MeasRespTimeGateEnum feed)
        {
            Set(feed, GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:FEED
        //     Selects the trace for time gated measurement. Both gates are assigned to the
        //     same trace.
        //
        // Параметры:
        //   feed:
        //     TRAC1| TRAC2| TRAC3| TRACe1| TRACe2| TRACe3| TRAC4| TRACe4
        //
        //   gate:
        //     Repeated capability selector
        public void Set(MeasRespTimeGateEnum feed, GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            _grpBase.IO.Write("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":FEED " + feed.ToScpiString());
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:FEED
        //     Selects the trace for time gated measurement. Both gates are assigned to the
        //     same trace.
        //     feed: TRAC1| TRAC2| TRAC3| TRACe1| TRACe2| TRACe3| TRAC4| TRACe4
        //     Used Repeated Capabilities default values:
        //     GateRepCap.Nr1 (settable in the interface "Gate")
        public MeasRespTimeGateEnum Get()
        {
            return Get(GateRepCap.Default);
        }

        //
        // Сводка:
        //     CALCulate:[POWer]:SWEep:TIME:GATE<CH>:FEED
        //     Selects the trace for time gated measurement. Both gates are assigned to the
        //     same trace.
        //     feed: TRAC1| TRAC2| TRAC3| TRACe1| TRACe2| TRACe3| TRAC4| TRACe4
        //
        // Параметры:
        //   gate:
        //     Repeated capability selector
        public MeasRespTimeGateEnum Get(GateRepCap gate)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(gate);
            return _grpBase.IO.QueryString("CALCulate:POWer:SWEep:TIME:GATE" + repCapCmdValue + ":FEED?").ToScpiEnum<MeasRespTimeGateEnum>();
        }
    }
}
