using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Transition commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 12
    public class RsSmab_Trace_Power_Sweep_Measurement_Transition
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative _negative;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive _positive;

        //
        // Сводка:
        //     Negative commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 6
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative Negative => _negative ?? (_negative = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Negative(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Positive commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 6
        public RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive Positive => _positive ?? (_positive = new RsSmab_Trace_Power_Sweep_Measurement_Transition_Positive(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Transition(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Transition", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Transition Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Transition rsSmab_Trace_Power_Sweep_Measurement_Transition = new RsSmab_Trace_Power_Sweep_Measurement_Transition(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Transition);
            return rsSmab_Trace_Power_Sweep_Measurement_Transition;
        }
    }
}
