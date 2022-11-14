using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger commands group definition
    //     Sub-classes count: 6
    //     Commands count: 0
    //     Total commands count: 6
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto _auto;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime _dtime;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis _hysteresis;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level _level;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope _slope;

        private RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source _source;

        //
        // Сводка:
        //     Auto commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto Auto => _auto ?? (_auto = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dtime commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime Dtime => _dtime ?? (_dtime = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hysteresis commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis Hysteresis => _hysteresis ?? (_hysteresis = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Level commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level Level => _level ?? (_level = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Slope commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope Slope => _slope ?? (_slope = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source Source => _source ?? (_source = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger Clone()
        {
            RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger rsSmab_Sense_Power_Sweep_Time_Sensor_Trigger = new RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time_Sensor_Trigger);
            return rsSmab_Sense_Power_Sweep_Time_Sensor_Trigger;
        }
    }
}
