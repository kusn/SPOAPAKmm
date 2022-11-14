using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 15
    public class RsSmab_Sense_Power_Sweep_HardCopy_File
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_File_Name _name;

        //
        // Сводка:
        //     Name commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 15
        public RsSmab_Sense_Power_Sweep_HardCopy_File_Name Name => _name ?? (_name = new RsSmab_Sense_Power_Sweep_HardCopy_File_Name(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Sweep_HardCopy_File(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("File", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_File Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_File rsSmab_Sense_Power_Sweep_HardCopy_File = new RsSmab_Sense_Power_Sweep_HardCopy_File(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_File);
            return rsSmab_Sense_Power_Sweep_HardCopy_File;
        }
    }
}
