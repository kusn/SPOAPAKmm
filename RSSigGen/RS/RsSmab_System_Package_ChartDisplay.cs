using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Package_ChartDisplay commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Package_ChartDisplay
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PACKage:CHARtdisplay:VERSion
        //     No additional help available
        public string Version => _grpBase.IO.QueryString("SYSTem:PACKage:CHARtdisplay:VERSion?").TrimStringResponse();

        internal RsSmab_System_Package_ChartDisplay(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("ChartDisplay", core, parent);
        }
    }
}
