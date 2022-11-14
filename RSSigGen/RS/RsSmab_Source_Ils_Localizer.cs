using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Localizer commands group definition
    //     Sub-classes count: 6
    //     Commands count: 6
    //     Total commands count: 32
    public class RsSmab_Source_Ils_Localizer
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Ils_Localizer_Comid _comid;

        private RsSmab_Source_Ils_Localizer_Ddm _ddm;

        private RsSmab_Source_Ils_Localizer_Frequency _frequency;

        private RsSmab_Source_Ils_Localizer_Icao _icao;

        private RsSmab_Source_Ils_Localizer_Llobe _llobe;

        private RsSmab_Source_Ils_Localizer_Rlobe _rlobe;

        //
        // Сводка:
        //     Comid commands group
        //     Sub-classes count: 1
        //     Commands count: 10
        //     Total commands count: 12
        public RsSmab_Source_Ils_Localizer_Comid Comid => _comid ?? (_comid = new RsSmab_Source_Ils_Localizer_Comid(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ddm commands group
        //     Sub-classes count: 0
        //     Commands count: 8
        //     Total commands count: 8
        public RsSmab_Source_Ils_Localizer_Ddm Ddm => _ddm ?? (_ddm = new RsSmab_Source_Ils_Localizer_Ddm(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Ils_Localizer_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Ils_Localizer_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Icao commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Localizer_Icao Icao => _icao ?? (_icao = new RsSmab_Source_Ils_Localizer_Icao(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Llobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Localizer_Llobe Llobe => _llobe ?? (_llobe = new RsSmab_Source_Ils_Localizer_Llobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Rlobe commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Ils_Localizer_Rlobe Rlobe => _rlobe ?? (_rlobe = new RsSmab_Source_Ils_Localizer_Rlobe(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:MODE
        //     Sets the operating mode for the ILS localizer modulation signal.
        //     mode: NORM| LLOBe| RLOBe NORM ILS localizer modulation is active. LLOBe Amplitude
        //     modulation of the output signal with the left lobe (90Hz) signal component of
        //     the ILS localizer signal is active. RLOBe Amplitude modulation of the output
        //     signal with the right lobe (150Hz) signal component of the ILS localizer signal
        //     is active.
        public AvionicIlsLocModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:MODE?").ToScpiEnum<AvionicIlsLocModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:PHASe
        //     Sets the phase between the modulation signals of the left and right antenna lobe
        //     of the ILS localizer signal. The zero crossing of the right lobe (150Hz) signal
        //     serves as a reference. The angle refers to the period of the signal of the right
        //     antenna lobe.
        //     phase: float Range: -60 to 120
        public double Phase
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:PHASe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:PHASe " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:SDM
        //     Sets the arithmetic sum of the modulation depths of the left lobe (90 Hz) and
        //     right lobe (150 Hz) for the ILS localizer signal contents. The RMS modulation
        //     depth of the sum signal depends on the phase setting of both modulation tones.
        //     sdm: float Range: 0 to 100
        public double Sdm
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:LOCalizer:SDM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:SDM " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:SOURce
        //     Sets the modulation source for the avionic standard modulation. If external modulation
        //     source is set, the external signal is added to the internal signal. Switching
        //     off the internal modulation source is not possible.
        //     ilsLocSource: INT| INT,EXT| EXT INT Internal modulation source is used. EXT|INT,EXT
        //     An external modulation source is used, additional to the internal modulation
        //     source. The external signal is input at the Ext connector.
        public AvionicExtAmEnum Source
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:LOCalizer:SOURce?").ToScpiEnum<AvionicExtAmEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:SOURce " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:LOCalizer:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Ils_Localizer(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Localizer", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Ils_Localizer Clone()
        {
            RsSmab_Source_Ils_Localizer rsSmab_Source_Ils_Localizer = new RsSmab_Source_Ils_Localizer(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Ils_Localizer);
            return rsSmab_Source_Ils_Localizer;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:PRESet
        //     Sets the parameters of the ILS localizer component to their default values (*RST
        //     values specified for the commands) . For other ILS preset commands, see ILS:PRESet.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ILS:LOCalizer:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:LOCalizer:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ILS:LOCalizer:PRESet", opcTimeoutMs);
        }
    }
}
