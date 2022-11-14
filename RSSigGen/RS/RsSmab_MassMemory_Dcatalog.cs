using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory_Dcatalog
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_MassMemory_Dcatalog_Length _length;

        //
        // Сводка:
        //     Length commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_MassMemory_Dcatalog_Length Length => _length ?? (_length = new RsSmab_MassMemory_Dcatalog_Length(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     MMEMory:DCATalog
        //     Returns the subdirectories of a particular directory.
        public string Value => _grpBase.IO.QueryString("MMEMory:DCATalog?").TrimStringResponse();

        internal RsSmab_MassMemory_Dcatalog(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dcatalog", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_MassMemory_Dcatalog Clone()
        {
            RsSmab_MassMemory_Dcatalog rsSmab_MassMemory_Dcatalog = new RsSmab_MassMemory_Dcatalog(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_MassMemory_Dcatalog);
            return rsSmab_MassMemory_Dcatalog;
        }
    }
}
