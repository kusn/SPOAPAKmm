using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Sensor_Map commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Slist_Sensor_Map
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Slist_Sensor_Map(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Map", core, parent);
        }

        //
        // Сводка:
        //     SLISt:SENSor:MAP
        //     Assigns a sensor directly to one of the sensor channels, using the sensor name
        //     and serial number. To find out the the sensor name and ID, you can get it from
        //     the label of the R&S NRP, or using the command method RsSmab.Slist.List. This
        //     command detects all R&S NRP power sensors connected in the LAN or via 'USBTMC
        //     protocol.
        //
        // Параметры:
        //   sensorId:
        //     string
        //
        //   mapping:
        //     enum
        public void Set(string sensorId, ErFpowSensMappingEnum mapping)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(sensorId, 0, DataType.String), new ArgSingle(mapping, 1, DataType.Enum));
            _grpBase.IO.Write("SLISt:SENSor:MAP " + text);
        }
    }
}
