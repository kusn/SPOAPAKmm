using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Startup commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Startup
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:STARtup:COMPlete
        //     Queries if the startup of the instrument is completed.
        //     complete: 0| 1| OFF| ON
        public bool Complete => _grpBase.IO.QueryBoolean("SYSTem:STARtup:COMPlete?");

        internal RsSmab_System_Startup(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Startup", core, parent);
        }
    }
}
