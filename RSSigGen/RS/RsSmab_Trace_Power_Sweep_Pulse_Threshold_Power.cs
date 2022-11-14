using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference _hreference;

        private RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference _lreference;

        private RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference _reference;

        //
        // Сводка:
        //     Hreference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference Hreference => _hreference ?? (_hreference = new RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Hreference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Lreference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference Lreference => _lreference ?? (_lreference = new RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Lreference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference Reference => _reference ?? (_reference = new RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power_Reference(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power Clone()
        {
            RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power rsSmab_Trace_Power_Sweep_Pulse_Threshold_Power = new RsSmab_Trace_Power_Sweep_Pulse_Threshold_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Pulse_Threshold_Power);
            return rsSmab_Trace_Power_Sweep_Pulse_Threshold_Power;
        }
    }
}
