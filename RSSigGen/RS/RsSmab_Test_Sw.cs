using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Sw commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Test_Sw
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Test_Sw_Scmd _scmd;

        //
        // Сводка:
        //     Scmd commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Test_Sw_Scmd Scmd => _scmd ?? (_scmd = new RsSmab_Test_Sw_Scmd(_grpBase.Core, _grpBase));

        internal RsSmab_Test_Sw(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sw", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Test_Sw Clone()
        {
            RsSmab_Test_Sw rsSmab_Test_Sw = new RsSmab_Test_Sw(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Test_Sw);
            return rsSmab_Test_Sw;
        }
    }
}
