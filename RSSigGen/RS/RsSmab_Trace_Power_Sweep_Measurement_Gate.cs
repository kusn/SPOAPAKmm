using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Gate commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Gate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Gate_Display _display;

        //
        // Сводка:
        //     Display commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Measurement_Gate_Display Display => _display ?? (_display = new RsSmab_Trace_Power_Sweep_Measurement_Gate_Display(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Gate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gate", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Gate Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Gate rsSmab_Trace_Power_Sweep_Measurement_Gate = new RsSmab_Trace_Power_Sweep_Measurement_Gate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Gate);
            return rsSmab_Trace_Power_Sweep_Measurement_Gate;
        }
    }
}
