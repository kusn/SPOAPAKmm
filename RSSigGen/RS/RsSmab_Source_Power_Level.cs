using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Level commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Source_Power_Level
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Power_Level_Immediate _immediate;

        //
        // Сводка:
        //     Immediate commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Power_Level_Immediate Immediate => _immediate ?? (_immediate = new RsSmab_Source_Power_Level_Immediate(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Power_Level(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Level", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Power_Level Clone()
        {
            RsSmab_Source_Power_Level rsSmab_Source_Power_Level = new RsSmab_Source_Power_Level(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Power_Level);
            return rsSmab_Source_Power_Level;
        }
    }
}
