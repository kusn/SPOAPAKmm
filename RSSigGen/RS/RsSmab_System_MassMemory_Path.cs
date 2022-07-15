using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_MassMemory_Path commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_MassMemory_Path
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:MMEMory:PATH:USER
        //     Queries the user directory, that means the directory the R&S SMA100B stores user
        //     files on.
        //     pathUser: string
        public string User => _grpBase.IO.QueryString("SYSTem:MMEMory:PATH:USER?").TrimStringResponse();

        internal RsSmab_System_MassMemory_Path(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Path", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:MMEMory:PATH
        //     No additional help available
        public string Get(string pathType)
        {
            return _grpBase.IO.QueryString("SYSTem:MMEMory:PATH? " + pathType.EncloseByQuotes()).TrimStringResponse();
        }
    }
}
