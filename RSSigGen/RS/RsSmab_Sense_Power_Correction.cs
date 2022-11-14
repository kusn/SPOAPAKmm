using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Correction commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Sense_Power_Correction
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Correction_SpDevice _spDevice;

        //
        // Сводка:
        //     SpDevice commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Sense_Power_Correction_SpDevice SpDevice => _spDevice ?? (_spDevice = new RsSmab_Sense_Power_Correction_SpDevice(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Correction(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Correction", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Correction Clone()
        {
            RsSmab_Sense_Power_Correction rsSmab_Sense_Power_Correction = new RsSmab_Sense_Power_Correction(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Correction);
            return rsSmab_Sense_Power_Correction;
        }
    }
}
