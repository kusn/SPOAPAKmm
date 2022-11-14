using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Snumber commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Snumber
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Snumber(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Snumber", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SNUMber
        //     Queries the serial number of the sensor.
        //     snumber: string
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public string Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SNUMber
        //     Queries the serial number of the sensor.
        //     snumber: string
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public string Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SNUMber?").TrimStringResponse();
        }
    }
}
