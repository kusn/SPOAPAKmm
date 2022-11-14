using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Package commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_System_Package
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Package_ChartDisplay _chartDisplay;

        private RsSmab_System_Package_GuiFramework _guiFramework;

        private RsSmab_System_Package_Qt _qt;

        //
        // Сводка:
        //     ChartDisplay commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Package_ChartDisplay ChartDisplay => _chartDisplay ?? (_chartDisplay = new RsSmab_System_Package_ChartDisplay(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     GuiFramework commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Package_GuiFramework GuiFramework => _guiFramework ?? (_guiFramework = new RsSmab_System_Package_GuiFramework(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Qt commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Package_Qt Qt => _qt ?? (_qt = new RsSmab_System_Package_Qt(_grpBase.Core, _grpBase));

        internal RsSmab_System_Package(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Package", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Package Clone()
        {
            RsSmab_System_Package rsSmab_System_Package = new RsSmab_System_Package(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Package);
            return rsSmab_System_Package;
        }
    }
}
