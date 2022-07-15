using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Initiate_FreqSweep _freqSweep;

        private RsSmab_Initiate_LffSweep _lffSweep;

        private RsSmab_Initiate_List _list;

        private RsSmab_Initiate_Psweep _psweep;

        private RsSmab_Initiate_Power _power;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to ChannelRepCap.Default
        //     Default value after init: ChannelRepCap.Nr1
        public ChannelRepCap RepCapChannel
        {
            get
            {
                return (ChannelRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     FreqSweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Initiate_FreqSweep FreqSweep => _freqSweep ?? (_freqSweep = new RsSmab_Initiate_FreqSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     LffSweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Initiate_LffSweep LffSweep => _lffSweep ?? (_lffSweep = new RsSmab_Initiate_LffSweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     List commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Initiate_List List => _list ?? (_list = new RsSmab_Initiate_List(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Psweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Initiate_Psweep Psweep => _psweep ?? (_psweep = new RsSmab_Initiate_Psweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Initiate_Power Power => _power ?? (_power = new RsSmab_Initiate_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Initiate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Initiate", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(ChannelRepCap), _grpBase.GroupName, "RepCapChannel", ChannelRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Initiate Clone()
        {
            RsSmab_Initiate rsSmab_Initiate = new RsSmab_Initiate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Initiate);
            return rsSmab_Initiate;
        }
    }
}
