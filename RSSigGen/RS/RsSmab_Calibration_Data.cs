using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Calibration_Data
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Data_Factory _factory;

        private RsSmab_Calibration_Data_Remove _remove;

        private RsSmab_Calibration_Data_Update _update;

        //
        // Сводка:
        //     Factory commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Data_Factory Factory => _factory ?? (_factory = new RsSmab_Calibration_Data_Factory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Remove commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Data_Remove Remove => _remove ?? (_remove = new RsSmab_Calibration_Data_Remove(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Update commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Calibration_Data_Update Update => _update ?? (_update = new RsSmab_Calibration_Data_Update(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Data Clone()
        {
            RsSmab_Calibration_Data rsSmab_Calibration_Data = new RsSmab_Calibration_Data(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Data);
            return rsSmab_Calibration_Data;
        }
    }
}
