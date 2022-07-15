using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Display_Annotation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DISPlay:ANNotation:AMPLitude
        //     Indicates asterisks instead of the level values in the status bar.
        //     state: 0| 1| OFF| ON
        public bool Amplitude
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:ANNotation:AMPLitude?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:ANNotation:AMPLitude " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     DISPlay:ANNotation:FREQuency
        //     Indicates asterisks instead of the frequency values in the status bar.
        //     state: 0| 1| OFF| ON
        public bool Frequency
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:ANNotation:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:ANNotation:FREQuency " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     DISPlay:ANNotation:[ALL]
        //     Displays asterisks instead of the level and frequency values in the status bar
        //     of the instrument. We recommend that you use this mode if you operate the instrument
        //     in remote control.
        //     state: 0| 1| OFF| ON
        public bool All
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DISPlay:ANNotation:ALL?");
            }
            set
            {
                _grpBase.IO.Write("DISPlay:ANNotation:ALL " + value.ToBooleanString());
            }
        }

        internal RsSmab_Display_Annotation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Annotation", core, parent);
        }
    }
}
