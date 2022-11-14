using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Store_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_MassMemory_Store_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     MMEMory:STORe:STATe
        //     Stores the current instrument setting in the specified file. The instrument setting
        //     must first be stored in an internal memory with the same number using the common
        //     command *SAV.
        //
        // Параметры:
        //   dataSet:
        //     No help available
        //
        //   destinationFile:
        //     No help available
        public void Set(int dataSet, string destinationFile)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(dataSet, 0, DataType.Integer), new ArgSingle(destinationFile, 1, DataType.String));
            _grpBase.IO.Write("MMEMory:STORe:STATe " + text);
        }
    }
}
