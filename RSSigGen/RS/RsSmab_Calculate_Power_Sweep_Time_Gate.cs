using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time_Gate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_Average _average;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_Feed _feed;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_Maximum _maximum;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_Start _start;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_State _state;

        private RsSmab_Calculate_Power_Sweep_Time_Gate_Stop _stop;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to GateRepCap.Default
        //     Default value after init: GateRepCap.Nr1
        public GateRepCap RepCapGate
        {
            get
            {
                return (GateRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Average commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_Average Average => _average ?? (_average = new RsSmab_Calculate_Power_Sweep_Time_Gate_Average(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Feed commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_Feed Feed => _feed ?? (_feed = new RsSmab_Calculate_Power_Sweep_Time_Gate_Feed(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Maximum commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_Maximum Maximum => _maximum ?? (_maximum = new RsSmab_Calculate_Power_Sweep_Time_Gate_Maximum(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Start commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_Start Start => _start ?? (_start = new RsSmab_Calculate_Power_Sweep_Time_Gate_Start(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_State State => _state ?? (_state = new RsSmab_Calculate_Power_Sweep_Time_Gate_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Stop commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calculate_Power_Sweep_Time_Gate_Stop Stop => _stop ?? (_stop = new RsSmab_Calculate_Power_Sweep_Time_Gate_Stop(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power_Sweep_Time_Gate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Gate", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(GateRepCap), _grpBase.GroupName, "RepCapGate", GateRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power_Sweep_Time_Gate Clone()
        {
            RsSmab_Calculate_Power_Sweep_Time_Gate rsSmab_Calculate_Power_Sweep_Time_Gate = new RsSmab_Calculate_Power_Sweep_Time_Gate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power_Sweep_Time_Gate);
            return rsSmab_Calculate_Power_Sweep_Time_Gate;
        }
    }
}
