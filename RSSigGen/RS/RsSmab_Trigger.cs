using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger commands group definition
    //     Sub-classes count: 6
    //     Commands count: 0
    //     Total commands count: 14
    //     Repeated Capability: InputIxRepCap, default value after init: InputIxRepCap.Nr1
    public class RsSmab_Trigger
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_FpSweep _fpSweep;

        private RsSmab_Trigger_FreqSweep _freqSweep;

        private RsSmab_Trigger_LffSweep _lffSweep;

        private RsSmab_Trigger_List _list;

        private RsSmab_Trigger_Psweep _psweep;

        private RsSmab_Trigger_Sweep _sweep;

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

        //
        // Сводка:
        //     FpSweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trigger_FpSweep FpSweep => _fpSweep ?? (_fpSweep = new RsSmab_Trigger_FpSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     FreqSweep commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Trigger_FreqSweep FreqSweep => _freqSweep ?? (_freqSweep = new RsSmab_Trigger_FreqSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     LffSweep commands group
        //     Sub-classes count: 2
        //     Commands count: 1
        //     Total commands count: 4
        public RsSmab_Trigger_LffSweep LffSweep => _lffSweep ?? (_lffSweep = new RsSmab_Trigger_LffSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     List commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Trigger_List List => _list ?? (_list = new RsSmab_Trigger_List(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Psweep commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Trigger_Psweep Psweep => _psweep ?? (_psweep = new RsSmab_Trigger_Psweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Trigger_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Trigger_Sweep(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(InputIxRepCap), _grpBase.GroupName, "RepCapInputIx", InputIxRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger Clone()
        {
            RsSmab_Trigger rsSmab_Trigger = new RsSmab_Trigger(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger);
            return rsSmab_Trigger;
        }
    }
}
