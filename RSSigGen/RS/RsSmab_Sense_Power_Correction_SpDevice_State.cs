using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Correction_SpDevice_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Correction_SpDevice_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Correction_SpDevice_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:STATe
        //     Activates the use of the S-parameter correction data. Note: If you use power
        //     sensors with attenuator, the instrument automatically activates the use of S-parameter
        //     data.
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
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:STATe
        //     Activates the use of the S-parameter correction data. Note: If you use power
        //     sensors with attenuator, the instrument automatically activates the use of S-parameter
        //     data.
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
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:CORRection:SPDevice:STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:STATe
        //     Activates the use of the S-parameter correction data. Note: If you use power
        //     sensors with attenuator, the instrument automatically activates the use of S-parameter
        //     data.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:STATe
        //     Activates the use of the S-parameter correction data. Note: If you use power
        //     sensors with attenuator, the instrument automatically activates the use of S-parameter
        //     data.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:CORRection:SPDevice:STATe?");
        }
    }
}
