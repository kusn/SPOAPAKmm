using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am commands group definition
    //     Sub-classes count: 4
    //     Commands count: 3
    //     Total commands count: 11
    //     Repeated Capability: GeneratorIxRepCap, default value after init: GeneratorIxRepCap.Nr1
    public class RsSmab_Source_Am
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Am_Depth _depth;

        private RsSmab_Source_Am_Deviation _deviation;

        private RsSmab_Source_Am_Sensitivity _sensitivity;

        private RsSmab_Source_Am_State _state;

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
        //     Depth commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_Source_Am_Depth Depth => _depth ?? (_depth = new RsSmab_Source_Am_Depth(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Deviation commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_Deviation Deviation => _deviation ?? (_deviation = new RsSmab_Source_Am_Deviation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensitivity commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Source_Am_Sensitivity Sensitivity => _sensitivity ?? (_sensitivity = new RsSmab_Source_Am_Sensitivity(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_State State => _state ?? (_state = new RsSmab_Source_Am_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:AM:MODE
        //     Selects the mode of the amplitude modulation. [:SOURce<hw>]:AM:MODE > SCAN sets
        //     [:SOURce<hw>]:AM:TYPE > EXPonential. For active external exponential AM, automatically
        //     sets [:SOURce<hw>]:INPut:MODext:COUPling<ch> > DC.
        //     amMode: SCAN| NORMal
        public AmModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:AM:MODE?").ToScpiEnum<AmModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:AM:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM:RATio
        //     Sets the deviation ratio (path#2 to path#1) in percent.
        //     ratio: float Range: 0 to 100
        public double Ratio
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:AM:RATio?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:AM:RATio " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM:TYPE
        //     Selects the type of amplitude modulation. For [:SOURce<hw>]:AM:MODE SCAN, only
        //     EXPonential is available. For active external exponential AM, automatically sets
        //     [:SOURce<hw>]:INPut:MODext:COUPling<ch>DC.
        //     amType: LINear| EXPonential
        public AmTypeEnum Type
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:AM:TYPE?").ToScpiEnum<AmTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:AM:TYPE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Am(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Am", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(GeneratorIxRepCap), _grpBase.GroupName, "RepCapGeneratorIx", GeneratorIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Am Clone()
        {
            RsSmab_Source_Am rsSmab_Source_Am = new RsSmab_Source_Am(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Am);
            return rsSmab_Source_Am;
        }
    }
}
