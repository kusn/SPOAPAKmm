using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Window_Power_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Display_Window_Power_Sweep_Background _background;

        private RsSmab_Display_Window_Power_Sweep_Grid _grid;

        //
        // Сводка:
        //     Background commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Display_Window_Power_Sweep_Background Background => _background ?? (_background = new RsSmab_Display_Window_Power_Sweep_Background(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Grid commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Display_Window_Power_Sweep_Grid Grid => _grid ?? (_grid = new RsSmab_Display_Window_Power_Sweep_Grid(_grpBase.Core, _grpBase));

        internal RsSmab_Display_Window_Power_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Display_Window_Power_Sweep Clone()
        {
            RsSmab_Display_Window_Power_Sweep rsSmab_Display_Window_Power_Sweep = new RsSmab_Display_Window_Power_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Display_Window_Power_Sweep);
            return rsSmab_Display_Window_Power_Sweep;
        }
    }
}
