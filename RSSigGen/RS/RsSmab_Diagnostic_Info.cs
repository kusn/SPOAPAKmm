using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Info_Ecount _ecount;

        private RsSmab_Diagnostic_Info_Otime _otime;

        private RsSmab_Diagnostic_Info_PoCount _poCount;

        //
        // Сводка:
        //     Ecount commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 4
        //     Repeated Capability: ErrorCountRepCap, default value after init: ErrorCountRepCap.Nr1
        public RsSmab_Diagnostic_Info_Ecount Ecount => _ecount ?? (_ecount = new RsSmab_Diagnostic_Info_Ecount(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Otime commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Diagnostic_Info_Otime Otime => _otime ?? (_otime = new RsSmab_Diagnostic_Info_Otime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     PoCount commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Diagnostic_Info_PoCount PoCount => _poCount ?? (_poCount = new RsSmab_Diagnostic_Info_PoCount(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Info(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Info", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Info Clone()
        {
            RsSmab_Diagnostic_Info rsSmab_Diagnostic_Info = new RsSmab_Diagnostic_Info(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Info);
            return rsSmab_Diagnostic_Info;
        }
    }
}
