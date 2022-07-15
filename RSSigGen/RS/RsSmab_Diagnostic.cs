using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_BgInfo _bgInfo;

        private RsSmab_Diagnostic_Debug _debug;

        private RsSmab_Diagnostic_Eeprom _eeprom;

        private RsSmab_Diagnostic_Info _info;

        private RsSmab_Diagnostic_Point _point;

        private RsSmab_Diagnostic_Service _service;

        private RsSmab_Diagnostic_Measure _measure;

        //
        // Сводка:
        //     BgInfo commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Diagnostic_BgInfo BgInfo => _bgInfo ?? (_bgInfo = new RsSmab_Diagnostic_BgInfo(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Debug commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Diagnostic_Debug Debug => _debug ?? (_debug = new RsSmab_Diagnostic_Debug(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Eeprom commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 4
        public RsSmab_Diagnostic_Eeprom Eeprom => _eeprom ?? (_eeprom = new RsSmab_Diagnostic_Eeprom(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Info commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 8
        public RsSmab_Diagnostic_Info Info => _info ?? (_info = new RsSmab_Diagnostic_Info(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Point commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Diagnostic_Point Point => _point ?? (_point = new RsSmab_Diagnostic_Point(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Service commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Diagnostic_Service Service => _service ?? (_service = new RsSmab_Diagnostic_Service(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Measure commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Diagnostic_Measure Measure => _measure ?? (_measure = new RsSmab_Diagnostic_Measure(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Diagnostic", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic Clone()
        {
            RsSmab_Diagnostic rsSmab_Diagnostic = new RsSmab_Diagnostic(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic);
            return rsSmab_Diagnostic;
        }
    }
}
