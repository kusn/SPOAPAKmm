using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Aperture_Default commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Aperture_Default
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Aperture_Default_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Aperture_Default_State State => _state ?? (_state = new RsSmab_Sense_Power_Aperture_Default_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Aperture_Default(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Default", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Aperture_Default Clone()
        {
            RsSmab_Sense_Power_Aperture_Default rsSmab_Sense_Power_Aperture_Default = new RsSmab_Sense_Power_Aperture_Default(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Aperture_Default);
            return rsSmab_Sense_Power_Aperture_Default;
        }
    }
}
