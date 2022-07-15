using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time_HrTimer commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 3
    public class RsSmab_System_Time_HrTimer
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Time_HrTimer_Absolute _absolute;

        //
        // Сводка:
        //     Absolute commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Time_HrTimer_Absolute Absolute => _absolute ?? (_absolute = new RsSmab_System_Time_HrTimer_Absolute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:TIME:HRTimer:RELative
        //     No additional help available
        public string Relative
        {
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:HRTimer:RELative " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time_HrTimer(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("HrTimer", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Time_HrTimer Clone()
        {
            RsSmab_System_Time_HrTimer rsSmab_System_Time_HrTimer = new RsSmab_System_Time_HrTimer(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Time_HrTimer);
            return rsSmab_System_Time_HrTimer;
        }
    }
}
