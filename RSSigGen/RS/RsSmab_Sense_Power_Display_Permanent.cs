using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Display_Permanent commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Display_Permanent
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Display_Permanent_Priority _priority;

        private RsSmab_Sense_Power_Display_Permanent_State _state;

        //
        // Сводка:
        //     Priority commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Display_Permanent_Priority Priority => _priority ?? (_priority = new RsSmab_Sense_Power_Display_Permanent_Priority(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Display_Permanent_State State => _state ?? (_state = new RsSmab_Sense_Power_Display_Permanent_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Display_Permanent(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Permanent", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Display_Permanent Clone()
        {
            RsSmab_Sense_Power_Display_Permanent rsSmab_Sense_Power_Display_Permanent = new RsSmab_Sense_Power_Display_Permanent(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Display_Permanent);
            return rsSmab_Sense_Power_Display_Permanent;
        }
    }
}
