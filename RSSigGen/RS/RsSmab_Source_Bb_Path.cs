using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Path commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Bb_Path
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:BB:PATH:COUNt
        //     No additional help available
        public int Count => _grpBase.IO.QueryInt32("SOURce:BB:PATH:COUNt?");

        internal RsSmab_Source_Bb_Path(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Path", core, parent);
        }
    }
}
