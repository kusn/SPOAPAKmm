using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset_Data_Sensor_Power commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Correction_Cset_Data_Sensor_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce _sonce;

        //
        // Сводка:
        //     Sonce commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce Sonce => _sonce ?? (_sonce = new RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Correction_Cset_Data_Sensor_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Correction_Cset_Data_Sensor_Power Clone()
        {
            RsSmab_Source_Correction_Cset_Data_Sensor_Power rsSmab_Source_Correction_Cset_Data_Sensor_Power = new RsSmab_Source_Correction_Cset_Data_Sensor_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Correction_Cset_Data_Sensor_Power);
            return rsSmab_Source_Correction_Cset_Data_Sensor_Power;
        }
    }
}
