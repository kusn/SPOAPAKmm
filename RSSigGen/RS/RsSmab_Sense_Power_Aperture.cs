using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Aperture commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Aperture
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Aperture_Default _default;

        private RsSmab_Sense_Power_Aperture_Time _time;

        //
        // Сводка:
        //     Default commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Sense_Power_Aperture_Default Default => _default ?? (_default = new RsSmab_Sense_Power_Aperture_Default(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Time commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Aperture_Time Time => _time ?? (_time = new RsSmab_Sense_Power_Aperture_Time(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Aperture(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Aperture", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Aperture Clone()
        {
            RsSmab_Sense_Power_Aperture rsSmab_Sense_Power_Aperture = new RsSmab_Sense_Power_Aperture(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Aperture);
            return rsSmab_Sense_Power_Aperture;
        }
    }
}
