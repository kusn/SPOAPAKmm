using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Localizer_Ddm commands group definition
    //     Sub-classes count: 0
    //     Commands count: 8
    //     Total commands count: 8
    public class RsSmab_Source_Ils_Localizer_Ddm
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:COUPling
        //     Selects if the DDM value is fixed or is changed with a change of sum of modulation
        //     depths (SDM, see ILS:LOCalizer:SDM) .
        //     coupling: FIXed| SDM
        public AvionicIlsDdmCoupEnum Coupling
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:DDM:COUPling?").ToScpiEnum<AvionicIlsDdmCoupEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:COUPling " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:CURRent
        //     Sets the DDM value alternatively as a current by means of the ILS indicating
        //     instrument. The instrument current is calculated according to: DDM µA = DDM ×
        //     857,1 µA A variation of the instrument current automatically leads to a variation
        //     of the DDM value and the DDM value in dB.
        //     current: float Range: -9.6775E-4 to 9.6775E-4
        public double Current
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:DDM:CURRent?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:CURRent " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:DIRection
        //     Sets the simulation mode for the ILS-LOC modulation signal. A change of the setting
        //     automatically changes the sign of the DDM value.
        //     direction: LEFT| RIGHt LEFT The 150 Hz modulation signal is predominant, the
        //     DDM value is negative (the airplane is too far to the right, it must turn to
        //     the left) . RIGHT The 90 Hz modulation signal is predominant, the DDM value is
        //     positive (the airplane is too far to the left, it must turn to the right) .
        public LeftRightDirectionEnum Direction
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:DDM:DIRection?").ToScpiEnum<LeftRightDirectionEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:DIRection " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:LOGarithmic
        //     Sets the modulation depth in dB for ILS localizer modulation. See also ILS:LOCalizer.
        //     logarithmic: float Range: -999.9 to 999.9
        public double Logarithmic
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:DDM:LOGarithmic?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:LOGarithmic " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:PCT
        //     Sets the difference in depth of modulation between the signal of the left lobe
        //     (90 Hz) and the right lobe (150 Hz) . The maximum value equals the sum of the
        //     modulation depths of the 90 Hz and the 150 Hz tone. See also ILS:LOCalizer.
        //     pct: float Range: -80.0 to 80.0
        public double Pct
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:DDM:PCT?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:PCT " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:POLarity
        //     Sets the polarity for DDM calculation (see [:SOURce<hw>]:ILS:LOCalizer:DDM[:DEPTh])
        //     . The DDM depth calculation depends on the selected polarity: Table Header: The
        //     effect depends on the selected mode: - Polarity 90 Hz - 150 Hz (default setting)
        //     : DDM = [ AM (90 Hz) - AM (150 Hz) ] / 100%, - Polarity 150 Hz - 90 Hz: DDM =
        //     [ AM (150 Hz) - AM (90 Hz) ] / 100%
        //     polarity: P90_150| P150_90
        public AvionicIlsDdmPolEnum Polarity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:DDM:POLarity?").ToScpiEnum<AvionicIlsDdmPolEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:POLarity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:STEP
        //     Sets the variation step of the DDM values.
        //     ddmStep: DECimal| PREDefined
        public AvionicDdmStepEnum Step
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:DDM:STEP?").ToScpiEnum<AvionicDdmStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:STEP " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:DDM:[DEPTh]
        //     Sets the difference in depth of modulation between the signal of the upper/left
        //     lobe (90 Hz) and the lower/right lobe (150 Hz) . The maximum value equals the
        //     sum of the modulation depths of the 90 Hz and the 150 Hz tone.The following is
        //     true: ILS:LOC:DDM:DEPTh = (AM(90Hz) - AM(150Hz) )/100% A variation of the DDM
        //     value automatically leads to a variation of the DDM value in dB and the value
        //     of the instrument current.
        //     depth: float Range: -0.4 to 0.4
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:DDM:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:DDM:DEPTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Localizer_Ddm(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ddm", core, parent);
        }
    }
}
