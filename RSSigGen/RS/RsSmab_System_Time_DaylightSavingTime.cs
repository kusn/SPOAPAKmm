using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Time_DaylightSavingTime commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 3
    public class RsSmab_System_Time_DaylightSavingTime
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Time_DaylightSavingTime_Rule _rule;

        //
        // Сводка:
        //     Rule commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Time_DaylightSavingTime_Rule Rule => _rule ?? (_rule = new RsSmab_System_Time_DaylightSavingTime_Rule(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:TIME:DSTime:MODE
        //     No additional help available
        public string Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:TIME:DSTime:MODE?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:TIME:DSTime:MODE " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Time_DaylightSavingTime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("DaylightSavingTime", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Time_DaylightSavingTime Clone()
        {
            RsSmab_System_Time_DaylightSavingTime rsSmab_System_Time_DaylightSavingTime = new RsSmab_System_Time_DaylightSavingTime(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Time_DaylightSavingTime);
            return rsSmab_System_Time_DaylightSavingTime;
        }
    }
}
