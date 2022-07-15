using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Ukey
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Display_Ukey_Add _add;

        //
        // Сводка:
        //     Add commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Display_Ukey_Add Add => _add ?? (_add = new RsSmab_Display_Ukey_Add(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     DISPlay:UKEY:NAME
        //     No additional help available
        public string Name
        {
            set
            {
                _grpBase.IO.Write("DISPlay:UKEY:NAME " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     DISPlay:UKEY:SCPI
        //     No additional help available
        public string Scpi
        {
            set
            {
                _grpBase.IO.Write("DISPlay:UKEY:SCPI " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Display_Ukey(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ukey", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Display_Ukey Clone()
        {
            RsSmab_Display_Ukey rsSmab_Display_Ukey = new RsSmab_Display_Ukey(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Display_Ukey);
            return rsSmab_Display_Ukey;
        }
    }
}
