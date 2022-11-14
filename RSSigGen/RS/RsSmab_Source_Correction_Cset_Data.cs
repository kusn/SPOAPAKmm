using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset_Data commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_Source_Correction_Cset_Data
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Correction_Cset_Data_Frequency _frequency;

        private RsSmab_Source_Correction_Cset_Data_Power _power;

        private RsSmab_Source_Correction_Cset_Data_Sensor _sensor;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Correction_Cset_Data_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Correction_Cset_Data_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Correction_Cset_Data_Power Power => _power ?? (_power = new RsSmab_Source_Correction_Cset_Data_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Source_Correction_Cset_Data_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Source_Correction_Cset_Data_Sensor(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Correction_Cset_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Correction_Cset_Data Clone()
        {
            RsSmab_Source_Correction_Cset_Data rsSmab_Source_Correction_Cset_Data = new RsSmab_Source_Correction_Cset_Data(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Correction_Cset_Data);
            return rsSmab_Source_Correction_Cset_Data;
        }
    }
}
