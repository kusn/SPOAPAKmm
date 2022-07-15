using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Catalog
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_MassMemory_Catalog_Length _length;

        //
        // Сводка:
        //     Length commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_MassMemory_Catalog_Length Length => _length ?? (_length = new RsSmab_MassMemory_Catalog_Length(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     MMEMory:CATalog
        //     Returns the content of a particular directory.
        public string Value => _grpBase.IO.QueryString("MMEMory:CATalog?").TrimStringResponse();

        internal RsSmab_MassMemory_Catalog(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Catalog", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_MassMemory_Catalog Clone()
        {
            RsSmab_MassMemory_Catalog rsSmab_MassMemory_Catalog = new RsSmab_MassMemory_Catalog(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_MassMemory_Catalog);
            return rsSmab_MassMemory_Catalog;
        }
    }
}
