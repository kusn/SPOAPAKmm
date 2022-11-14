using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Read commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
    public class RsSmab_Read
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Read_Power _power;

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
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Read_Power Power => _power ?? (_power = new RsSmab_Read_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Read(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Read", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(ChannelRepCap), _grpBase.GroupName, "RepCapChannel", ChannelRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Read Clone()
        {
            RsSmab_Read rsSmab_Read = new RsSmab_Read(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Read);
            return rsSmab_Read;
        }
    }
}
