using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sversion commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sversion
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sversion(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sversion", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SVERsion
        //     Queries the software version of the connected R&S NRP power sensor.
        //     sversion: string
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public string Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SVERsion
        //     Queries the software version of the connected R&S NRP power sensor.
        //     sversion: string
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public string Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SVERsion?").TrimStringResponse();
        }
    }
}
