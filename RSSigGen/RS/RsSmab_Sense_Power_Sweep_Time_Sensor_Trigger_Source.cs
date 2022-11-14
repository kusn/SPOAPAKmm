using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SOURce
        //     Selects if the measurement is free running (FREE) or starts only after a trigger
        //     event. The trigger can be applied internally or externally.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   source:
        //     FREE| AUTO| INTernal| EXTernal
        public void Set(MeasRespTrigModeEnum source)
        {
            Set(source, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SOURce
        //     Selects if the measurement is free running (FREE) or starts only after a trigger
        //     event. The trigger can be applied internally or externally.
        //
        // Параметры:
        //   source:
        //     FREE| AUTO| INTernal| EXTernal
        //
        //   channel:
        //     Repeated capability selector
        public void Set(MeasRespTrigModeEnum source, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SOURce
        //     Selects if the measurement is free running (FREE) or starts only after a trigger
        //     event. The trigger can be applied internally or externally.
        //     source: FREE| AUTO| INTernal| EXTernal
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public MeasRespTrigModeEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SOURce
        //     Selects if the measurement is free running (FREE) or starts only after a trigger
        //     event. The trigger can be applied internally or externally.
        //     source: FREE| AUTO| INTernal| EXTernal
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public MeasRespTrigModeEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:SOURce?").ToScpiEnum<MeasRespTrigModeEnum>();
        }
    }
}
