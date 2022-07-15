using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Dcatalog_Length
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_MassMemory_Dcatalog_Length(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Length", core, parent);
        }

        private int _Get(string queryArgs)
        {
            return _grpBase.IO.QueryInt32(("MMEMory:DCATalog:LENGth? " + queryArgs).TrimEnd());
        }

        //
        // Сводка:
        //     MMEMory:DCATalog:LENGth
        //     Returns the number of subdirectories in the current or specified directory.
        //     directoryCount: integer Number of parent and subdirectories.
        //
        // Параметры:
        //   path:
        //     String parameter to specify the directory. If the directory is omitted, the command
        //     queries the contents of the current directory, to be queried with method RsSmab.MassMemory.CurrentDirectory
        //     command.
        public int Get(string path)
        {
            string queryArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(path, 0, DataType.String));
            return _Get(queryArgs);
        }

        //
        // Сводка:
        //     MMEMory:DCATalog:LENGth
        //     Returns the number of subdirectories in the current or specified directory.
        //     directoryCount: integer Number of parent and subdirectories.
        public int Get()
        {
            return _Get("");
        }
    }
}
