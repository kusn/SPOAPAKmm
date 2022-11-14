using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_BgInfo
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DIAGnostic<HW>:BGINfo:CATalog
        //     Queries the names of the assemblies available in the instrument.
        //     catalog: string List of all assemblies; the values are separated by commas The
        //     length of the list is variable and depends on the instrument equipment configuration.
        public List<string> Catalog => _grpBase.IO.QueryStringArray("DIAGnostic<HwInstance>:BGINfo:CATalog?").ToStringList();

        internal RsSmab_Diagnostic_BgInfo(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("BgInfo", core, parent);
        }

        private string _Get(string queryArgs)
        {
            return _grpBase.IO.QueryString(("DIAGnostic<HwInstance>:BGINfo? " + queryArgs).TrimEnd()).TrimStringResponse();
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:BGINfo
        //     Queries information on the modules available in the instrument, using the variant
        //     and revision state.
        //     bgInfo: Module name Module stock number incl. variant Module revision Module
        //     serial number List of comma-separated entries, one entry per module. Each entry
        //     for one module consists of four parts that are separated by space characters.
        //
        // Параметры:
        //   board:
        //     string Module name, as queried with the command method RsSmab.Diagnostic.BgInfo.Catalog.
        //     To retrieve a complete list of all modules, omit the parameter. The length of
        //     the list is variable and depends on the instrument equipment configuration.
        public string Get(string board)
        {
            string queryArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(board, 0, DataType.String));
            return _Get(queryArgs);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:BGINfo
        //     Queries information on the modules available in the instrument, using the variant
        //     and revision state.
        //     bgInfo: Module name Module stock number incl. variant Module revision Module
        //     serial number List of comma-separated entries, one entry per module. Each entry
        //     for one module consists of four parts that are separated by space characters.
        public string Get()
        {
            return _Get("");
        }
    }
}
