using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gs_Ddm commands group definition
    //     Sub-classes count: 0
    //     Commands count: 8
    //     Total commands count: 8
    public class RsSmab_Source_Ils_Gs_Ddm
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:COUPling
        //     Selects if the DDM value is fixed or is changed with a change of sum of modulation
        //     depths (SDM, see SDM) .
        //     coupling: FIXed| SDM
        public AvionicIlsDdmCoupEnum Coupling
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:DDM:COUPling?").ToScpiEnum<AvionicIlsDdmCoupEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:COUPling " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:CURRent
        //     Sets the DDM value alternatively as a current by means of the ILS indicating
        //     instrument. The instrument current is calculated according to: DDM Current µA
        //     = DDM Depth [%] × 857,125 µA A variation of the instrument current automatically
        //     leads to a variation of the DDM value and the DDM value in dB.
        //     current: float Range: -8.57125E-4 to 8.57125E-4
        public double Current
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:DDM:CURRent?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:CURRent " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:DIRection
        //     Sets the simulation mode for the ILS glide slope modulation signal. A change
        //     of the setting automatically changes the sign of the DDM value.
        //     direction: UP| DOWN UP The 150-Hz modulation signal is predominant, the DDM value
        //     is negative (the airplane is too low, it must climb) . DOWN The 90-Hz modulation
        //     signal is predominant, the DDM value is positive (the airplane is too high, it
        //     must descend) .
        public UpDownDirectionEnum Direction
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:DDM:DIRection?").ToScpiEnum<UpDownDirectionEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:DIRection " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:LOGarithmic
        //     Sets the depth of modulation value for ILS glide slope modulation in dB. See
        //     also [:​SOURce<hw>]:​ILS[:​GS|GSLope]:​DDM[:​DEPTh].
        //     logarithmic: float Range: -999.9 to 999.9
        public double Logarithmic
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:DDM:LOGarithmic?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:LOGarithmic " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:PCT
        //     Sets the difference in depth of modulation between the signal of the upper lobe
        //     (90 Hz) and the lower lobe (150 Hz) . The maximum value equals the sum of the
        //     modulation depths of the 90 Hz and the 150 Hz tone. See also [:​SOURce<hw>]:​ILS[:​GS|GSLope]:​DDM[:​DEPTh].
        //     pct: float Range: -80.0 to 80.0
        public double Pct
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:DDM:PCT?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:PCT " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:POLarity
        //     Sets the polarity for DDM calculation (see [:​SOURce<hw>]:​ILS[:​GS|GSLope]:​DDM[:​DEPTh])
        //     . The DDM depth calculation depends on the selected polarity: Table Header: The
        //     effect depends on the selected mode: - Polarity 90 Hz - 150 Hz (default setting)
        //     : DDM = [ AM(90 Hz) - AM (150 Hz) ] / 100%, - Polarity 150 Hz - 90 Hz: DDM =
        //     [ AM(150 Hz) - AM (90 Hz) ] / 100%
        //     polarity: P90_150| P150_90
        public AvionicIlsDdmPolEnum Polarity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:DDM:POLarity?").ToScpiEnum<AvionicIlsDdmPolEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:POLarity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:STEP
        //     Sets the variation of the difference in depth of modulation via the rotary knob.
        //     ddmStep: DECimal| PREDefined
        public AvionicDdmStepEnum Step
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:DDM:STEP?").ToScpiEnum<AvionicDdmStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:STEP " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:DDM:[DEPTh]
        //     Sets the difference in depth of modulation between the signal of the upper/left
        //     lobe (90 Hz) and the lower/right lobe (150 Hz) . The maximum value equals the
        //     sum of the modulation depths of the 90 Hz and the 150 Hz tone. The following
        //     is true: ILS:GS|GSL:DDM:DEPTh = (AM(90Hz) - AM(150Hz) )/100% A variation of the
        //     DDM value automatically leads to a variation of the DDM value in dB and the value
        //     of the instrument current.
        //     depth: float Range: -0.8 to 0.8
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:DDM:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:DDM:DEPTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Gs_Ddm(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ddm", core, parent);
        }
    }
}
