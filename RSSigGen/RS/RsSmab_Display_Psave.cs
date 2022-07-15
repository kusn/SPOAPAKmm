using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Psave
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:PSAVe:HOLDoff
        //     Sets the wait time for the screen saver mode of the display.
        //     holdoffTimeMin: integer Range: 1 to 60, Unit: minute
        public int Holdoff
        {
            get
            {
                return _grpBase.IO.QueryInt32("DISPlay:PSAVe:HOLDoff?");
            }
            set
            {
                _grpBase.IO.Write($"DISPlay:PSAVe:HOLDoff {value}");
            }
        }

        //
        // Сводка:
        //     DISPlay:PSAVe:[STATe]
        //     Activates the screen saver mode of the display. We recommend that you use this
        //     mode to protect the display, if you operate the instrument in remote control.
        //     To define the wait time, use the command method RsSmab.Display.Psave.Holdoff.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:PSAVe:STATe?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:PSAVe:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Display_Psave(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Psave", core, parent);
        }
    }
}
