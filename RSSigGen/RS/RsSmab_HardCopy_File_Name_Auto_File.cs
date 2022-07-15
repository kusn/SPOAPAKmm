using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto_File
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_HardCopy_File_Name_Auto_File_Day _day;

        private RsSmab_HardCopy_File_Name_Auto_File_Month _month;

        private RsSmab_HardCopy_File_Name_Auto_File_Prefix _prefix;

        private RsSmab_HardCopy_File_Name_Auto_File_Year _year;

        //
        // Сводка:
        //     Day commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_File_Name_Auto_File_Day Day => _day ?? (_day = new RsSmab_HardCopy_File_Name_Auto_File_Day(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Month commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_File_Name_Auto_File_Month Month => _month ?? (_month = new RsSmab_HardCopy_File_Name_Auto_File_Month(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Prefix commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_HardCopy_File_Name_Auto_File_Prefix Prefix => _prefix ?? (_prefix = new RsSmab_HardCopy_File_Name_Auto_File_Prefix(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Year commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_File_Name_Auto_File_Year Year => _year ?? (_year = new RsSmab_HardCopy_File_Name_Auto_File_Year(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:[FILE]:NUMBer
        //     Queries the number that is used as part of the file name for the next hard copy
        //     in automatic mode. At the beginning, the count starts at 0. The R&S SMA100B searches
        //     the specified output directory for the highest number in the stored files. It
        //     increases this number by one to achieve a unique name for the new file. The resulting
        //     auto number is appended to the resulting file name with at least three digits.
        //     number: integer Range: 0 to 999999
        public int Number => _grpBase.IO.QueryInt32("HCOPy:FILE:NAME:AUTO:FILE:NUMBer?");

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:FILE
        //     Queries the name of the automatically named hard copy file. An automatically
        //     generated file name consists of: <Prefix><YYYY><MM><DD><Number>.<Format>. You
        //     can activate each component separately, to individually design the file name.
        //     file: string
        public string Value => _grpBase.IO.QueryString("HCOPy:FILE:NAME:AUTO:FILE?").TrimStringResponse();

        internal RsSmab_HardCopy_File_Name_Auto_File(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("File", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_HardCopy_File_Name_Auto_File Clone()
        {
            RsSmab_HardCopy_File_Name_Auto_File rsSmab_HardCopy_File_Name_Auto_File = new RsSmab_HardCopy_File_Name_Auto_File(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_HardCopy_File_Name_Auto_File);
            return rsSmab_HardCopy_File_Name_Auto_File;
        }
    }
}
