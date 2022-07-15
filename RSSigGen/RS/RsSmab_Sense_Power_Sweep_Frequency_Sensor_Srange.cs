using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start _start;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Stop _stop;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_State _state;

        //
        // Сводка:
        //     Start commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start Start => _start ?? (_start = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Stop commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Stop Stop => _stop ?? (_stop = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Stop(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_State State => _state ?? (_state = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Srange", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange Clone()
        {
            RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange rsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange);
            return rsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange;
        }
    }
}
