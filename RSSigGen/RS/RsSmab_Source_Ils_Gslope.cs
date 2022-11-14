using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gslope commands group definition
    //     Sub-classes count: 5
    //     Commands count: 6
    //     Total commands count: 20
    public class RsSmab_Source_Ils_Gslope
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Ils_Gslope_Ddm _ddm;

        private RsSmab_Source_Ils_Gslope_Frequency _frequency;

        private RsSmab_Source_Ils_Gslope_Icao _icao;

        private RsSmab_Source_Ils_Gslope_Llobe _llobe;

        private RsSmab_Source_Ils_Gslope_Ulobe _ulobe;

        //
        // Сводка:
        //     Ddm commands group
        //     Sub-classes count: 0
        //     Commands count: 8
        //     Total commands count: 8
        public RsSmab_Source_Ils_Gslope_Ddm Ddm => _ddm ?? (_ddm = new RsSmab_Source_Ils_Gslope_Ddm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Ils_Gslope_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Ils_Gslope_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Icao commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gslope_Icao Icao => _icao ?? (_icao = new RsSmab_Source_Ils_Gslope_Icao(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Llobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gslope_Llobe Llobe => _llobe ?? (_llobe = new RsSmab_Source_Ils_Gslope_Llobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ulobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gslope_Ulobe Ulobe => _ulobe ?? (_ulobe = new RsSmab_Source_Ils_Gslope_Ulobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GSLope:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:GSLope:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:MODE
        //     Sets the operating mode for the ILS glide slope modulation signal.
        //     mode: NORM| ULOBe| LLOBe NORM ILS glide slope modulation is active. ULOBe Amplitude
        //     modulation of the output signal with the upper lobe (90Hz) signal component of
        //     the ILS glide slope signal is active. LLOBe Amplitude modulation of the output
        //     signal with the lower lobe (150Hz) signal component of the ILS glide slope signal
        //     is active.
        public AvionicIlsGsModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GSLope:MODE?").ToScpiEnum<AvionicIlsGsModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:PHASe
        //     Sets the phase between the modulation signals of the upper and lower antenna
        //     lobe of the ILS glide slope signal. Zero crossing of the lower lobe (150Hz) signal
        //     serves as a reference. The angle refers to the period of the signal of the right
        //     antenna lobe.
        //     phase: float Range: -60 to 120
        public double Phase
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GSLope:PHASe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:PHASe " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:SDM
        //     Sets the arithmetic sum of the modulation depths of the upper lobe (90 Hz) and
        //     lower lobe (150 Hz) for the ILS glide slope signal contents. The RMS modulation
        //     depth of the sum signal depends on the phase setting of both modulation tones.
        //     sdm: float Range: 0 to 100
        public double Sdm
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GSLope:SDM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:SDM " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GSLope]:SOURce
        //     Sets the modulation source for the avionic standard modulation. If external modulation
        //     source is set, the external signal is added to the internal signal. Switching
        //     off the internal modulation source is not possible.
        //     ilsGsSource: INT| INT,EXT| EXT INT Internal modulation source is used. EXT|INT,EXT
        //     An external modulation source is used, additional to the internal modulation
        //     source. The external signal is input at the Ext connector.
        public AvionicExtAmEnum Source
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GSLope:SOURce?").ToScpiEnum<AvionicExtAmEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:SOURce " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Ils_Gslope(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gslope", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Ils_Gslope Clone()
        {
            RsSmab_Source_Ils_Gslope rsSmab_Source_Ils_Gslope = new RsSmab_Source_Ils_Gslope(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Ils_Gslope);
            return rsSmab_Source_Ils_Gslope;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GSLope:PRESet
        //     Sets the parameters of the ILS glide slope component to their default values
        //     (*RST values specified for the commands) . For other ILS preset commands, see
        //     ILS:PRESet.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ILS:GSLope:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GSLope:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GSLope:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ILS:GSLope:PRESet", opcTimeoutMs);
        }
    }
}
