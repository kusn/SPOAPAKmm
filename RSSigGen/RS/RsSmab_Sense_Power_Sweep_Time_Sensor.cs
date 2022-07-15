using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 15
    public class RsSmab_Sense_Power_Sweep_Time_Sensor
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Offset _offset;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse _pulse;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency _sfrequency;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger _trigger;

        //
        // Сводка:
        //     Offset commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Offset Offset => _offset ?? (_offset = new RsSmab_Sense_Power_Sweep_Time_Sensor_Offset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sfrequency commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency Sfrequency => _sfrequency ?? (_sfrequency = new RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 6
        //     Commands count: 0
        //     Total commands count: 6
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Time_Sensor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sensor", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time_Sensor Clone()
        {
            RsSmab_Sense_Power_Sweep_Time_Sensor rsSmab_Sense_Power_Sweep_Time_Sensor = new RsSmab_Sense_Power_Sweep_Time_Sensor(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time_Sensor);
            return rsSmab_Sense_Power_Sweep_Time_Sensor;
        }
    }
}
