using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Type commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Type
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Type(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Type", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:TYPE
        //     Queries the sensor type. The type is automatically detected.
        //     type: string
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public string Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:TYPE
        //     Queries the sensor type. The type is automatically detected.
        //     type: string
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public string Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:TYPE?").TrimStringResponse();
        }
    }
}
