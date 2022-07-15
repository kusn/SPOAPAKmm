using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Output_Alternate commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Source_Roscillator_Output_Alternate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Roscillator_Output_Alternate_Frequency _frequency;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Roscillator_Output_Alternate_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Roscillator_Output_Alternate_Frequency(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Roscillator_Output_Alternate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Alternate", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Roscillator_Output_Alternate Clone()
        {
            RsSmab_Source_Roscillator_Output_Alternate rsSmab_Source_Roscillator_Output_Alternate = new RsSmab_Source_Roscillator_Output_Alternate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Roscillator_Output_Alternate);
            return rsSmab_Source_Roscillator_Output_Alternate;
        }
    }
}
