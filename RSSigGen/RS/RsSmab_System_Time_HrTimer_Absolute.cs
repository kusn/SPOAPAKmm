using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time_HrTimer_Absolute commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Time_HrTimer_Absolute
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:TIME:HRTimer:ABSolute:SET
        //     No additional help available
        public string Set
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:HRTimer:ABSolute:SET?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:HRTimer:ABSolute:SET " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:TIME:HRTimer:ABSolute
        //     No additional help available
        public string Value
        {
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:HRTimer:ABSolute " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time_HrTimer_Absolute(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Absolute", core, parent);
        }
    }
}
