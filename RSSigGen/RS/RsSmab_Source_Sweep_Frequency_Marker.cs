using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency_Marker commands group definition
    //     Sub-classes count: 2
    //     Commands count: 1
    //     Total commands count: 3
    //     Repeated Capability: MarkerRepCap, default value after init: MarkerRepCap.Nr0
    public class RsSmab_Source_Sweep_Frequency_Marker
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Frequency_Marker_Frequency _frequency;

        private RsSmab_Source_Sweep_Frequency_Marker_Fstate _fstate;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to MarkerRepCap.Default
        //     Default value after init: MarkerRepCap.Nr0
        public MarkerRepCap RepCapMarker
        {
            get
            {
                return (MarkerRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Frequency_Marker_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Sweep_Frequency_Marker_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Fstate commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Frequency_Marker_Fstate Fstate => _fstate ?? (_fstate = new RsSmab_Source_Sweep_Frequency_Marker_Fstate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer:ACTive
        //     Defines the marker signal to be output with a higher voltage than all other markers.
        //     active: NONE| M01| M02| M03| M04| M05| M06| M07| M08| M09| M10
        public SweMarkActiveEnum Active
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:FREQuency:MARKer:ACTive?").ToScpiEnum<SweMarkActiveEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:MARKer:ACTive " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Frequency_Marker(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Marker", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(MarkerRepCap), _grpBase.GroupName, "RepCapMarker", MarkerRepCap.Nr0);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep_Frequency_Marker Clone()
        {
            RsSmab_Source_Sweep_Frequency_Marker rsSmab_Source_Sweep_Frequency_Marker = new RsSmab_Source_Sweep_Frequency_Marker(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep_Frequency_Marker);
            return rsSmab_Source_Sweep_Frequency_Marker;
        }
    }
}
