using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom_Bidentifier_Catalog
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Eeprom_Bidentifier_Catalog(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Catalog", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:BIDentifier:CATalog
        //     No additional help available
        public List<string> Get(List<string> boardId)
        {
            return _grpBase.IO.QueryStringArray("DIAGnostic<HwInstance>:EEPRom:BIDentifier:CATalog? " + boardId.ToCsvString()).ToStringList();
        }
    }
}
