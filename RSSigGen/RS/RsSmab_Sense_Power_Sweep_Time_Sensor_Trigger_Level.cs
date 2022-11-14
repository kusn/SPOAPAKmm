using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Level(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Level", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:LEVel
        //     Sets the trigger threshold.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   level:
        //     float Range: -200 to 100
        public void Set(double level)
        {
            Set(level, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:LEVel
        //     Sets the trigger threshold.
        //
        // Параметры:
        //   level:
        //     float Range: -200 to 100
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double level, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:LEVel " + level.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:LEVel
        //     Sets the trigger threshold.
        //     level: float Range: -200 to 100
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:LEVel
        //     Sets the trigger threshold.
        //     level: float Range: -200 to 100
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:LEVel?");
        }
    }
}
