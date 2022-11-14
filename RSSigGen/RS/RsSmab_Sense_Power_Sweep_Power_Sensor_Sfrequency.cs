using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency_State State => _state ?? (_state = new RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sfrequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency Clone()
        {
            RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency rsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency = new RsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency);
            return rsSmab_Sense_Power_Sweep_Power_Sensor_Sfrequency;
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:POWer:[SENSor]:SFRequency
        //     Defines the separate frequency used for power vs. power measurement.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   sfrequency:
        //     float Range: 0 to 1E12
        public void Set(double sfrequency)
        {
            Set(sfrequency, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:POWer:[SENSor]:SFRequency
        //     Defines the separate frequency used for power vs. power measurement.
        //
        // Параметры:
        //   sfrequency:
        //     float Range: 0 to 1E12
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double sfrequency, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:POWer:SENSor:SFRequency " + sfrequency.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:POWer:[SENSor]:SFRequency
        //     Defines the separate frequency used for power vs. power measurement.
        //     sfrequency: float Range: 0 to 1E12
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:POWer:[SENSor]:SFRequency
        //     Defines the separate frequency used for power vs. power measurement.
        //     sfrequency: float Range: 0 to 1E12
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:POWer:SENSor:SFRequency?");
        }
    }
}
