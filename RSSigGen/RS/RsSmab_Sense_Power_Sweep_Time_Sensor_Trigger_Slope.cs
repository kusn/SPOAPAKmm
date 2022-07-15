using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Slope(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Slope", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SLOPe
        //     Sets the polarity of the active slope for the trigger signals.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   triggerSlope:
        //     POSitive| NEGative
        public void Set(SlopeTypeEnum triggerSlope)
        {
            Set(triggerSlope, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SLOPe
        //     Sets the polarity of the active slope for the trigger signals.
        //
        // Параметры:
        //   triggerSlope:
        //     POSitive| NEGative
        //
        //   channel:
        //     Repeated capability selector
        public void Set(SlopeTypeEnum triggerSlope, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:SLOPe " + triggerSlope.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SLOPe
        //     Sets the polarity of the active slope for the trigger signals.
        //     triggerSlope: POSitive| NEGative
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public SlopeTypeEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:SLOPe
        //     Sets the polarity of the active slope for the trigger signals.
        //     triggerSlope: POSitive| NEGative
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public SlopeTypeEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:SLOPe?").ToScpiEnum<SlopeTypeEnum>();
        }
    }
}
