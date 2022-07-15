using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Hreference commands
    //     group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Hreference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Hreference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hreference", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:HREFerence
        //     Sets the upper reference level in terms of percentage of the overall pulse level
        //     (power or voltage) . The distal power defines the end of the rising edge and
        //     the start of the falling edge of the pulse. Note: The command is only available
        //     in time measurement mode and with R&S NRPZ81 power sensors.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   hreference:
        //     float Range: 0 to 100
        public void Set(double hreference)
        {
            Set(hreference, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:HREFerence
        //     Sets the upper reference level in terms of percentage of the overall pulse level
        //     (power or voltage) . The distal power defines the end of the rising edge and
        //     the start of the falling edge of the pulse. Note: The command is only available
        //     in time measurement mode and with R&S NRPZ81 power sensors.
        //
        // Параметры:
        //   hreference:
        //     float Range: 0 to 100
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double hreference, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:HREFerence " + hreference.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:HREFerence
        //     Sets the upper reference level in terms of percentage of the overall pulse level
        //     (power or voltage) . The distal power defines the end of the rising edge and
        //     the start of the falling edge of the pulse. Note: The command is only available
        //     in time measurement mode and with R&S NRPZ81 power sensors.
        //     hreference: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:HREFerence
        //     Sets the upper reference level in terms of percentage of the overall pulse level
        //     (power or voltage) . The distal power defines the end of the rising edge and
        //     the start of the falling edge of the pulse. Note: The command is only available
        //     in time measurement mode and with R&S NRPZ81 power sensors.
        //     hreference: float Range: 0 to 100
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:HREFerence?");
        }
    }
}
