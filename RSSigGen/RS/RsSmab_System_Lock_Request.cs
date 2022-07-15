using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Request commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_System_Lock_Request
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Lock_Request_Shared _shared;

        //
        // Сводка:
        //     Shared commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Lock_Request_Shared Shared => _shared ?? (_shared = new RsSmab_System_Lock_Request_Shared(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:LOCK:REQuest:[EXCLusive]
        //     Queries whether a lock for exclusive access to the instrument via ethernet exists.
        //     If successful, the query returns a 1, otherwise 0.
        //     success: integer
        public int Exclusive => _grpBase.IO.QueryInt32("SYSTem:LOCK:REQuest:EXCLusive?");

        internal RsSmab_System_Lock_Request(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Request", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Lock_Request Clone()
        {
            RsSmab_System_Lock_Request rsSmab_System_Lock_Request = new RsSmab_System_Lock_Request(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Lock_Request);
            return rsSmab_System_Lock_Request;
        }
    }
}
