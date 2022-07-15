using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Dtime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dtime", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:DTIMe
        //     Determines the minimum time for which the signal must be below (above) the power
        //     level defined by level and hysteresis before triggering can occur again.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   dtime:
        //     float Range: 0 to 10
        public void Set(double dtime)
        {
            Set(dtime, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:DTIMe
        //     Determines the minimum time for which the signal must be below (above) the power
        //     level defined by level and hysteresis before triggering can occur again.
        //
        // Параметры:
        //   dtime:
        //     float Range: 0 to 10
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double dtime, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:DTIMe " + dtime.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:DTIMe
        //     Determines the minimum time for which the signal must be below (above) the power
        //     level defined by level and hysteresis before triggering can occur again.
        //     dtime: float Range: 0 to 10
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:DTIMe
        //     Determines the minimum time for which the signal must be below (above) the power
        //     level defined by level and hysteresis before triggering can occur again.
        //     dtime: float Range: 0 to 10
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:DTIMe?");
        }
    }
}
