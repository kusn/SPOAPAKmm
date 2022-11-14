using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_Mmem commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_System_Security_Mmem
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Security_Mmem_Protect _protect;

        //
        // Сводка:
        //     Protect commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_System_Security_Mmem_Protect Protect => _protect ?? (_protect = new RsSmab_System_Security_Mmem_Protect(_grpBase.Core, _grpBase));

        internal RsSmab_System_Security_Mmem(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mmem", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Security_Mmem Clone()
        {
            RsSmab_System_Security_Mmem rsSmab_System_Security_Mmem = new RsSmab_System_Security_Mmem(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Security_Mmem);
            return rsSmab_System_Security_Mmem;
        }
    }
}
