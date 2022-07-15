using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Bios commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Bios
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:BIOS:VERSion
        //     Queries the BIOS version of the instrument.
        //     version: string
        public string Version => _grpBase.IO.QueryString("SYSTem:BIOS:VERSion?").TrimStringResponse();

        internal RsSmab_System_Bios(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bios", core, parent);
        }
    }
}
