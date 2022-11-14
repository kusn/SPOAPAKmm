using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_HardCopy_File_Name_Auto _auto;

        //
        // Сводка:
        //     Auto commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 11
        public RsSmab_HardCopy_File_Name_Auto Auto => _auto ?? (_auto = new RsSmab_HardCopy_File_Name_Auto(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]
        //     Determines the file name and path to save the hard copy, provided automatic naming
        //     is disabled. Note: If you have enabled automatic naming, the instrument automatically
        //     generates the file name and directory, see "Automatic Naming".
        //     name: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:FILE:NAME?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_HardCopy_File_Name(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Name", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_HardCopy_File_Name Clone()
        {
            RsSmab_HardCopy_File_Name rsSmab_HardCopy_File_Name = new RsSmab_HardCopy_File_Name(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_HardCopy_File_Name);
            return rsSmab_HardCopy_File_Name;
        }
    }
}
