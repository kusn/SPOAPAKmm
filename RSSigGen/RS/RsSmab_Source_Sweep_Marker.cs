using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Marker commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Marker
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Marker_Output _output;

        //
        // Сводка:
        //     Output commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Marker_Output Output => _output ?? (_output = new RsSmab_Source_Sweep_Marker_Output(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Sweep_Marker(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Marker", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep_Marker Clone()
        {
            RsSmab_Source_Sweep_Marker rsSmab_Source_Sweep_Marker = new RsSmab_Source_Sweep_Marker(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep_Marker);
            return rsSmab_Source_Sweep_Marker;
        }
    }
}
