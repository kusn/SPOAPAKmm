using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Window
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Display_Window_Power _power;

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Display_Window_Power Power => _power ?? (_power = new RsSmab_Display_Window_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Display_Window(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Window", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Display_Window Clone()
        {
            RsSmab_Display_Window rsSmab_Display_Window = new RsSmab_Display_Window(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Display_Window);
            return rsSmab_Display_Window;
        }
    }
}
