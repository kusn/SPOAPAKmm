﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data_Update_Level commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Calibration_Data_Update_Level
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Data_Update_Level_Force _force;

        //
        // Сводка:
        //     Force commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Data_Update_Level_Force Force => _force ?? (_force = new RsSmab_Calibration_Data_Update_Level_Force(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Data_Update_Level(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Level", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Data_Update_Level Clone()
        {
            RsSmab_Calibration_Data_Update_Level rsSmab_Calibration_Data_Update_Level = new RsSmab_Calibration_Data_Update_Level(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Data_Update_Level);
            return rsSmab_Calibration_Data_Update_Level;
        }
    }
}
