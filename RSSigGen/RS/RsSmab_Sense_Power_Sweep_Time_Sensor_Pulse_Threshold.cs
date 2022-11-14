using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base _base;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power _power;

        //
        // Сводка:
        //     Base commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base Base => _base ?? (_base = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power Power => _power ?? (_power = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Threshold", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold Clone()
        {
            RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold = new RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold);
            return rsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold;
        }
    }
}
