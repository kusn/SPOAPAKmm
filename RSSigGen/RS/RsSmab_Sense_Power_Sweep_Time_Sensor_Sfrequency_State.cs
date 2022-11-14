using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Time_Sensor_Sfrequency_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:SFRequency:STATe
        //     Activates the use of a different frequency for the power measurement.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:SFRequency:STATe
        //     Activates the use of a different frequency for the power measurement.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   channel:
        //     Repeated capability selector
        public void Set(bool state, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:SFRequency:STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:SFRequency:STATe
        //     Activates the use of a different frequency for the power measurement.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:TIME:[SENSor]:SFRequency:STATe
        //     Activates the use of a different frequency for the power measurement.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:SWEep:TIME:SENSor:SFRequency:STATe?");
        }
    }
}
