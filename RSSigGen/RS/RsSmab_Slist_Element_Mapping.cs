using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Element_Mapping commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Slist_Element_Mapping
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Slist_Element_Mapping(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mapping", core, parent);
        }

        //
        // Сводка:
        //     SLISt:ELEMent<CH>:MAPPing
        //     Assigns an entry from the :​SLISt[:​LIST]? to one of the four sensor channels.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Element")
        //
        // Параметры:
        //   mapping:
        //     SENS1| SENSor1| SENS2| SENSor2| SENS3| SENSor3| SENS4| SENSor4| UNMapped Sensor
        //     channel.
        public void Set(ErFpowSensMappingEnum mapping)
        {
            Set(mapping, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SLISt:ELEMent<CH>:MAPPing
        //     Assigns an entry from the :​SLISt[:​LIST]? to one of the four sensor channels.
        //
        // Параметры:
        //   mapping:
        //     SENS1| SENSor1| SENS2| SENSor2| SENS3| SENSor3| SENS4| SENSor4| UNMapped Sensor
        //     channel.
        //
        //   channel:
        //     Repeated capability selector
        public void Set(ErFpowSensMappingEnum mapping, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SLISt:ELEMent" + repCapCmdValue + ":MAPPing " + mapping.ToScpiString());
        }

        //
        // Сводка:
        //     SLISt:ELEMent<CH>:MAPPing
        //     Assigns an entry from the :​SLISt[:​LIST]? to one of the four sensor channels.
        //     mapping: SENS1| SENSor1| SENS2| SENSor2| SENS3| SENSor3| SENS4| SENSor4| UNMapped
        //     Sensor channel.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Element")
        public ErFpowSensMappingEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SLISt:ELEMent<CH>:MAPPing
        //     Assigns an entry from the :​SLISt[:​LIST]? to one of the four sensor channels.
        //     mapping: SENS1| SENSor1| SENS2| SENSor2| SENS3| SENSor3| SENS4| SENSor4| UNMapped
        //     Sensor channel.
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public ErFpowSensMappingEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SLISt:ELEMent" + repCapCmdValue + ":MAPPing?").ToScpiEnum<ErFpowSensMappingEnum>();
        }
    }
}
