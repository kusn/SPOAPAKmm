using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Trigger_Hysteresis(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hysteresis", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:HYSTeresis
        //     Sets the hysteresis of the internal trigger threshold. Hysteresis is the magnitude
        //     (in dB) the trigger signal level must drop below the trigger threshold (positive
        //     trigger slope) before triggering can occur again.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   hysteresis:
        //     float Range: 0 to 10
        public void Set(double hysteresis)
        {
            Set(hysteresis, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:HYSTeresis
        //     Sets the hysteresis of the internal trigger threshold. Hysteresis is the magnitude
        //     (in dB) the trigger signal level must drop below the trigger threshold (positive
        //     trigger slope) before triggering can occur again.
        //
        // Параметры:
        //   hysteresis:
        //     float Range: 0 to 10
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double hysteresis, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:HYSTeresis " + hysteresis.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:HYSTeresis
        //     Sets the hysteresis of the internal trigger threshold. Hysteresis is the magnitude
        //     (in dB) the trigger signal level must drop below the trigger threshold (positive
        //     trigger slope) before triggering can occur again.
        //     hysteresis: float Range: 0 to 10
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:TRIGger:HYSTeresis
        //     Sets the hysteresis of the internal trigger threshold. Hysteresis is the magnitude
        //     (in dB) the trigger signal level must drop below the trigger threshold (positive
        //     trigger slope) before triggering can occur again.
        //     hysteresis: float Range: 0 to 10
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:TRIGger:HYSTeresis?");
        }
    }
}
