using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp commands group definition
    //     Sub-classes count: 4
    //     Commands count: 3
    //     Total commands count: 9
    public class RsSmab_Source_Chirp
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Chirp_Compression _compression;

        private RsSmab_Source_Chirp_Pulse _pulse;

        private RsSmab_Source_Chirp_Test _test;

        private RsSmab_Source_Chirp_Trigger _trigger;

        //
        // Сводка:
        //     Compression commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Chirp_Compression Compression => _compression ?? (_compression = new RsSmab_Source_Chirp_Compression(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Chirp_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Source_Chirp_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Test commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Chirp_Test Test => _test ?? (_test = new RsSmab_Source_Chirp_Test(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Source_Chirp_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_Chirp_Trigger(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:BANDwidth
        //     Sets the modulation bandwidth of the chirp modulated signal.
        //     bandwidth: float Range: 0 to Depends on hardware variant
        public double Bandwidth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:CHIRp:BANDwidth?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:BANDwidth " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:DIRection
        //     Selects the direction of the chirp modulation.
        //     direction: DOWN| UP
        public UpDownDirectionEnum Direction
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:CHIRp:DIRection?").ToScpiEnum<UpDownDirectionEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:DIRection " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:STATe
        //     Activates the generation of a chirp modulation signal.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:CHIRp:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Chirp(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Chirp", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Chirp Clone()
        {
            RsSmab_Source_Chirp rsSmab_Source_Chirp = new RsSmab_Source_Chirp(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Chirp);
            return rsSmab_Source_Chirp;
        }
    }
}
