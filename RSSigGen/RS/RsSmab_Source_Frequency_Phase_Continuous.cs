using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Phase_Continuous commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Source_Frequency_Phase_Continuous
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:PHASe:CONTinuous:HIGH
        //     Queries the minimum frequency of the frequency range for phase continuous settings.
        //     The minimum frequency of the frequency range depends on the mode selected with
        //     the command FREQuency:PHASe:CONTinuous:MODE.
        //     high: float Range: 1E5 to 6E9, Unit: Hz
        public double High => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:HIGH?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:PHASe:CONTinuous:LOW
        //     Queries the minimum frequency of the frequency range for phase continuous settings.
        //     The minimum frequency of the frequency range depends on the mode selected with
        //     the command FREQuency:PHASe:CONTinuous:MODE.
        //     low: float Range: 1E5 to 6E9, Unit: Hz
        public double Low => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:LOW?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:PHASe:CONTinuous:MODE
        //     Selects the mode that determines the frequency range for the phase continuity.
        //     To query the frequency range, use the commands FREQuency:PHASe:CONTinuous:HIGH
        //     and FREQuency:PHASe:CONTinuous:LOW
        //     mode: NARRow| WIDE NARRow Small frequency range, asymmetrically around the RF
        //     frequency. WIDE Large frequency range, symmetrically around the RF frequency.
        public FilterWidthEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:MODE?").ToScpiEnum<FilterWidthEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:PHASe:CONTinuous:STATe
        //     Activates phase continuity of the RF frequency. The frequency range is limited
        //     and varies depending on the set RF frequency. You can query the range with the
        //     commands FREQuency:PHASe:CONTinuous:HIGH and FREQuency:PHASe:CONTinuous:LOW.
        //     Note: Restricted structure of command line. In phase continuous mode, the R&S
        //     SMA100B only processes the first command of a command line and ignores further
        //     commands if they are on the same line.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:PHASe:CONTinuous:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Frequency_Phase_Continuous(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Continuous", core, parent);
        }
    }
}
