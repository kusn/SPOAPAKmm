using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Phase commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Source_Frequency_Phase
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Frequency_Phase_Continuous _continuous;

        //
        // Сводка:
        //     Continuous commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Source_Frequency_Phase_Continuous Continuous => _continuous ?? (_continuous = new RsSmab_Source_Frequency_Phase_Continuous(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Frequency_Phase(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Phase", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Frequency_Phase Clone()
        {
            RsSmab_Source_Frequency_Phase rsSmab_Source_Frequency_Phase = new RsSmab_Source_Frequency_Phase(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Frequency_Phase);
            return rsSmab_Source_Frequency_Phase;
        }
    }
}
