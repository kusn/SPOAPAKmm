using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Correction_SpDevice_List commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Correction_SpDevice_List
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Correction_SpDevice_List(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("List", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:LIST
        //     Queries the list of the S-parameter data sets that have been loaded to the power
        //     sensor.
        //     list: string list
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public List<string> Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:LIST
        //     Queries the list of the S-parameter data sets that have been loaded to the power
        //     sensor.
        //     list: string list
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public List<string> Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryStringArray("SENSe" + repCapCmdValue + ":POWer:CORRection:SPDevice:LIST?").ToStringList();
        }
    }
}
