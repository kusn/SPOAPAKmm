using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Sensor commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_Sense_Power_Sweep_Frequency_Sensor
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset _offset;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange _srange;

        //
        // Сводка:
        //     Offset commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset Offset => _offset ?? (_offset = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Srange commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange Srange => _srange ?? (_srange = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Frequency_Sensor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sensor", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor Clone()
        {
            RsSmab_Sense_Power_Sweep_Frequency_Sensor rsSmab_Sense_Power_Sweep_Frequency_Sensor = new RsSmab_Sense_Power_Sweep_Frequency_Sensor(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Frequency_Sensor);
            return rsSmab_Sense_Power_Sweep_Frequency_Sensor;
        }
    }
}
