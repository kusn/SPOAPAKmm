using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 17
    public class RsSmab_Source_Bb
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Bb_Dme _dme;

        private RsSmab_Source_Bb_Path _path;

        private RsSmab_Source_Bb_Vor _vor;

        private RsSmab_Source_Bb_Ils _ils;

        //
        // Сводка:
        //     Dme commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 6
        public RsSmab_Source_Bb_Dme Dme => _dme ?? (_dme = new RsSmab_Source_Bb_Dme(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Path commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Bb_Path Path => _path ?? (_path = new RsSmab_Source_Bb_Path(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Vor commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 5
        public RsSmab_Source_Bb_Vor Vor => _vor ?? (_vor = new RsSmab_Source_Bb_Vor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ils commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 5
        public RsSmab_Source_Bb_Ils Ils => _ils ?? (_ils = new RsSmab_Source_Bb_Ils(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Bb(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bb", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Bb Clone()
        {
            RsSmab_Source_Bb rsSmab_Source_Bb = new RsSmab_Source_Bb(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Bb);
            return rsSmab_Source_Bb;
        }
    }
}
