using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 6
    public class RsSmab_Sense_Power_Filter
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Filter_Length _length;

        private RsSmab_Sense_Power_Filter_NsRatio _nsRatio;

        private RsSmab_Sense_Power_Filter_Sonce _sonce;

        private RsSmab_Sense_Power_Filter_Type _type;

        //
        // Сводка:
        //     Length commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Sense_Power_Filter_Length Length => _length ?? (_length = new RsSmab_Sense_Power_Filter_Length(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     NsRatio commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Sense_Power_Filter_NsRatio NsRatio => _nsRatio ?? (_nsRatio = new RsSmab_Sense_Power_Filter_NsRatio(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sonce commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Filter_Sonce Sonce => _sonce ?? (_sonce = new RsSmab_Sense_Power_Filter_Sonce(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Type commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Filter_Type Type => _type ?? (_type = new RsSmab_Sense_Power_Filter_Type(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Filter(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Filter", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Filter Clone()
        {
            RsSmab_Sense_Power_Filter rsSmab_Sense_Power_Filter = new RsSmab_Sense_Power_Filter(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Filter);
            return rsSmab_Sense_Power_Filter;
        }
    }
}
