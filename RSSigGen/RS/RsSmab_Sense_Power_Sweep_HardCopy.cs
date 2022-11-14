using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 24
    public class RsSmab_Sense_Power_Sweep_HardCopy
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_Device _device;

        private RsSmab_Sense_Power_Sweep_HardCopy_File _file;

        private RsSmab_Sense_Power_Sweep_HardCopy_Execute _execute;

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 7
        public RsSmab_Sense_Power_Sweep_HardCopy_Device Device => _device ?? (_device = new RsSmab_Sense_Power_Sweep_HardCopy_Device(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     File commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 15
        public RsSmab_Sense_Power_Sweep_HardCopy_File File => _file ?? (_file = new RsSmab_Sense_Power_Sweep_HardCopy_File(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_HardCopy_Execute Execute => _execute ?? (_execute = new RsSmab_Sense_Power_Sweep_HardCopy_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DATA
        //     Queries the measurement data directly. The data is transferred to the remote
        //     client as data stream. Readable ASCII data is available for hardcopy language
        //     CSV. The representation of the values depends on the selected orientation for
        //     the CSV format.
        //     data: block data
        public byte[] Data => _grpBase.IO.QueryBinaryData("SENSe:POWer:SWEep:HCOPy:DATA?");

        internal RsSmab_Sense_Power_Sweep_HardCopy(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("HardCopy", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy rsSmab_Sense_Power_Sweep_HardCopy = new RsSmab_Sense_Power_Sweep_HardCopy(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy);
            return rsSmab_Sense_Power_Sweep_HardCopy;
        }
    }
}
