using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Input_Modext_Impedance commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
    public class RsSmab_Source_Input_Modext_Impedance
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to InputIxRepCap.Default
        //     Default value after init: InputIxRepCap.Nr1
        public InputIxRepCap RepCapInputIx
        {
            get
            {
                return (InputIxRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        internal RsSmab_Source_Input_Modext_Impedance(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Impedance", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(InputIxRepCap), _grpBase.GroupName, "RepCapInputIx", InputIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Input_Modext_Impedance Clone()
        {
            RsSmab_Source_Input_Modext_Impedance rsSmab_Source_Input_Modext_Impedance = new RsSmab_Source_Input_Modext_Impedance(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Input_Modext_Impedance);
            return rsSmab_Source_Input_Modext_Impedance;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:IMPedance<CH>
        //     Sets the impedance for the externally supplied modulation signal.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Impedance")
        //
        // Параметры:
        //   impedance:
        //     G50| G600| HIGH G50 = 50 Ohm to ground G600 = 600 Ohm to ground HIGH = 100 kOhm
        //     to ground
        public void Set(ImpEnum impedance)
        {
            Set(impedance, InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:IMPedance<CH>
        //     Sets the impedance for the externally supplied modulation signal.
        //
        // Параметры:
        //   impedance:
        //     G50| G600| HIGH G50 = 50 Ohm to ground G600 = 600 Ohm to ground HIGH = 100 kOhm
        //     to ground
        //
        //   inputIx:
        //     Repeated capability selector
        public void Set(ImpEnum impedance, InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("SOURce<HwInstance>:INPut:MODext:IMPedance" + repCapCmdValue + " " + impedance.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:IMPedance<CH>
        //     Sets the impedance for the externally supplied modulation signal.
        //     impedance: G50| G600| HIGH G50 = 50 Ohm to ground G600 = 600 Ohm to ground HIGH
        //     = 100 kOhm to ground
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Impedance")
        public ImpEnum Get()
        {
            return Get(InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:IMPedance<CH>
        //     Sets the impedance for the externally supplied modulation signal.
        //     impedance: G50| G600| HIGH G50 = 50 Ohm to ground G600 = 600 Ohm to ground HIGH
        //     = 100 kOhm to ground
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public ImpEnum Get(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            return _grpBase.IO.QueryString("SOURce<HwInstance>:INPut:MODext:IMPedance" + repCapCmdValue + "?").ToScpiEnum<ImpEnum>();
        }
    }
}
