using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Load_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_MassMemory_Load_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     MMEMory:LOAD:STATe
        //     Loads the specified file stored under the specified name in an internal memory.
        //     After the file has been loaded, the instrument setting must be activated using
        //     an *RCL command.
        //
        // Параметры:
        //   dataSet:
        //     No help available
        //
        //   sourceFile:
        //     No help available
        public void Set(int dataSet, string sourceFile)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(dataSet, 0, DataType.Integer), new ArgSingle(sourceFile, 1, DataType.String));
            _grpBase.IO.Write("MMEMory:LOAD:STATe " + text);
        }
    }
}
