using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_State _state;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold _threshold;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_State State => _state ?? (_state = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Threshold commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold Threshold => _threshold ?? (_threshold = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse Clone()
        {
            RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse);
            return rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse;
        }
    }
}
