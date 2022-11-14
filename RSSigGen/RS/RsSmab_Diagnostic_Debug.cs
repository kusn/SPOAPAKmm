using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Debug
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Debug_Page _page;

        //
        // Сводка:
        //     Page commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Debug_Page Page => _page ?? (_page = new RsSmab_Diagnostic_Debug_Page(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Debug(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Debug", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Debug Clone()
        {
            RsSmab_Diagnostic_Debug rsSmab_Diagnostic_Debug = new RsSmab_Diagnostic_Debug(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Debug);
            return rsSmab_Diagnostic_Debug;
        }
    }
}
