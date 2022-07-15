using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_Afixed
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Output_Afixed_Range _range;

        //
        // Сводка:
        //     Range commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Output_Afixed_Range Range => _range ?? (_range = new RsSmab_Output_Afixed_Range(_grpBase.Core, _grpBase));

        internal RsSmab_Output_Afixed(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Afixed", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Output_Afixed Clone()
        {
            RsSmab_Output_Afixed rsSmab_Output_Afixed = new RsSmab_Output_Afixed(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Output_Afixed);
            return rsSmab_Output_Afixed;
        }
    }
}
