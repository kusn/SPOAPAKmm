using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_MassMemory commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_System_MassMemory
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_MassMemory_Path _path;

        //
        // Сводка:
        //     Path commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_MassMemory_Path Path => _path ?? (_path = new RsSmab_System_MassMemory_Path(_grpBase.Core, _grpBase));

        internal RsSmab_System_MassMemory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("MassMemory", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_MassMemory Clone()
        {
            RsSmab_System_MassMemory rsSmab_System_MassMemory = new RsSmab_System_MassMemory(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_MassMemory);
            return rsSmab_System_MassMemory;
        }
    }
}
