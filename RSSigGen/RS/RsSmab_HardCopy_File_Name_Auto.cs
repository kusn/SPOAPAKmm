using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_HardCopy_File_Name_Auto_Directory _directory;

        private RsSmab_HardCopy_File_Name_Auto_File _file;

        //
        // Сводка:
        //     Directory commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_HardCopy_File_Name_Auto_Directory Directory => _directory ?? (_directory = new RsSmab_HardCopy_File_Name_Auto_Directory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     File commands group
        //     Sub-classes count: 4
        //     Commands count: 2
        //     Total commands count: 7
        public RsSmab_HardCopy_File_Name_Auto_File File => _file ?? (_file = new RsSmab_HardCopy_File_Name_Auto_File(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:STATe
        //     Activates automatic naming of the hard copy files.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("HCOPy:FILE:NAME:AUTO:STATe?");
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO
        //     Queries path and file name of the hardcopy file, if you have enabled Automatic
        //     Naming.
        //     auto: string
        public string Value => _grpBase.IO.QueryString("HCOPy:FILE:NAME:AUTO?").TrimStringResponse();

        internal RsSmab_HardCopy_File_Name_Auto(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Auto", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_HardCopy_File_Name_Auto Clone()
        {
            RsSmab_HardCopy_File_Name_Auto rsSmab_HardCopy_File_Name_Auto = new RsSmab_HardCopy_File_Name_Auto(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_HardCopy_File_Name_Auto);
            return rsSmab_HardCopy_File_Name_Auto;
        }
    }
}
