using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Pulse commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Trace_Power_Sweep_Pulse
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Pulse_Threshold _threshold;

        //
        // Сводка:
        //     Threshold commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Trace_Power_Sweep_Pulse_Threshold Threshold => _threshold ?? (_threshold = new RsSmab_Trace_Power_Sweep_Pulse_Threshold(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Pulse Clone()
        {
            RsSmab_Trace_Power_Sweep_Pulse rsSmab_Trace_Power_Sweep_Pulse = new RsSmab_Trace_Power_Sweep_Pulse(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Pulse);
            return rsSmab_Trace_Power_Sweep_Pulse;
        }
    }
}
