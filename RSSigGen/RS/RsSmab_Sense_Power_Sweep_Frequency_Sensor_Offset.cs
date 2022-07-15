using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset_State State => _state ?? (_state = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Offset", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset Clone()
        {
            RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset rsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset = new RsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset);
            return rsSmab_Sense_Power_Sweep_Frequency_Sensor_Offset;
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:OFFSet
        //     Defines the level offset at the sensor input in dB. Activate the offset with
        //     the command SWEep:OFFSet:STATe.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   offset:
        //     float Range: -100 to 100
        public void Set(double offset)
        {
            Set(offset, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:OFFSet
        //     Defines the level offset at the sensor input in dB. Activate the offset with
        //     the command SWEep:OFFSet:STATe.
        //
        // Параметры:
        //   offset:
        //     float Range: -100 to 100
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double offset, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:FREQuency:SENSor:OFFSet " + offset.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:OFFSet
        //     Defines the level offset at the sensor input in dB. Activate the offset with
        //     the command SWEep:OFFSet:STATe.
        //     offset: float Range: -100 to 100
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:OFFSet
        //     Defines the level offset at the sensor input in dB. Activate the offset with
        //     the command SWEep:OFFSet:STATe.
        //     offset: float Range: -100 to 100
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:FREQuency:SENSor:OFFSet?");
        }
    }
}
