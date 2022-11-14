using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File commands group definition
    //     Sub-classes count: 4
    //     Commands count: 2
    //     Total commands count: 10
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day _day;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Month _month;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix _prefix;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year _year;

        //
        // Сводка:
        //     Day commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day Day => _day ?? (_day = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Month commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Month Month => _month ?? (_month = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Month(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Prefix commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix Prefix => _prefix ?? (_prefix = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Year commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year Year => _year ?? (_year = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:NUMBer
        //     Queries the generated number in the automatic file name.
        //     number: integer Range: 0 to 999999
        public int Number => _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:NUMBer?");

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:FILE
        //     Queries the file name generated with the automatic naming settings. Note: As
        //     default the automatically generated file name is composed of: >PAth>/<Prefix><YYYY><MM><DD><Number>.<Format>.
        //     Each component can be deactivated/ activated separately to individually design
        //     the file name.
        //     file: string
        public string Value => _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE?").TrimStringResponse();

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("File", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File);
            return rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File;
        }
    }
}
