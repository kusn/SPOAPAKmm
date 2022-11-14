using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Window_Power_Sweep_Grid
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:[WINDow]:[POWer]:SWEep:GRID:STATe
        //     Indicates a grid in the diagram.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:WINDow:POWer:SWEep:GRID:STATe?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:WINDow:POWer:SWEep:GRID:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Display_Window_Power_Sweep_Grid(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Grid", core, parent);
        }
    }
}
