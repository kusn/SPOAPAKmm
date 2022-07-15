using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Generic commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Generic
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:GENeric:MSG
        //     No additional help available
        public string Msg
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:GENeric:MSG?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:GENeric:MSG " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Generic(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Generic", core, parent);
        }
    }
}
