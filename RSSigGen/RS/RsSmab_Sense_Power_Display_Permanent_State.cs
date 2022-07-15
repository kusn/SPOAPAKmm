using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Display_Permanent_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Display_Permanent_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Display_Permanent_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:STATe
        //     Activates the permanent display of the measured power level results. The instrument
        //     also indicates the sensor type, the connection, the measurement source and the
        //     offset if set.
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
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:STATe
        //     Activates the permanent display of the measured power level results. The instrument
        //     also indicates the sensor type, the connection, the measurement source and the
        //     offset if set.
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
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:DISPlay:PERManent:STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:STATe
        //     Activates the permanent display of the measured power level results. The instrument
        //     also indicates the sensor type, the connection, the measurement source and the
        //     offset if set.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:STATe
        //     Activates the permanent display of the measured power level results. The instrument
        //     also indicates the sensor type, the connection, the measurement source and the
        //     offset if set.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:DISPlay:PERManent:STATe?");
        }
    }
}
