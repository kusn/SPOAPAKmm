using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Output commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Source_Roscillator_Output
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Roscillator_Output_Alternate _alternate;

        private RsSmab_Source_Roscillator_Output_Frequency _frequency;

        //
        // Сводка:
        //     Alternate commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Roscillator_Output_Alternate Alternate => _alternate ?? (_alternate = new RsSmab_Source_Roscillator_Output_Alternate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Roscillator_Output_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Roscillator_Output_Frequency(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Roscillator_Output(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Output", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Roscillator_Output Clone()
        {
            RsSmab_Source_Roscillator_Output rsSmab_Source_Roscillator_Output = new RsSmab_Source_Roscillator_Output(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Roscillator_Output);
            return rsSmab_Source_Roscillator_Output;
        }
    }
}
