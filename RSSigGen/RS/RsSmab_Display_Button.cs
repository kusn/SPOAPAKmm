using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Button
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:BUTTon:BRIGhtness
        //     Sets the brightness of the [RF on/off] key.
        //     buttonBrightnes: integer Range: 1 to 20
        public int Brightness
        {
            get
            {
                return _grpBase.IO.QueryInt32("DISPlay:BUTTon:BRIGhtness?");
            }
            set
            {
                _grpBase.IO.Write($"DISPlay:BUTTon:BRIGhtness {value}");
            }
        }

        internal RsSmab_Display_Button(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Button", core, parent);
        }
    }
}
