using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Record commands group definition
    //     Sub-classes count: 2
    //     Commands count: 4
    //     Total commands count: 7
    public class RsSmab_System_Profiling_Record
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Profiling_Record_Count _count;

        private RsSmab_System_Profiling_Record_Wrap _wrap;

        //
        // Сводка:
        //     Count commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Profiling_Record_Count Count => _count ?? (_count = new RsSmab_System_Profiling_Record_Count(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Wrap commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Profiling_Record_Wrap Wrap => _wrap ?? (_wrap = new RsSmab_System_Profiling_Record_Wrap(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:IGNore
        //     No additional help available
        public double Ignore
        {
            get
            {
                return _grpBase.IO.QueryDouble("SYSTem:PROFiling:RECord:IGNore?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:RECord:IGNore " + value.ToDoubleString());
            }
        }

        internal RsSmab_System_Profiling_Record(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Record", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Profiling_Record Clone()
        {
            RsSmab_System_Profiling_Record rsSmab_System_Profiling_Record = new RsSmab_System_Profiling_Record(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Profiling_Record);
            return rsSmab_System_Profiling_Record;
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord
        //     No additional help available
        public List<string> Get(List<string> index)
        {
            return _grpBase.IO.QueryStringArray("SYSTem:PROFiling:RECord? " + index.ToCsvString()).ToStringList();
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:CLEar
        //     No additional help available
        public void Clear()
        {
            _grpBase.IO.Write("SYSTem:PROFiling:RECord:CLEar");
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAndWait()
        {
            ClearAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:PROFiling:RECord:CLEar", opcTimeoutMs);
        }

        //
        // Сводка:
        //     SYSTem:PROFiling:RECord:SAVE
        //     No additional help available
        public void Save(string filename)
        {
            _grpBase.IO.Write("SYSTem:PROFiling:RECord:SAVE " + filename.EncloseByQuotes());
        }
    }
}
