using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Protect commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    //     Repeated Capability: LevelRepCap, default value after init: LevelRepCap.Nr1
    public class RsSmab_System_Protect
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Protect_State _state;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to LevelRepCap.Default
        //     Default value after init: LevelRepCap.Nr1
        public LevelRepCap RepCapLevel
        {
            get
            {
                return (LevelRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Protect_State State => _state ?? (_state = new RsSmab_System_Protect_State(_grpBase.Core, _grpBase));

        internal RsSmab_System_Protect(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Protect", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(LevelRepCap), _grpBase.GroupName, "RepCapLevel", LevelRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Protect Clone()
        {
            RsSmab_System_Protect rsSmab_System_Protect = new RsSmab_System_Protect(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Protect);
            return rsSmab_System_Protect;
        }
    }
}
