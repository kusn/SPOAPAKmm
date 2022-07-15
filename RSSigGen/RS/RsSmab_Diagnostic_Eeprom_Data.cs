using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom_Data
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Eeprom_Data_Points _points;

        //
        // Сводка:
        //     Points commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Eeprom_Data_Points Points => _points ?? (_points = new RsSmab_Diagnostic_Eeprom_Data_Points(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Eeprom_Data(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Data", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Eeprom_Data Clone()
        {
            RsSmab_Diagnostic_Eeprom_Data rsSmab_Diagnostic_Eeprom_Data = new RsSmab_Diagnostic_Eeprom_Data(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Eeprom_Data);
            return rsSmab_Diagnostic_Eeprom_Data;
        }
    }
}
