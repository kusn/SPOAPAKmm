using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Input_Modext commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Source_Input_Modext
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Input_Modext_Coupling _coupling;

        private RsSmab_Source_Input_Modext_Impedance _impedance;

        //
        // Сводка:
        //     Coupling commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
        public RsSmab_Source_Input_Modext_Coupling Coupling => _coupling ?? (_coupling = new RsSmab_Source_Input_Modext_Coupling(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Impedance commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
        public RsSmab_Source_Input_Modext_Impedance Impedance => _impedance ?? (_impedance = new RsSmab_Source_Input_Modext_Impedance(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Input_Modext(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Modext", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Input_Modext Clone()
        {
            RsSmab_Source_Input_Modext rsSmab_Source_Input_Modext = new RsSmab_Source_Input_Modext(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Input_Modext);
            return rsSmab_Source_Input_Modext;
        }
    }
}
