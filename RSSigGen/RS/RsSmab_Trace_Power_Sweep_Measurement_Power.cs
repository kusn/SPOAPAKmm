using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Power commands group definition
    //     Sub-classes count: 7
    //     Commands count: 0
    //     Total commands count: 16
    public class RsSmab_Trace_Power_Sweep_Measurement_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Average _average;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference _hreference;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Lreference _lreference;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Maximum _maximum;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Minimum _minimum;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse _pulse;

        private RsSmab_Trace_Power_Sweep_Measurement_Power_Reference _reference;

        //
        // Сводка:
        //     Average commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Average Average => _average ?? (_average = new RsSmab_Trace_Power_Sweep_Measurement_Power_Average(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hreference commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference Hreference => _hreference ?? (_hreference = new RsSmab_Trace_Power_Sweep_Measurement_Power_Hreference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Lreference commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Lreference Lreference => _lreference ?? (_lreference = new RsSmab_Trace_Power_Sweep_Measurement_Power_Lreference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Maximum commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Maximum Maximum => _maximum ?? (_maximum = new RsSmab_Trace_Power_Sweep_Measurement_Power_Maximum(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Minimum commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Minimum Minimum => _minimum ?? (_minimum = new RsSmab_Trace_Power_Sweep_Measurement_Power_Minimum(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Trace_Power_Sweep_Measurement_Power_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Trace_Power_Sweep_Measurement_Power_Reference Reference => _reference ?? (_reference = new RsSmab_Trace_Power_Sweep_Measurement_Power_Reference(_grpBase.Core, _grpBase));

        internal RsSmab_Trace_Power_Sweep_Measurement_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trace_Power_Sweep_Measurement_Power Clone()
        {
            RsSmab_Trace_Power_Sweep_Measurement_Power rsSmab_Trace_Power_Sweep_Measurement_Power = new RsSmab_Trace_Power_Sweep_Measurement_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trace_Power_Sweep_Measurement_Power);
            return rsSmab_Trace_Power_Sweep_Measurement_Power;
        }
    }
}
