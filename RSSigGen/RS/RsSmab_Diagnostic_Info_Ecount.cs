using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info_Ecount
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Diagnostic_Info_Ecount_Info _info;

        private RsSmab_Diagnostic_Info_Ecount_Name _name;

        private RsSmab_Diagnostic_Info_Ecount_Set _set;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to ErrorCountRepCap.Default
        //     Default value after init: ErrorCountRepCap.Nr1
        public ErrorCountRepCap RepCapErrorCount
        {
            get
            {
                return (ErrorCountRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Info commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Info_Ecount_Info Info => _info ?? (_info = new RsSmab_Diagnostic_Info_Ecount_Info(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Name commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Info_Ecount_Name Name => _name ?? (_name = new RsSmab_Diagnostic_Info_Ecount_Name(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Set commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Diagnostic_Info_Ecount_Set Set => _set ?? (_set = new RsSmab_Diagnostic_Info_Ecount_Set(_grpBase.Core, _grpBase));

        internal RsSmab_Diagnostic_Info_Ecount(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ecount", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(ErrorCountRepCap), _grpBase.GroupName, "RepCapErrorCount", ErrorCountRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Diagnostic_Info_Ecount Clone()
        {
            RsSmab_Diagnostic_Info_Ecount rsSmab_Diagnostic_Info_Ecount = new RsSmab_Diagnostic_Info_Ecount(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Diagnostic_Info_Ecount);
            return rsSmab_Diagnostic_Info_Ecount;
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ErrorCountRepCap.Nr1 (settable in the interface "Ecount")
        public int Get()
        {
            return Get(ErrorCountRepCap.Default);
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>
        //     No additional help available
        //
        // Параметры:
        //   errorCount:
        //     Repeated capability selector
        public int Get(ErrorCountRepCap errorCount)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(errorCount);
            return _grpBase.IO.QueryInt32("DIAGnostic:INFO:ECOunt" + repCapCmdValue + "?");
        }
    }
}
