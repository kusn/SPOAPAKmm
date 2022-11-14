using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Auto(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Auto", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:AUTO
        //     Sets the trigger level, the hysteresis and the dropout time to default values.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   auto:
        //     ONCE
        public void Set(MeasRespTrigAutoSetEnum auto)
        {
            Set(auto, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:AUTO
        //     Sets the trigger level, the hysteresis and the dropout time to default values.
        //
        // Параметры:
        //   auto:
        //     ONCE
        //
        //   channel:
        //     Repeated capability selector
        public void Set(MeasRespTrigAutoSetEnum auto, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:AUTO " + auto.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:AUTO
        //     Sets the trigger level, the hysteresis and the dropout time to default values.
        //     auto: ONCE
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public MeasRespTrigAutoSetEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:AUTO
        //     Sets the trigger level, the hysteresis and the dropout time to default values.
        //     auto: ONCE
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public MeasRespTrigAutoSetEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:AUTO?").ToScpiEnum<MeasRespTrigAutoSetEnum>();
        }
    }
}
