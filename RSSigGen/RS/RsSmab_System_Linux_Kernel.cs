using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Linux_Kernel commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Linux_Kernel
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:LINux:KERNel:VERSion
        //     No additional help available
        public string Version => _grpBase.IO.QueryString("SYSTem:LINux:KERNel:VERSion?").TrimStringResponse();

        internal RsSmab_System_Linux_Kernel(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Kernel", core, parent);
        }
    }
}
