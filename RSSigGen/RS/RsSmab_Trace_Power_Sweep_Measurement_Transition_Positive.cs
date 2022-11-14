using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 6
    public class RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Duration _duration;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Occurrence _occurrence;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Overshoot _overshoot;

        //
        // Сводка:
        //     Duration commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Duration Duration => _duration ?? (_duration = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Duration(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Occurrence commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Occurrence Occurrence => _occurrence ?? (_occurrence = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Occurrence(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Overshoot commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Overshoot Overshoot => _overshoot ?? (_overshoot = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive_Overshoot(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Positive", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive rsSmab_Trace_Power_Sweep_Measurement_Transition_Positive = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Transition_Positive);
            return rsSmab_Trace_Power_Sweep_Measurement_Transition_Positive;
        }
    }
}
