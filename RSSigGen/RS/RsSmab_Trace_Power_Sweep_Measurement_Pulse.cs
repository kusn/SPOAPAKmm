using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Pulse commands group definition
    //     Sub-classes count: 7
    //     Commands count: 0
    //     Total commands count: 11
    public class RsSmab_Trace_Power_Sweep_Measurement_Pulse
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_All _all;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_Dcycle _dcycle;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display _display;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_Duration _duration;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_Period _period;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_Separation _separation;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_State _state;

        //
        // Сводка:
        //     All commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_All All => _all ?? (_all = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_All(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dcycle commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_Dcycle Dcycle => _dcycle ?? (_dcycle = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_Dcycle(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display Display => _display ?? (_display = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Duration commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_Duration Duration => _duration ?? (_duration = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_Duration(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Period commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_Period Period => _period ?? (_period = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_Period(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Separation commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_Separation Separation => _separation ?? (_separation = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_Separation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_State State => _state ?? (_state = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_State(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Pulse rsSmab_Trace_Power_Sweep_Measurement_Pulse = new RsSmab_Trace_Power_Sweep_Measurement_Pulse(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Pulse);
            return rsSmab_Trace_Power_Sweep_Measurement_Pulse;
        }
    }
}
