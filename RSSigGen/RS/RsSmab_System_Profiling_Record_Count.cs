using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Record_Count commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Profiling_Record_Count
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:COUNt:MAX
        //     No additional help available
        public double Max
        {
            get
            {
                return _grpBase.IO.QueryDouble("SYSTem:PROFiling:RECord:COUNt:MAX?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:RECord:COUNt:MAX " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:COUNt
        //     No additional help available
        public double Value => _grpBase.IO.QueryDouble("SYSTem:PROFiling:RECord:COUNt?");

        internal RsSmab_System_Profiling_Record_Count(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Count", core, parent);
        }
    }
}
