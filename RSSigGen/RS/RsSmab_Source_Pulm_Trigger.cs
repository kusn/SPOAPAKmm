using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Trigger commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Trigger
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Trigger_External _external;

        //
        // Сводка:
        //     External commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Pulm_Trigger_External External => _external ?? (_external = new RsSmab_Source_Pulm_Trigger_External(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRIGger:MODE
        //     Selects a trigger mode - auto, single, external, external single or external
        //     gated - for generating the modulation signal.
        //     mode: AUTO| EXTernal| EGATe| SINGle| ESINgle
        public PulsTrigModeWithSingleEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRIGger:MODE?").ToScpiEnum<PulsTrigModeWithSingleEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRIGger:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Pulm_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Trigger Clone()
        {
            RsSmab_Source_Pulm_Trigger rsSmab_Source_Pulm_Trigger = new RsSmab_Source_Pulm_Trigger(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Trigger);
            return rsSmab_Source_Pulm_Trigger;
        }
    }
}
