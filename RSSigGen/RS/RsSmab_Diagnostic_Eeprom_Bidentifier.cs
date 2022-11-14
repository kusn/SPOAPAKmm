using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom_Bidentifier
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Eeprom_Bidentifier_Catalog _catalog;

        //
        // Сводка:
        //     Catalog commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Eeprom_Bidentifier_Catalog Catalog => _catalog ?? (_catalog = new RsSmab_Diagnostic_Eeprom_Bidentifier_Catalog(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Eeprom_Bidentifier(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bidentifier", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Eeprom_Bidentifier Clone()
        {
            RsSmab_Diagnostic_Eeprom_Bidentifier rsSmab_Diagnostic_Eeprom_Bidentifier = new RsSmab_Diagnostic_Eeprom_Bidentifier(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Eeprom_Bidentifier);
            return rsSmab_Diagnostic_Eeprom_Bidentifier;
        }
    }
}
