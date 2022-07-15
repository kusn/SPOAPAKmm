using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Eeprom_Data_Points
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Eeprom_Data_Points(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Points", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:EEPRom:DATA:POINts
        //     No additional help available
        public int Get(string board, string subBoard)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(board, 0, DataType.String), new ArgSingle(subBoard, 1, DataType.String));
            return _grpBase.IO.QueryInt32("DIAGnostic<HwInstance>:EEPRom:DATA:POINts? " + text);
        }
    }
}
