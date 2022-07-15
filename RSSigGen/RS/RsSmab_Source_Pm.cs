using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pm commands group definition
    //     Sub-classes count: 3
    //     Commands count: 3
    //     Total commands count: 8
    //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
    public class RsSmab_Source_Pm
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pm_Deviation _deviation;

        private RsSmab_Source_Pm_Source _source;

        private RsSmab_Source_Pm_State _state;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to GeneratorIxRepCap.Default
        //     Default value after init: GeneratorIxRepCap.Nr1
        public GeneratorIxRepCap RepCapGeneratorIx
        {
            get
            {
                return (GeneratorIxRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Deviation commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Pm_Deviation Deviation => _deviation ?? (_deviation = new RsSmab_Source_Pm_Deviation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Pm_Source Source => _source ?? (_source = new RsSmab_Source_Pm_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Pm_State State => _state ?? (_state = new RsSmab_Source_Pm_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PM:MODE
        //     Selects the mode for the phase modulation.
        //     mode: HBANdwidth| HDEViation| LNOise HBANdwidth Sets the maximum available bandwidth.
        //     HDEViation Sets the maximum range for ΦM deviation. LNOise Selects a phase modulation
        //     mode with phase noise and spurious characteristics close to CW mode.
        public PmModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PM:MODE?").ToScpiEnum<PmModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PM:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM:RATio
        //     Sets the deviation ratio (path2 to path1) in percent.
        //     ratio: float Range: 0 to 100
        public double Ratio
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PM:RATio?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PM:RATio " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PM:SENSitivity
        //     Queries the sensitivity of the externally applied signal for phase modulation.
        //     The returned value reports the sensitivity in RAD/V. It is assigned to the voltage
        //     value for full modulation of the input.
        //     sensitivity: float
        public double Sensitivity => _grpBase.IO.QueryDouble("SOURce<HwInstance>:PM:SENSitivity?");

        internal RsSmab_Source_Pm(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pm", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(GeneratorIxRepCap), _grpBase.GroupName, "RepCapGeneratorIx", GeneratorIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pm Clone()
        {
            RsSmab_Source_Pm rsSmab_Source_Pm = new RsSmab_Source_Pm(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pm);
            return rsSmab_Source_Pm;
        }
    }
}
