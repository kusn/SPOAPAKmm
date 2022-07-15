using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Roscillator commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Calibration_Roscillator
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Roscillator_Data _data;

        private RsSmab_Calibration_Roscillator_Store _store;

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Calibration_Roscillator_Data Data => _data ?? (_data = new RsSmab_Calibration_Roscillator_Data(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Store commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Roscillator_Store Store => _store ?? (_store = new RsSmab_Calibration_Roscillator_Store(_grpBase.Core, _grpBase));

        internal RsSmab_Calibration_Roscillator(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Roscillator", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Roscillator Clone()
        {
            RsSmab_Calibration_Roscillator rsSmab_Calibration_Roscillator = new RsSmab_Calibration_Roscillator(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Roscillator);
            return rsSmab_Calibration_Roscillator;
        }
    }
}
