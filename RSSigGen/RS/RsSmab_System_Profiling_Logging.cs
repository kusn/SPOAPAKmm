using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Logging commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Profiling_Logging
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PROFiling:LOGGing:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:PROFiling:LOGGing:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:LOGGing:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Profiling_Logging(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Logging", core, parent);
        }
    }
}
