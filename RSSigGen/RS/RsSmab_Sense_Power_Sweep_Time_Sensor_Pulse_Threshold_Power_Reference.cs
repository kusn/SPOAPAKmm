using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Reference commands
    //     group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Reference
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Power_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:REFerence
        //     Sets the medial reference level in terms of percentage of the overall pulse level
        //     (power or voltage related) . This level is used to define pulse width and pulse
        //     period. Note: The command is only available in time measurement mode and with
        //     R&S NRPZ81 power sensors.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   reference:
        //     float Range: 0.0 to 100.0
        public void Set(double reference)
        {
            Set(reference, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:REFerence
        //     Sets the medial reference level in terms of percentage of the overall pulse level
        //     (power or voltage related) . This level is used to define pulse width and pulse
        //     period. Note: The command is only available in time measurement mode and with
        //     R&S NRPZ81 power sensors.
        //
        // Параметры:
        //   reference:
        //     float Range: 0.0 to 100.0
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double reference, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:REFerence " + reference.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:REFerence
        //     Sets the medial reference level in terms of percentage of the overall pulse level
        //     (power or voltage related) . This level is used to define pulse width and pulse
        //     period. Note: The command is only available in time measurement mode and with
        //     R&S NRPZ81 power sensors.
        //     reference: float Range: 0.0 to 100.0
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:POWer:REFerence
        //     Sets the medial reference level in terms of percentage of the overall pulse level
        //     (power or voltage related) . This level is used to define pulse width and pulse
        //     period. Note: The command is only available in time measurement mode and with
        //     R&S NRPZ81 power sensors.
        //     reference: float Range: 0.0 to 100.0
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:POWer:REFerence?");
        }
    }
}
