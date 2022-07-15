using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pgenerator_Output commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pgenerator_Output
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PGENerator:OUTPut:POLarity
        //     Sets the polarity of the pulse output signal.
        //     polarity: NORMal| INVerted NORMal Outputs the pulse signal during the pulse width,
        //     that means during the high state. INVerted Inverts the pulse output signal polarity.
        //     The pulse output signal is suppressed during the pulse width, but provided during
        //     the low state.
        public NormalInvertedEnum Polarity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PGENerator:OUTPut:POLarity?").ToScpiEnum<NormalInvertedEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PGENerator:OUTPut:POLarity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PGENerator:OUTPut:[STATe]
        //     Activates the output of the pulse modulation signal.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:PGENerator:OUTPut:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PGENerator:OUTPut:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Pgenerator_Output(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Output", core, parent);
        }
    }
}
