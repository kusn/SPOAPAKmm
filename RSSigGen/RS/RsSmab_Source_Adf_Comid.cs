using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Adf_Comid commands group definition
    //     Sub-classes count: 0
    //     Commands count: 10
    //     Total commands count: 10
    public class RsSmab_Source_Adf_Comid
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:CODE
        //     Sets the coding of the COM/ID signal by the international short name of the airport
        //     (e.g. MUC for the Munich airport) . The COM/ID tone is sent according to the
        //     selected code, see "Morse Code Settings". If no coding is set, the COM/ID tone
        //     is sent uncoded (key down) .
        //     code: string
        public string Code
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ADF:COMid:CODE?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:CODE " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:DASH
        //     Sets the length of a Morse code dash.
        //     dash: float Range: 50E-3 to 1
        public double Dash
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:DASH?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:DASH " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:DEPTh
        //     Sets the AM modulation depth of the COM/ID signal.
        //     depth: float Range: 0 to 100
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:DEPTh " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:DOT
        //     Sets the length of a Morse code dot.
        //     dot: float Range: 50E-3 to 1
        public double Dot
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:DOT?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:DOT " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:FREQuency
        //     Sets the frequency of the COM/ID signal.
        //     frequency: float Range: 0.1 to 20E3
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:FREQuency " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:LETTer
        //     Sets the length of a Morse code letter space.
        //     letter: float Range: 50E-3 to 1
        public double Letter
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:LETTer?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:LETTer " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:PERiod
        //     Sets the period of the COM/ID signal.
        //     period: float Range: 0 to 120
        public double Period
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:PERiod?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:PERiod " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:SYMBol
        //     Sets the length of the Morse code symbol space.
        //     symbol: float Range: 50E-3 to 1
        public double Symbol
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ADF:COMid:SYMBol?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:SYMBol " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:TSCHema
        //     Sets the time schema of the Morse code for the COM/ID signal.
        //     tschema: STD| USER
        public AvionicComIdTimeSchemEnum Tschema
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ADF:COMid:TSCHema?").ToScpiEnum<AvionicComIdTimeSchemEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:TSCHema " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:COMid:[STATe]
        //     Enables/disables the COM/ID signal.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ADF:COMid:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:COMid:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Adf_Comid(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Comid", core, parent);
        }
    }
}
