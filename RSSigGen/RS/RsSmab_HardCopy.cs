using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_HardCopy_Device _device;

        private RsSmab_HardCopy_File _file;

        private RsSmab_HardCopy_Image _image;

        private RsSmab_HardCopy_Execute _execute;

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_Device Device => _device ?? (_device = new RsSmab_HardCopy_Device(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     File commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_HardCopy_File File => _file ?? (_file = new RsSmab_HardCopy_File(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Image commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_Image Image => _image ?? (_image = new RsSmab_HardCopy_Image(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_HardCopy_Execute Execute => _execute ?? (_execute = new RsSmab_HardCopy_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     HCOPy:DATA
        //     Transfers the hard copy data directly as a NByte stream to the remote client.
        //     data: block data
        public byte[] Data => _grpBase.IO.QueryBinaryData("HCOPy:DATA?");

        //
        // Сводка:
        //     HCOPy:REGion
        //     Selects the area to be copied. You can create a snapshot of the screen or an
        //     active dialog.
        //     region: ALL| DIALog
        public HcopyRegionEnum Region
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:REGion?").ToScpiEnum<HcopyRegionEnum>();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:REGion " + value.ToScpiString());
            }
        }

        internal RsSmab_HardCopy(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("HardCopy", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_HardCopy Clone()
        {
            RsSmab_HardCopy rsSmab_HardCopy = new RsSmab_HardCopy(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_HardCopy);
            return rsSmab_HardCopy;
        }
    }
}
