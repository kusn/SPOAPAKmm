using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_Length_Auto commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Filter_Length_Auto
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Filter_Length_Auto(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Auto", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:AUTO
        //     Queries the current filter length in filter mode AUTO (FILTer:TYPE)
        //     auto: float Range: 1 to 65536
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:LENGth:AUTO
        //     Queries the current filter length in filter mode AUTO (FILTer:TYPE)
        //     auto: float Range: 1 to 65536
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:FILTer:LENGth:AUTO?");
        }
    }
}
