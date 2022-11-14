using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Profiling_Tick commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_System_Profiling_Tick
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Profiling_Tick_Enable _enable;

        //
        // Сводка:
        //     Enable commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Profiling_Tick_Enable Enable => _enable ?? (_enable = new RsSmab_System_Profiling_Tick_Enable(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:PROFiling:TICK
        //     No additional help available
        public string Value => _grpBase.IO.QueryString("SYSTem:PROFiling:TICK?").TrimStringResponse();

        internal RsSmab_System_Profiling_Tick(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Tick", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Profiling_Tick Clone()
        {
            RsSmab_System_Profiling_Tick rsSmab_System_Profiling_Tick = new RsSmab_System_Profiling_Tick(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Profiling_Tick);
            return rsSmab_System_Profiling_Tick;
        }
    }
}
