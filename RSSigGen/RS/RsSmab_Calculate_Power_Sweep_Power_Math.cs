using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Power_Math
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep_Power_Math_State _state;

        private RsSmab_Calculate_Power_Sweep_Power_Math_Subtract _subtract;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to MathRepCap.Default
        //     Default value after init: MathRepCap.Nr1
        public MathRepCap RepCapMath
        {
            get
            {
                return (MathRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Power_Math_State State => _state ?? (_state = new RsSmab_Calculate_Power_Sweep_Power_Math_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Subtract commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Power_Math_Subtract Subtract => _subtract ?? (_subtract = new RsSmab_Calculate_Power_Sweep_Power_Math_Subtract(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power_Sweep_Power_Math(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Math", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(MathRepCap), _grpBase.GroupName, "RepCapMath", MathRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power_Sweep_Power_Math Clone()
        {
            RsSmab_Calculate_Power_Sweep_Power_Math rsSmab_Calculate_Power_Sweep_Power_Math = new RsSmab_Calculate_Power_Sweep_Power_Math(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power_Sweep_Power_Math);
            return rsSmab_Calculate_Power_Sweep_Power_Math;
        }
    }
}
