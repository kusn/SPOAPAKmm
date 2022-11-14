using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Logging commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Logging
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Logging_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Logging_State State => _state ?? (_state = new RsSmab_Sense_Power_Logging_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Logging(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Logging", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Logging Clone()
        {
            RsSmab_Sense_Power_Logging rsSmab_Sense_Power_Logging = new RsSmab_Sense_Power_Logging(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Logging);
            return rsSmab_Sense_Power_Logging;
        }
    }
}
