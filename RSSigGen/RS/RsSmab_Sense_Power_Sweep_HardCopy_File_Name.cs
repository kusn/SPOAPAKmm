using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 15
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto _auto;

        //
        // Сводка:
        //     Auto commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 14
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto Auto => _auto ?? (_auto = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]
        //     Creates of selects a file for storing the hardcopy after the SWEep command is
        //     sent. The directory is either defined with the command method RsSmab.MassMemory.CurrentDirectory
        //     or the path is specified together with the file name. Access to the file via
        //     remote control is possible using the commands of the MMEM-Subsystem. In contrast,
        //     command SWEep:HCOPy:DATA transfers the hardcopy contents directly to the remote
        //     client where they can be further processed.
        //     name: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:FILE:NAME?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Name", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_File_Name rsSmab_Sense_Power_Sweep_HardCopy_File_Name = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_File_Name);
            return rsSmab_Sense_Power_Sweep_HardCopy_File_Name;
        }
    }
}
