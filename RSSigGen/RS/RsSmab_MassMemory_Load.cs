using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Load
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_MassMemory_Load_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_MassMemory_Load_State State => _state ?? (_state = new RsSmab_MassMemory_Load_State(_grpBase.Core, _grpBase));

        internal RsSmab_MassMemory_Load(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Load", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_MassMemory_Load Clone()
        {
            RsSmab_MassMemory_Load rsSmab_MassMemory_Load = new RsSmab_MassMemory_Load(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_MassMemory_Load);
            return rsSmab_MassMemory_Load;
        }
    }
}
