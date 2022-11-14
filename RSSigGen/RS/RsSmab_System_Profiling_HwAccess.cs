using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_HwAccess commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_System_Profiling_HwAccess
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PROFiling:HWACcess:DESCription
        //     No additional help available
        public string Description => _grpBase.IO.QueryString("SYSTem:PROFiling:HWACcess:DESCription?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:PROFiling:HWACcess:PDURation
        //     No additional help available
        public int Pduration
        {
            get
            {
                return _grpBase.IO.QueryInt32("SYSTem:PROFiling:HWACcess:PDURation?");
            }
            set
            {
                _grpBase.IO.Write($"SYSTem:PROFiling:HWACcess:PDURation {value}");
            }
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:HWACcess:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:PROFiling:HWACcess:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:HWACcess:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Profiling_HwAccess(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("HwAccess", core, parent);
        }
    }
}
