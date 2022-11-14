using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Package_Qt commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Package_Qt
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PACKage:QT:VERSion
        //     No additional help available
        public string Version => _grpBase.IO.QueryString("SYSTem:PACKage:QT:VERSion?").TrimStringResponse();

        internal RsSmab_System_Package_Qt(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Qt", core, parent);
        }
    }
}
