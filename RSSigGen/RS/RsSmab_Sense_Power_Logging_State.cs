using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Logging_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Logging_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Logging_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:LOGGing:STATe
        //     Activates the recording of the power values, measured by a connected R&S NRP
        //     power sensor.
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
        //     SENSe<CH>:[POWer]:LOGGing:STATe
        //     Activates the recording of the power values, measured by a connected R&S NRP
        //     power sensor.
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
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:LOGGing:STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:LOGGing:STATe
        //     Activates the recording of the power values, measured by a connected R&S NRP
        //     power sensor.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:LOGGing:STATe
        //     Activates the recording of the power values, measured by a connected R&S NRP
        //     power sensor.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:LOGGing:STATe?");
        }
    }
}
