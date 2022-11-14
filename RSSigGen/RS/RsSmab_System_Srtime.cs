using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Srtime commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_System_Srtime
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Srtime_Synchronize _synchronize;

        //
        // Сводка:
        //     Synchronize commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Srtime_Synchronize Synchronize => _synchronize ?? (_synchronize = new RsSmab_System_Srtime_Synchronize(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:SRTime:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:SRTime:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:SRTime:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Srtime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Srtime", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Srtime Clone()
        {
            RsSmab_System_Srtime rsSmab_System_Srtime = new RsSmab_System_Srtime(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Srtime);
            return rsSmab_System_Srtime;
        }
    }
}
