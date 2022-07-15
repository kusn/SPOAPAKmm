using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time_DaylightSavingTime_Rule commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Time_DaylightSavingTime_Rule
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:TIME:DSTime:RULE:CATalog
        //     No additional help available
        public string Catalog => _grpBase.IO.QueryString("SYSTem:TIME:DSTime:RULE:CATalog?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:TIME:DSTime:RULE
        //     No additional help available
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:DSTime:RULE?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:DSTime:RULE " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time_DaylightSavingTime_Rule(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Rule", core, parent);
        }
    }
}
