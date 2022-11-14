using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Catalog_Length
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_MassMemory_Catalog_Length(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Length", core, parent);
        }

        private int _Get(string queryArgs)
        {
            return _grpBase.IO.QueryInt32(("MMEMory:CATalog:LENGth? " + queryArgs).TrimEnd());
        }

        //
        // Сводка:
        //     MMEMory:CATalog:LENGth
        //     Returns the number of files in the current or in the specified directory.
        //     fileCount: integer Number of files.
        //
        // Параметры:
        //   path:
        //     string String parameter to specify the directory. If the directory is omitted,
        //     the command queries the content of the current directory, queried with method
        //     RsSmab.MassMemory.CurrentDirectory command.
        public int Get(string path)
        {
            string queryArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(path, 0, DataType.String));
            return _Get(queryArgs);
        }

        //
        // Сводка:
        //     MMEMory:CATalog:LENGth
        //     Returns the number of files in the current or in the specified directory.
        //     fileCount: integer Number of files.
        public int Get()
        {
            return _Get("");
        }
    }
}
