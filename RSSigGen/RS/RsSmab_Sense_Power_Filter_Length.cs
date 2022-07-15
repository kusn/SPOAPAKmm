using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_Length commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Filter_Length
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Filter_Length_Auto _auto;

        private RsSmab_Sense_Power_Filter_Length_User _user;

        //
        // Сводка:
        //     Auto commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Filter_Length_Auto Auto => _auto ?? (_auto = new RsSmab_Sense_Power_Filter_Length_Auto(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     User commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Filter_Length_User User => _user ?? (_user = new RsSmab_Sense_Power_Filter_Length_User(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Filter_Length(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Length", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Filter_Length Clone()
        {
            RsSmab_Sense_Power_Filter_Length rsSmab_Sense_Power_Filter_Length = new RsSmab_Sense_Power_Filter_Length(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Filter_Length);
            return rsSmab_Sense_Power_Filter_Length;
        }
    }
}
