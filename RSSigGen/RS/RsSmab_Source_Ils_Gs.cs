using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Gs commands group definition
    //     Sub-classes count: 5
    //     Commands count: 6
    //     Total commands count: 20
    public class RsSmab_Source_Ils_Gs
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Ils_Gs_Ddm _ddm;

        private RsSmab_Source_Ils_Gs_Frequency _frequency;

        private RsSmab_Source_Ils_Gs_Icao _icao;

        private RsSmab_Source_Ils_Gs_Llobe _llobe;

        private RsSmab_Source_Ils_Gs_Ulobe _ulobe;

        //
        // Сводка:
        //     Ddm commands group
        //     Sub-classes count: 0
        //     Commands count: 8
        //     Total commands count: 8
        public RsSmab_Source_Ils_Gs_Ddm Ddm => _ddm ?? (_ddm = new RsSmab_Source_Ils_Gs_Ddm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Ils_Gs_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Ils_Gs_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Icao commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gs_Icao Icao => _icao ?? (_icao = new RsSmab_Source_Ils_Gs_Icao(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Llobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gs_Llobe Llobe => _llobe ?? (_llobe = new RsSmab_Source_Ils_Gs_Llobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ulobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Gs_Ulobe Ulobe => _ulobe ?? (_ulobe = new RsSmab_Source_Ils_Gs_Ulobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GS:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:GS:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:MODE
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
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:MODE?").ToScpiEnum<AvionicIlsGsModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:PHASe
        //     Sets the phase between the modulation signals of the upper and lower antenna
        //     lobe of the ILS glide slope signal. Zero crossing of the lower lobe (150Hz) signal
        //     serves as a reference. The angle refers to the period of the signal of the right
        //     antenna lobe.
        //     phase: float Range: -60 to 120
        public double Phase
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:PHASe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:PHASe " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:SDM
        //     Sets the arithmetic sum of the modulation depths of the upper lobe (90 Hz) and
        //     lower lobe (150 Hz) for the ILS glide slope signal contents. The RMS modulation
        //     depth of the sum signal depends on the phase setting of both modulation tones.
        //     sdm: float Range: 0 to 100
        public double Sdm
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:GS:SDM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:SDM " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:[GS]:SOURce
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
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:GS:SOURce?").ToScpiEnum<AvionicExtAmEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:SOURce " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Ils_Gs(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gs", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Ils_Gs Clone()
        {
            RsSmab_Source_Ils_Gs rsSmab_Source_Ils_Gs = new RsSmab_Source_Ils_Gs(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Ils_Gs);
            return rsSmab_Source_Ils_Gs;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GS:PRESet
        //     Sets the parameters of the ILS glide slope component to their default values
        //     (*RST values specified for the commands) . For other ILS preset commands, see
        //     ILS:PRESet.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ILS:GS:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:GS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ILS:GS:PRESet", opcTimeoutMs);
        }
    }
}
