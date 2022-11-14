using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Files commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_System_Files
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Files_Temporary _temporary;

        //
        // Сводка:
        //     Temporary commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Files_Temporary Temporary => _temporary ?? (_temporary = new RsSmab_System_Files_Temporary(_grpBase.Core, _grpBase));

        internal RsSmab_System_Files(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Files", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Files Clone()
        {
            RsSmab_System_Files rsSmab_System_Files = new RsSmab_System_Files(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Files);
            return rsSmab_System_Files;
        }
    }
}
