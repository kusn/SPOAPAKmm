using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 120
    //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
    public class RsSmab_Sense
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Unit _unit;

        private RsSmab_Sense_Power _power;

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
        //     Unit commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Sense_Unit Unit => _unit ?? (_unit = new RsSmab_Sense_Unit(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 15
        //     Commands count: 0
        //     Total commands count: 119
        public RsSmab_Sense_Power Power => _power ?? (_power = new RsSmab_Sense_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Sense(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sense", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(ChannelRepCap), _grpBase.GroupName, "RepCapChannel", ChannelRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense Clone()
        {
            RsSmab_Sense rsSmab_Sense = new RsSmab_Sense(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense);
            return rsSmab_Sense;
        }
    }
}
