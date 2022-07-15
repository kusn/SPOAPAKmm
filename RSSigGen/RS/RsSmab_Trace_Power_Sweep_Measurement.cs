using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement commands group definition
    //     Sub-classes count: 7
    //     Commands count: 0
    //     Total commands count: 43
    public class RsSmab_Trace_Power_Sweep_Measurement
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Fullscreen _fullscreen;

        private RsSmab_Trace_Power_Sweep_Measurement_Gate _gate;

        private RsSmab_Trace_Power_Sweep_Measurement_Marker _marker;

        private RsSmab_Trace_Power_Sweep_Measurement_Power _power;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse _pulse;

        private RsSmab_Trace_Power_Sweep_Measurement_Standard _standard;

        private RsSmab_Trace_Power_Sweep_Measurement_Transition _transition;

        //
        // Сводка:
        //     Fullscreen commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Fullscreen Fullscreen => _fullscreen ?? (_fullscreen = new RsSmab_Trace_Power_Sweep_Measurement_Fullscreen(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Gate commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Gate Gate => _gate ?? (_gate = new RsSmab_Trace_Power_Sweep_Measurement_Gate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Marker commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Marker Marker => _marker ?? (_marker = new RsSmab_Trace_Power_Sweep_Measurement_Marker(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 7
        //     Commands count: 0
        //     Total commands count: 16
        public RsSmab_Trace_Power_Sweep_Measurement_Power Power => _power ?? (_power = new RsSmab_Trace_Power_Sweep_Measurement_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 7
        //     Commands count: 0
        //     Total commands count: 11
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Trace_Power_Sweep_Measurement_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Standard commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Standard Standard => _standard ?? (_standard = new RsSmab_Trace_Power_Sweep_Measurement_Standard(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Transition commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_Trace_Power_Sweep_Measurement_Transition Transition => _transition ?? (_transition = new RsSmab_Trace_Power_Sweep_Measurement_Transition(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measurement", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement rsSmab_Trace_Power_Sweep_Measurement = new RsSmab_Trace_Power_Sweep_Measurement(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement);
            return rsSmab_Trace_Power_Sweep_Measurement;
        }
    }
}
