using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling commands group definition
    //     Sub-classes count: 6
    //     Commands count: 1
    //     Total commands count: 18
    public class RsSmab_System_Profiling
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Profiling_HwAccess _hwAccess;

        private RsSmab_System_Profiling_Logging _logging;

        private RsSmab_System_Profiling_Module _module;

        private RsSmab_System_Profiling_Record _record;

        private RsSmab_System_Profiling_Tick _tick;

        private RsSmab_System_Profiling_Tpoint _tpoint;

        //
        // Сводка:
        //     HwAccess commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_System_Profiling_HwAccess HwAccess => _hwAccess ?? (_hwAccess = new RsSmab_System_Profiling_HwAccess(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Logging commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Profiling_Logging Logging => _logging ?? (_logging = new RsSmab_System_Profiling_Logging(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Module commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Profiling_Module Module => _module ?? (_module = new RsSmab_System_Profiling_Module(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Record commands group
        //     Sub-classes count: 2
        //     Commands count: 4
        //     Total commands count: 7
        public RsSmab_System_Profiling_Record Record => _record ?? (_record = new RsSmab_System_Profiling_Record(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Tick commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_System_Profiling_Tick Tick => _tick ?? (_tick = new RsSmab_System_Profiling_Tick(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Tpoint commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_System_Profiling_Tpoint Tpoint => _tpoint ?? (_tpoint = new RsSmab_System_Profiling_Tpoint(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:PROFiling:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:PROFiling:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PROFiling:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Profiling(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Profiling", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Profiling Clone()
        {
            RsSmab_System_Profiling rsSmab_System_Profiling = new RsSmab_System_Profiling(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Profiling);
            return rsSmab_System_Profiling;
        }
    }
}
