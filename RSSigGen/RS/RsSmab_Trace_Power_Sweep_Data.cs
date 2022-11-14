using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Data commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Trace_Power_Sweep_Data
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Data_Points _points;

        private RsSmab_Trace_Power_Sweep_Data_Xvalues _xvalues;

        private RsSmab_Trace_Power_Sweep_Data_YsValue _ysValue;

        private RsSmab_Trace_Power_Sweep_Data_Yvalues _yvalues;

        //
        // Сводка:
        //     Points commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Data_Points Points => _points ?? (_points = new RsSmab_Trace_Power_Sweep_Data_Points(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Xvalues commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Data_Xvalues Xvalues => _xvalues ?? (_xvalues = new RsSmab_Trace_Power_Sweep_Data_Xvalues(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     YsValue commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Data_YsValue YsValue => _ysValue ?? (_ysValue = new RsSmab_Trace_Power_Sweep_Data_YsValue(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Yvalues commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trace_Power_Sweep_Data_Yvalues Yvalues => _yvalues ?? (_yvalues = new RsSmab_Trace_Power_Sweep_Data_Yvalues(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Data Clone()
        {
            RsSmab_Trace_Power_Sweep_Data rsSmab_Trace_Power_Sweep_Data = new RsSmab_Trace_Power_Sweep_Data(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Data);
            return rsSmab_Trace_Power_Sweep_Data;
        }
    }
}
