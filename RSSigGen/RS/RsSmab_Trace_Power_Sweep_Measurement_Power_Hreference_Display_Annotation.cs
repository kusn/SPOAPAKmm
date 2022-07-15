using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation commands
    //     group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation_State State => _state ?? (_state = new RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation_State(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Annotation", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation rsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation = new RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation);
            return rsSmab_Trace_Power_Sweep_Measurement_Power_Hreference_Display_Annotation;
        }
    }
}
