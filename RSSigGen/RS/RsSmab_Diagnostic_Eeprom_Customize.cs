using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom_Customize
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Eeprom_Customize(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Customize", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:CUSTomize
        //     No additional help available
        public void Set(string board, int index, int subBoard)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(board, 0, DataType.String), new ArgSingle(index, 1, DataType.Integer), new ArgSingle(subBoard, 2, DataType.Integer));
            _grpBase.IO.Write("DIAGnostic<HwInstance>:EEPRom:CUSTomize " + text);
        }
    }
}
