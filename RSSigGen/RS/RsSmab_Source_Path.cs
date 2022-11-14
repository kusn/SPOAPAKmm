using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Path commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Path
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:PATH:COUNt
        //     No additional help available
        public int Count => _grpBase.IO.QueryInt32("SOURce:PATH:COUNt?");

        internal RsSmab_Source_Path(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Path", core, parent);
        }
    }
}
