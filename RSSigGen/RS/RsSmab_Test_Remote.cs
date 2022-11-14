using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Remote commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Test_Remote
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Test_Remote_Lockout _lockout;

        //
        // Сводка:
        //     Lockout commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Test_Remote_Lockout Lockout => _lockout ?? (_lockout = new RsSmab_Test_Remote_Lockout(_grpBase.Core, _grpBase));

        internal RsSmab_Test_Remote(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Remote", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Test_Remote Clone()
        {
            RsSmab_Test_Remote rsSmab_Test_Remote = new RsSmab_Test_Remote(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Test_Remote);
            return rsSmab_Test_Remote;
        }
    }
}
