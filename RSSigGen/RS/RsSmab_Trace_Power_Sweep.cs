using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep commands group definition
    //     Sub-classes count: 6
    //     Commands count: 1
    //     Total commands count: 55
    public class RsSmab_Trace_Power_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Color _color;

        private RsSmab_Trace_Power_Sweep_Data _data;

        private RsSmab_Trace_Power_Sweep_Feed _feed;

        private RsSmab_Trace_Power_Sweep_Measurement _measurement;

        private RsSmab_Trace_Power_Sweep_Pulse _pulse;

        private RsSmab_Trace_Power_Sweep_State _state;

        //
        // Сводка:
        //     Color commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Color Color => _color ?? (_color = new RsSmab_Trace_Power_Sweep_Color(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Trace_Power_Sweep_Data Data => _data ?? (_data = new RsSmab_Trace_Power_Sweep_Data(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Feed commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Feed Feed => _feed ?? (_feed = new RsSmab_Trace_Power_Sweep_Feed(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Measurement commands group
        //     Sub-classes count: 7
        //     Commands count: 0
        //     Total commands count: 43
        public RsSmab_Trace_Power_Sweep_Measurement Measurement => _measurement ?? (_measurement = new RsSmab_Trace_Power_Sweep_Measurement(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Trace_Power_Sweep_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Trace_Power_Sweep_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_State State => _state ?? (_state = new RsSmab_Trace_Power_Sweep_State(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep Clone()
        {
            RsSmab_Trace_Power_Sweep rsSmab_Trace_Power_Sweep = new RsSmab_Trace_Power_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep);
            return rsSmab_Trace_Power_Sweep;
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COPY
        //     Stores the selected trace data as reference trace.
        //     Used Repeated Capabilities default values:
        //     TraceRepCap.Nr1 (settable in the interface "Trace")
        //
        // Параметры:
        //   copy:
        //     REFerence
        public void Copy(MeasRespTraceCopyDestEnum copy)
        {
            Copy(copy, TraceRepCap.Default);
        }

        //
        // Сводка:
        //     TRACe<CH>:[POWer]:SWEep:COPY
        //     Stores the selected trace data as reference trace.
        //
        // Параметры:
        //   copy:
        //     REFerence
        //
        //   trace:
        //     Repeated capability selector
        public void Copy(MeasRespTraceCopyDestEnum copy, TraceRepCap trace)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(trace);
            _grpBase.IO.Write("TRACe" + repCapCmdValue + ":POWer:SWEep:COPY " + copy.ToScpiString());
        }
    }
}
