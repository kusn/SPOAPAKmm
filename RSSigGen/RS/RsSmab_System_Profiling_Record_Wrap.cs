using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Record_Wrap commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Profiling_Record_Wrap
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:WRAP:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:PROFiling:RECord:WRAP:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:RECord:WRAP:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Profiling_Record_Wrap(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Wrap", core, parent);
        }
    }
}
