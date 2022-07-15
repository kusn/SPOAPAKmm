using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Window_Power_Sweep_Background
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:[WINDow]:[POWer]:SWEep:BACKground:COLor
        //     Defines the background color of the measurement diagram. The selected color applies
        //     also to the hardcopy of the diagram.
        //     color: BLACk| WHITe
        public DiagBgColorEnum Color
        {
            get
            {
                return _grpBase.IO.QueryString("DISPlay:WINDow:POWer:SWEep:BACKground:COLor?").ToScpiEnum<DiagBgColorEnum>();
            }
            set
            {
                _grpBase.IO.Write("DISPlay:WINDow:POWer:SWEep:BACKground:COLor " + value.ToScpiString());
            }
        }

        internal RsSmab_Display_Window_Power_Sweep_Background(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Background", core, parent);
        }
    }
}
