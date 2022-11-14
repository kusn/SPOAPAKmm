using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto commands group definition
    //     Sub-classes count: 2
    //     Commands count: 2
    //     Total commands count: 14
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory _directory;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File _file;

        //
        // Сводка:
        //     Directory commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory Directory => _directory ?? (_directory = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     File commands group
        //     Sub-classes count: 4
        //     Commands count: 2
        //     Total commands count: 10
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File File => _file ?? (_file = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:STATe
        //     Activates/deactivates automatic naming of the hardcopy files.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO
        //     No additional help available
        public string Value => _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO?").TrimStringResponse();

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Auto", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto);
            return rsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto;
        }
    }
}
