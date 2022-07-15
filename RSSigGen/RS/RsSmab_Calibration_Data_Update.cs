using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data_Update commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Calibration_Data_Update
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Data_Update_Level _level;

        //
        // Сводка:
        //     Level commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Calibration_Data_Update_Level Level => _level ?? (_level = new RsSmab_Calibration_Data_Update_Level(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CALibration<HW>:DATA:UPDate
        //     No additional help available
        public CalDataUpdateEnum Value
        {
            set
            {
                _grpBase.IO.Write("CALibration<HwInstance>:DATA:UPDate " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Data_Update(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Update", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Data_Update Clone()
        {
            RsSmab_Calibration_Data_Update rsSmab_Calibration_Data_Update = new RsSmab_Calibration_Data_Update(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Data_Update);
            return rsSmab_Calibration_Data_Update;
        }
    }
}
