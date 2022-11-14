using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Sensor commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Slist_Sensor
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Slist_Sensor_Map _map;

        //
        // Сводка:
        //     Map commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Slist_Sensor_Map Map => _map ?? (_map = new RsSmab_Slist_Sensor_Map(_grpBase.Core, _grpBase));

        internal RsSmab_Slist_Sensor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sensor", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Slist_Sensor Clone()
        {
            RsSmab_Slist_Sensor rsSmab_Slist_Sensor = new RsSmab_Slist_Sensor(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Slist_Sensor);
            return rsSmab_Slist_Sensor;
        }
    }
}
