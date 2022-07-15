using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Element commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
    public class RsSmab_Slist_Element
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Slist_Element_Mapping _mapping;

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
        //     Mapping commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Slist_Element_Mapping Mapping => _mapping ?? (_mapping = new RsSmab_Slist_Element_Mapping(_grpBase.Core, _grpBase));

        internal RsSmab_Slist_Element(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Element", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(ChannelRepCap), _grpBase.GroupName, "RepCapChannel", ChannelRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Slist_Element Clone()
        {
            RsSmab_Slist_Element rsSmab_Slist_Element = new RsSmab_Slist_Element(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Slist_Element);
            return rsSmab_Slist_Element;
        }
    }
}
