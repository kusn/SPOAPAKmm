using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display_Annotation _annotation;

        //
        // Сводка:
        //     Annotation commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display_Annotation Annotation => _annotation ?? (_annotation = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display_Annotation(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Display", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display rsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display = new RsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display);
            return rsSmab_Trace_Power_Sweep_Measurement_Pulse_All_Display;
        }
    }
}
