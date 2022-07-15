using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor commands group definition
    //     Sub-classes count: 8
    //     Commands count: 4
    //     Total commands count: 31
    public class RsSmab_Source_Vor
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Vor_Comid _comid;

        private RsSmab_Source_Vor_Frequency _frequency;

        private RsSmab_Source_Vor_Icao _icao;

        private RsSmab_Source_Vor_Reference _reference;

        private RsSmab_Source_Vor_Setting _setting;

        private RsSmab_Source_Vor_Subcarrier _subcarrier;

        private RsSmab_Source_Vor_Var _var;

        private RsSmab_Source_Vor_Bangle _bangle;

        //
        // Сводка:
        //     Comid commands group
        //     Sub-classes count: 1
        //     Commands count: 10
        //     Total commands count: 12
        public RsSmab_Source_Vor_Comid Comid => _comid ?? (_comid = new RsSmab_Source_Vor_Comid(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Vor_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Vor_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Icao commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Vor_Icao Icao => _icao ?? (_icao = new RsSmab_Source_Vor_Icao(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Vor_Reference Reference => _reference ?? (_reference = new RsSmab_Source_Vor_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Source_Vor_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Vor_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Subcarrier commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Vor_Subcarrier Subcarrier => _subcarrier ?? (_subcarrier = new RsSmab_Source_Vor_Subcarrier(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Var commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Vor_Var Var => _var ?? (_var = new RsSmab_Source_Vor_Var(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Bangle commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Vor_Bangle Bangle => _bangle ?? (_bangle = new RsSmab_Source_Vor_Bangle(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:MODE
        //     Sets the operating mode for the VOR modulation signal.
        //     mode: NORM| VAR| SUBCarrier| FMSubcarrier NORM VOR modulation is active. VAR
        //     Amplitude modulation of the output signal with the variable signal component
        //     (30Hz signal content) of the VOR signal. The modulation depth of the 30 Hz signal
        //     can be set with [:SOURcehw]:VOR:VAR[:DEPTh]. SUBCarrier Amplitude modulation
        //     of the output signal with the unmodulated FM carrier (9960Hz) of the VOR signal.
        //     The modulation depth of the 30 Hz signal can be set with [:SOURcehw]:VOR:SUBCarrier:DEPTh.
        //     FMSubcarrier Amplitude modulation of the output signal with the frequency modulated
        //     FM carrier (9960Hz) of the VOR signal. The modulation depth of the 30 Hz signal
        //     can be set with [:SOURcehw]:VOR:SUBCarrier:DEPTh. The frequency deviation can
        //     be set with [:SOURcehw]:VOR:REFerence[:DEViation].
        public AvionicVorModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:VOR:MODE?").ToScpiEnum<AvionicVorModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:SOURce
        //     Sets the modulation source for the avionic standard modulation. If external modulation
        //     source is set, the external signal is added to the internal signal. Switching
        //     off the internal modulation source is not possible.
        //     vorSourceSel: INT| INT,EXT| EXT INT Internal modulation source is used. EXT|INT,EXT
        //     An external modulation source is used, additional to the internal modulation
        //     source. The external signal is input at the Ext connector.
        public AvionicExtAmEnum Source
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:VOR:SOURce?").ToScpiEnum<AvionicExtAmEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:SOURce " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:STATe
        //     Activates/deactivates the VOR modulation.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:VOR:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Vor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Vor", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Vor Clone()
        {
            RsSmab_Source_Vor rsSmab_Source_Vor = new RsSmab_Source_Vor(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Vor);
            return rsSmab_Source_Vor;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:PRESet
        //     Sets the parameters of the digital standard to their default values (*RST values
        //     specified for the commands) . Not affected is the state set with the command
        //     SOURce<hw>:VOR:STATe.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:VOR:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:VOR:PRESet", opcTimeoutMs);
        }
    }
}
