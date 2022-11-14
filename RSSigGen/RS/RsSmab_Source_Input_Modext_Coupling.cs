using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Input_Modext_Coupling commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
    public class RsSmab_Source_Input_Modext_Coupling
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

        internal RsSmab_Source_Input_Modext_Coupling(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Coupling", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(InputIxRepCap), _grpBase.GroupName, "RepCapInputIx", InputIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Input_Modext_Coupling Clone()
        {
            RsSmab_Source_Input_Modext_Coupling rsSmab_Source_Input_Modext_Coupling = new RsSmab_Source_Input_Modext_Coupling(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Input_Modext_Coupling);
            return rsSmab_Source_Input_Modext_Coupling;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:COUPling<CH>
        //     Selects the coupling mode for an externally applied modulation signal.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Coupling")
        //
        // Параметры:
        //   coupling:
        //     AC| DC AC Passes the AC signal component of the modulation signal. DC Passes
        //     the modulation signal with both components, AC and DC. For active external exponential
        //     AM, automatically sets [:SOURcehw]:INPut:MODext:COUPlingchDC.
        public void Set(AcDcEnum coupling)
        {
            Set(coupling, InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:COUPling<CH>
        //     Selects the coupling mode for an externally applied modulation signal.
        //
        // Параметры:
        //   coupling:
        //     AC| DC AC Passes the AC signal component of the modulation signal. DC Passes
        //     the modulation signal with both components, AC and DC. For active external exponential
        //     AM, automatically sets [:SOURcehw]:INPut:MODext:COUPlingchDC.
        //
        //   inputIx:
        //     Repeated capability selector
        public void Set(AcDcEnum coupling, InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("SOURce<HwInstance>:INPut:MODext:COUPling" + repCapCmdValue + " " + coupling.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:COUPling<CH>
        //     Selects the coupling mode for an externally applied modulation signal.
        //     coupling: AC| DC AC Passes the AC signal component of the modulation signal.
        //     DC Passes the modulation signal with both components, AC and DC. For active external
        //     exponential AM, automatically sets [:SOURcehw]:INPut:MODext:COUPlingchDC.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Coupling")
        public AcDcEnum Get()
        {
            return Get(InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:INPut:MODext:COUPling<CH>
        //     Selects the coupling mode for an externally applied modulation signal.
        //     coupling: AC| DC AC Passes the AC signal component of the modulation signal.
        //     DC Passes the modulation signal with both components, AC and DC. For active external
        //     exponential AM, automatically sets [:SOURcehw]:INPut:MODext:COUPlingchDC.
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public AcDcEnum Get(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            return _grpBase.IO.QueryString("SOURce<HwInstance>:INPut:MODext:COUPling" + repCapCmdValue + "?").ToScpiEnum<AcDcEnum>();
        }
    }
}
