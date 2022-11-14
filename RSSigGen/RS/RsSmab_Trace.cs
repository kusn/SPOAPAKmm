using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 55
    //     Repeated Capability: TraceRepCap, default value after init: TraceRepCap.Nr1
    public class RsSmab_Trace
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power _power;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to TraceRepCap.Default
        //     Default value after init: TraceRepCap.Nr1
        public TraceRepCap RepCapTrace
        {
            get
            {
                return (TraceRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 55
        public RsSmab_Trace_Power Power => _power ?? (_power = new RsSmab_Trace_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Trace(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trace", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(TraceRepCap), _grpBase.GroupName, "RepCapTrace", TraceRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace Clone()
        {
            RsSmab_Trace rsSmab_Trace = new RsSmab_Trace(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace);
            return rsSmab_Trace;
        }
    }
}
