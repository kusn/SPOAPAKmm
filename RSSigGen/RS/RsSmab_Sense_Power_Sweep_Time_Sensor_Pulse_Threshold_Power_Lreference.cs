using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Lreference commands
    //     group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Lreference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Lreference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lreference", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:LREFerence
        //     Sets the lower reference level in terms of percentage of the overall pulse level.
        //     The proximal power defines the start of the rising edge and the end of the falling
        //     edge of the pulse. Note: This parameter is only available in time measurement
        //     mode and R&S NRP-Z81 power sensors.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   lreference:
        //     float Range: 0.0 to 100.0
        public void Set(double lreference)
        {
            Set(lreference, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:LREFerence
        //     Sets the lower reference level in terms of percentage of the overall pulse level.
        //     The proximal power defines the start of the rising edge and the end of the falling
        //     edge of the pulse. Note: This parameter is only available in time measurement
        //     mode and R&S NRP-Z81 power sensors.
        //
        // Параметры:
        //   lreference:
        //     float Range: 0.0 to 100.0
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double lreference, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:LREFerence " + lreference.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:LREFerence
        //     Sets the lower reference level in terms of percentage of the overall pulse level.
        //     The proximal power defines the start of the rising edge and the end of the falling
        //     edge of the pulse. Note: This parameter is only available in time measurement
        //     mode and R&S NRP-Z81 power sensors.
        //     lreference: float Range: 0.0 to 100.0
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:LREFerence
        //     Sets the lower reference level in terms of percentage of the overall pulse level.
        //     The proximal power defines the start of the rising edge and the end of the falling
        //     edge of the pulse. Note: This parameter is only available in time measurement
        //     mode and R&S NRP-Z81 power sensors.
        //     lreference: float Range: 0.0 to 100.0
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:LREFerence?");
        }
    }
}
