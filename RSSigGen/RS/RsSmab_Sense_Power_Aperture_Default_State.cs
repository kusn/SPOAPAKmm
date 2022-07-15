using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Aperture_Default_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Aperture_Default_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Aperture_Default_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:DEFault:STATe
        //     Deactivates the default aperture time of the respective sensor. To specify a
        //     user-defined value, use the command APERture:TIMe.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   useDefAp:
        //     0| 1| OFF| ON
        public void Set(bool useDefAp)
        {
            Set(useDefAp, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:DEFault:STATe
        //     Deactivates the default aperture time of the respective sensor. To specify a
        //     user-defined value, use the command APERture:TIMe.
        //
        // Параметры:
        //   useDefAp:
        //     0| 1| OFF| ON
        //
        //   channel:
        //     Repeated capability selector
        public void Set(bool useDefAp, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:APERture:DEFault:STATe " + useDefAp.ToBooleanString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:DEFault:STATe
        //     Deactivates the default aperture time of the respective sensor. To specify a
        //     user-defined value, use the command APERture:TIMe.
        //     useDefAp: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:DEFault:STATe
        //     Deactivates the default aperture time of the respective sensor. To specify a
        //     user-defined value, use the command APERture:TIMe.
        //     useDefAp: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:APERture:DEFault:STATe?");
        }
    }
}
