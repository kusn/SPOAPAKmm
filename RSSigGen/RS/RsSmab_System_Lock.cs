using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock commands group definition
    //     Sub-classes count: 5
    //     Commands count: 1
    //     Total commands count: 10
    public class RsSmab_System_Lock
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Lock_Name _name;

        private RsSmab_System_Lock_Owner _owner;

        private RsSmab_System_Lock_Release _release;

        private RsSmab_System_Lock_Request _request;

        private RsSmab_System_Lock_Shared _shared;

        //
        // Сводка:
        //     Name commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Lock_Name Name => _name ?? (_name = new RsSmab_System_Lock_Name(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Owner commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Lock_Owner Owner => _owner ?? (_owner = new RsSmab_System_Lock_Owner(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Release commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Lock_Release Release => _release ?? (_release = new RsSmab_System_Lock_Release(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Request commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_System_Lock_Request Request => _request ?? (_request = new RsSmab_System_Lock_Request(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Shared commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Lock_Shared Shared => _shared ?? (_shared = new RsSmab_System_Lock_Shared(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:LOCK:TIMeout
        //     No additional help available
        public int Timeout
        {
            get
            {
                return _grpBase.IO.QueryInt32("SYSTem:LOCK:TIMeout?");
            }
            set
            {
                _grpBase.IO.Write($"SYSTem:LOCK:TIMeout {value}");
            }
        }

        internal RsSmab_System_Lock(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lock", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Lock Clone()
        {
            RsSmab_System_Lock rsSmab_System_Lock = new RsSmab_System_Lock(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Lock);
            return rsSmab_System_Lock;
        }
    }
}
