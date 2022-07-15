using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Undo commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 5
    public class RsSmab_System_Undo
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Undo_Hclear _hclear;

        private RsSmab_System_Undo_Hid _hid;

        private RsSmab_System_Undo_Hlable _hlable;

        //
        // Сводка:
        //     Hclear commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Undo_Hclear Hclear => _hclear ?? (_hclear = new RsSmab_System_Undo_Hclear(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hid commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Undo_Hid Hid => _hid ?? (_hid = new RsSmab_System_Undo_Hid(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hlable commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_Undo_Hlable Hlable => _hlable ?? (_hlable = new RsSmab_System_Undo_Hlable(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:UNDO:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:UNDO:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:UNDO:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_System_Undo(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Undo", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Undo Clone()
        {
            RsSmab_System_Undo rsSmab_System_Undo = new RsSmab_System_Undo(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Undo);
            return rsSmab_System_Undo;
        }
    }
}
