using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Clear commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Slist_Clear
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Slist_Clear_Lan _lan;

        private RsSmab_Slist_Clear_Usb _usb;

        //
        // Сводка:
        //     Lan commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Slist_Clear_Lan Lan => _lan ?? (_lan = new RsSmab_Slist_Clear_Lan(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Usb commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Slist_Clear_Usb Usb => _usb ?? (_usb = new RsSmab_Slist_Clear_Usb(_grpBase.Core, _grpBase));

        internal RsSmab_Slist_Clear(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Clear", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Slist_Clear Clone()
        {
            RsSmab_Slist_Clear rsSmab_Slist_Clear = new RsSmab_Slist_Clear(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Slist_Clear);
            return rsSmab_Slist_Clear;
        }
    }
}
