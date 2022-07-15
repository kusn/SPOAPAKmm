using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Display commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Display
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Display_Permanent _permanent;

        //
        // Сводка:
        //     Permanent commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Sense_Power_Display_Permanent Permanent => _permanent ?? (_permanent = new RsSmab_Sense_Power_Display_Permanent(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Display(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Display", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Display Clone()
        {
            RsSmab_Sense_Power_Display rsSmab_Sense_Power_Display = new RsSmab_Sense_Power_Display(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Display);
            return rsSmab_Sense_Power_Display;
        }
    }
}
