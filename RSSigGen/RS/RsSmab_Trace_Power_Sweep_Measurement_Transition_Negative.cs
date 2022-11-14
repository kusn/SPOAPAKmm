using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 6
    public class RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Duration _duration;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Occurrence _occurrence;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Overshoot _overshoot;

        //
        // Сводка:
        //     Duration commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Duration Duration => _duration ?? (_duration = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Duration(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Occurrence commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Occurrence Occurrence => _occurrence ?? (_occurrence = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Occurrence(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Overshoot commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Overshoot Overshoot => _overshoot ?? (_overshoot = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative_Overshoot(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Negative", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative rsSmab_Trace_Power_Sweep_Measurement_Transition_Negative = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Transition_Negative);
            return rsSmab_Trace_Power_Sweep_Measurement_Transition_Negative;
        }
    }
}
