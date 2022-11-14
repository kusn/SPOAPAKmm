using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Pulse_Threshold_Base(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Base", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:BASE
        //     Selects how the threshold parameters for pulse analysis are calculated. Note:
        //     The command is only available in time measurement mode and with R&S NRPZ81 power
        //     sensors.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   baseX:
        //     VOLTage| POWer
        public void Set(MeasRespPulsThrBaseEnum baseX)
        {
            Set(baseX, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:BASE
        //     Selects how the threshold parameters for pulse analysis are calculated. Note:
        //     The command is only available in time measurement mode and with R&S NRPZ81 power
        //     sensors.
        //
        // Параметры:
        //   baseX:
        //     VOLTage| POWer
        //
        //   channel:
        //     Repeated capability selector
        public void Set(MeasRespPulsThrBaseEnum baseX, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:BASE " + baseX.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:BASE
        //     Selects how the threshold parameters for pulse analysis are calculated. Note:
        //     The command is only available in time measurement mode and with R&S NRPZ81 power
        //     sensors.
        //     baseX: VOLTage| POWer
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public MeasRespPulsThrBaseEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:PULSe:THReshold:BASE
        //     Selects how the threshold parameters for pulse analysis are calculated. Note:
        //     The command is only available in time measurement mode and with R&S NRPZ81 power
        //     sensors.
        //     baseX: VOLTage| POWer
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public MeasRespPulsThrBaseEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:PULSe:THReshold:BASE?").ToScpiEnum<MeasRespPulsThrBaseEnum>();
        }
    }
}
