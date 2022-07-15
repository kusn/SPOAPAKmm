using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Fm commands group definition
    //     Sub-classes count: 3
    //     Commands count: 3
    //     Total commands count: 8
    //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
    public class RsSmab_Source_Fm
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Fm_Deviation _deviation;

        private RsSmab_Source_Fm_Source _source;

        private RsSmab_Source_Fm_State _state;

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
        public RsSmab_Source_Fm_Deviation Deviation => _deviation ?? (_deviation = new RsSmab_Source_Fm_Deviation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Fm_Source Source => _source ?? (_source = new RsSmab_Source_Fm_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Fm_State State => _state ?? (_state = new RsSmab_Source_Fm_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:FM:MODE
        //     Selects the mode for the frequency modulation.
        //     mode: HBANdwidth| LNOise HBANdwidth Selects maximum range for modulation bandwidth.
        //     LNOise Selects optimized phase noise and spurious characteristics with reduced
        //     modulation bandwidth and FM deviation.
        public FmModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FM:MODE?").ToScpiEnum<FmModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FM:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM:RATio
        //     Sets the deviation ratio (path2 to path1) in percent.
        //     ratio: float Range: 0 to 100
        public double Ratio
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FM:RATio?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FM:RATio " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM:SENSitivity
        //     Queries the sensitivity of the externally supplied signal for frequency modulation.
        //     The sensitivity depends on the set modulation deviation.
        //     sensitivity: float Sensitivity in Hz/V. It is assigned to the voltage value for
        //     full modulation of the input. Range: 0 to max
        public double Sensitivity => _grpBase.IO.QueryDouble("SOURce<HwInstance>:FM:SENSitivity?");

        internal RsSmab_Source_Fm(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Fm", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(GeneratorIxRepCap), _grpBase.GroupName, "RepCapGeneratorIx", GeneratorIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Fm Clone()
        {
            RsSmab_Source_Fm rsSmab_Source_Fm = new RsSmab_Source_Fm(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Fm);
            return rsSmab_Source_Fm;
        }
    }
}
