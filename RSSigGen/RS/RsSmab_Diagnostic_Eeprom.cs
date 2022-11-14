using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Eeprom_Bidentifier _bidentifier;

        private RsSmab_Diagnostic_Eeprom_Customize _customize;

        private RsSmab_Diagnostic_Eeprom_Data _data;

        //
        // Сводка:
        //     Bidentifier commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Diagnostic_Eeprom_Bidentifier Bidentifier => _bidentifier ?? (_bidentifier = new RsSmab_Diagnostic_Eeprom_Bidentifier(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Customize commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Eeprom_Customize Customize => _customize ?? (_customize = new RsSmab_Diagnostic_Eeprom_Customize(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Diagnostic_Eeprom_Data Data => _data ?? (_data = new RsSmab_Diagnostic_Eeprom_Data(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Eeprom(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Eeprom", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Eeprom Clone()
        {
            RsSmab_Diagnostic_Eeprom rsSmab_Diagnostic_Eeprom = new RsSmab_Diagnostic_Eeprom(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Eeprom);
            return rsSmab_Diagnostic_Eeprom;
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:DELete
        //     No additional help available
        public void Delete()
        {
            _grpBase.IO.Write("DIAGnostic<HwInstance>:EEPRom:DELete");
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void DeleteAndWait()
        {
            DeleteAndWait(-1);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:DELete
        //     Same as Delete, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void DeleteAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("DIAGnostic<HwInstance>:EEPRom:DELete", opcTimeoutMs);
        }
    }
}
