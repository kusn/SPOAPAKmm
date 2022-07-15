using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 55
    public class RsSmab_Trace_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep _sweep;

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 6
        //     Commands count: 1
        //     Total commands count: 55
        public RsSmab_Trace_Power_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Trace_Power_Sweep(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power Clone()
        {
            RsSmab_Trace_Power rsSmab_Trace_Power = new RsSmab_Trace_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power);
            return rsSmab_Trace_Power;
        }
    }
}
