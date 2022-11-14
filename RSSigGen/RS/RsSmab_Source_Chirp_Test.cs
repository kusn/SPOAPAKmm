using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp_Test commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Chirp_Test
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Chirp_Test_Measurement _measurement;

        //
        // Сводка:
        //     Measurement commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Chirp_Test_Measurement Measurement => _measurement ?? (_measurement = new RsSmab_Source_Chirp_Test_Measurement(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Chirp_Test(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Test", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Chirp_Test Clone()
        {
            RsSmab_Source_Chirp_Test rsSmab_Source_Chirp_Test = new RsSmab_Source_Chirp_Test(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Chirp_Test);
            return rsSmab_Source_Chirp_Test;
        }
    }
}
