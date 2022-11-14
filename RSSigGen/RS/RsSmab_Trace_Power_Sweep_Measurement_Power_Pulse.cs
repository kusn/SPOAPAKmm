using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Base _base;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top _top;

        //
        // Сводка:
        //     Base commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Base Base => _base ?? (_base = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Base(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Top commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top Top => _top ?? (_top = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse_Top(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse);
            return rsSmab_Trace_Power_Sweep_Measurement_Power_Pulse;
        }
    }
}
