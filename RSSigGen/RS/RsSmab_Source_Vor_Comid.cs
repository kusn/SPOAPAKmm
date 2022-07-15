using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor_Comid commands group definition
    //     Sub-classes count: 1
    //     Commands count: 10
    //     Total commands count: 12
    public class RsSmab_Source_Vor_Comid
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Vor_Comid_Code _code;

        //
        // Сводка:
        //     Code commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Vor_Comid_Code Code => _code ?? (_code = new RsSmab_Source_Vor_Comid_Code(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:DASH
        //     Sets the length of a Morse code dash.
        //     dash: float Range: 0.05 to 1
        public double Dash
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:DASH?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:DASH " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:DEPTh
        //     Sets the AM modulation depth of the COM/ID signal.
        //     depth: float Range: 0 to 100
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:DEPTh " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:DOT
        //     Sets the length of a Morse code dot. If the time schema is set to standard, the
        //     dash length (= 3 times dot length) , symbol space (= dot length) and letter space
        //     (= 3 times dot length) is also determined by this entry.
        //     dot: float Range: 0.05 to 1
        public double Dot
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:DOT?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:DOT " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:FREQuency
        //     Sets the frequency of the COM/ID signal.
        //     frequency: float Range: 0.1 to 20E3
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:FREQuency " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:LETTer
        //     Sets the length of a Morse code letter space.
        //     letter: float Range: 0.05 to 1, Unit: s
        public double Letter
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:LETTer?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:LETTer " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:PERiod
        //     Sets the period of the COM/ID signal.
        //     period: float Range: 0 to 120
        public double Period
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:PERiod?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:PERiod " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:REPeat
        //     No additional help available
        public int Repeat
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:VOR:COMid:REPeat?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:VOR:COMid:REPeat {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:SYMBol
        //     Sets the length of the Morse code symbol space.
        //     symbol: float Range: 0.05 to 1
        public double Symbol
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:COMid:SYMBol?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:SYMBol " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:TSCHema
        //     Sets the time schema of the Morse code for the COM/ID signal.
        //     tschema: STD| USER STD Activates the standard time schema of the Morse code.
        //     The set dot length determines the dash length, which is 3 times the dot length.
        //     USER Activates the user-defined time schema of the Morse code. Dot and dash length,
        //     as well as symbol and letter space can be set separately.
        public AvionicComIdTimeSchemEnum Tschema
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:VOR:COMid:TSCHema?").ToScpiEnum<AvionicComIdTimeSchemEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:TSCHema " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:COMid:[STATe]
        //     Enables/disables the COM/ID signal.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:VOR:COMid:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:COMid:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Vor_Comid(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Comid", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Vor_Comid Clone()
        {
            RsSmab_Source_Vor_Comid rsSmab_Source_Vor_Comid = new RsSmab_Source_Vor_Comid(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Vor_Comid);
            return rsSmab_Source_Vor_Comid;
        }
    }
}
