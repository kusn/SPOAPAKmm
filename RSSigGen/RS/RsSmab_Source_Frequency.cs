using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency commands group definition
    //     Sub-classes count: 6
    //     Commands count: 8
    //     Total commands count: 50
    public class RsSmab_Source_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Multiplier _multiplier;

        private RsSmab_Source_Frequency_Phase _phase;

        private RsSmab_Source_Frequency_Pll _pll;

        private RsSmab_Source_Frequency_Step _step;

        private RsSmab_Source_Frequency_Cw _cw;

        private RsSmab_Source_Frequency_Fixed _fixed;

        //
        // Сводка:
        //     Multiplier commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 31
        public RsSmab_Source_Frequency_Multiplier Multiplier => _multiplier ?? (_multiplier = new RsSmab_Source_Frequency_Multiplier(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Phase commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Source_Frequency_Phase Phase => _phase ?? (_phase = new RsSmab_Source_Frequency_Phase(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pll commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Frequency_Pll Pll => _pll ?? (_pll = new RsSmab_Source_Frequency_Pll(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Frequency_Step Step => _step ?? (_step = new RsSmab_Source_Frequency_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Cw commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Frequency_Cw Cw => _cw ?? (_cw = new RsSmab_Source_Frequency_Cw(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Fixed commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Frequency_Fixed Fixed => _fixed ?? (_fixed = new RsSmab_Source_Frequency_Fixed(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:CENTer
        //     Sets the center frequency of the sweep. See "Correlating Parameters in Sweep
        //     Mode".
        //     center: float Range: 300 kHz to RFmax, Unit: Hz
        public double Center
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:CENTer?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:CENTer " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:FREQuency
        //     No additional help available
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:FREQuency " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MANual
        //     Sets the frequency and triggers a sweep step manually if SWEep:MODE MAN.
        //     manual: float You can select any frequency within the setting range, where: STARt
        //     is set with FREQuency:STARt STOP is set with FREQuency:STOP OFFSet is set with
        //     FREQuency:OFFSet Range: (STARt + OFFSet) to (STOP + OFFSet) , Unit: Hz
        public double Manual
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:MANual?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MANual " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MODE
        //     Sets the frequency mode for generating the RF output signal. The selected mode
        //     determines the parameters to be used for further frequency settings.
        //     mode: CW| FIXed | SWEep| LIST CW|FIXed Sets the fixed frequency mode. CW and
        //     FIXed are synonyms. The instrument operates at a defined frequency, set with
        //     command [:​SOURcehw]:​FREQuency[:​CW|FIXed]. SWEep Sets sweep mode. The instrument
        //     processes frequency (and level) settings in defined sweep steps. Set the range
        //     and current frequency with the commands: FREQuency:STARt and FREQuency:STOP,
        //     FREQuency:CENTer, FREQuency:SPAN, FREQuency:MANual LIST Sets list mode. The instrument
        //     processes frequency and level settings by means of values loaded from a list.
        //     To configure list mode settings, use the commands of the "SOURce:LIST Subsystem".
        public FreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:MODE?").ToScpiEnum<FreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:OFFSet
        //     Sets the frequency offset fFREQ:OFFSet of a downstream instrument. The parameters
        //     offset fFREQ:OFFSer and multiplier NFREQ:MULT affect the frequency value set
        //     with the command [:​SOURce<hw>]:​FREQuency[:​CW|FIXed]. The query [:​SOURce<hw>]:​FREQuency[:​CW|FIXed]
        //     returns the value corresponding to the formula: fFREQ = fRFout * NFREQ:MULT +
        //     fFREQ:OFFSer See "RF frequency and level display with a downstream instrument".
        //     Note: The offset also affects RF frequency sweep.
        //     offset: float
        public double Offset
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:OFFSet?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:OFFSet " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:SPAN
        //     Sets the sapn of the frequency sweep range. See "Correlating Parameters in Sweep
        //     Mode".
        //     span: float Full freqeuncy range
        public double Span
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:SPAN?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:SPAN " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:STARt
        //     Sets the start frequency for the RF sweep. See "Correlating Parameters in Sweep
        //     Mode".
        //     start: float Range: 300kHz to RFmax
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:STOP
        //     Sets the stop frequency range for the RF sweep. See "Correlating Parameters in
        //     Sweep Mode".
        //     stop: float Range: 300kHz to RFmax, Unit: Hz
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency Clone()
        {
            RsSmab_Source_Frequency rsSmab_Source_Frequency = new RsSmab_Source_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency);
            return rsSmab_Source_Frequency;
        }
    }
}
