using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Specification commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 5
    public class RsSmab_System_Specification
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Specification_Identification _identification;

        private RsSmab_System_Specification_Version _version;

        //
        // Сводка:
        //     Identification commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Specification_Identification Identification => _identification ?? (_identification = new RsSmab_System_Specification_Identification(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Version commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_System_Specification_Version Version => _version ?? (_version = new RsSmab_System_Specification_Version(_grpBase.Core, _grpBase));

        internal RsSmab_System_Specification(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Specification", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Specification Clone()
        {
            RsSmab_System_Specification rsSmab_System_Specification = new RsSmab_System_Specification(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Specification);
            return rsSmab_System_Specification;
        }
    }
}
