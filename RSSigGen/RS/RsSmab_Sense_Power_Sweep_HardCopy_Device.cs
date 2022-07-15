using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_Device commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 7
    public class RsSmab_Sense_Power_Sweep_HardCopy_Device
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_HardCopy_Device_Language _language;

        //
        // Сводка:
        //     Language commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 5
        public RsSmab_Sense_Power_Sweep_HardCopy_Device_Language Language => _language ?? (_language = new RsSmab_Sense_Power_Sweep_HardCopy_Device_Language(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice:SIZE
        //     Sets the size of the hardcopy in number of pixels. The first value of the size
        //     setting defines the width, the second value the height of the image.
        //     size: 320,240 | 640,480 | 800,600 | 1024,768
        public List<int> Size
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiIntegerArray("SENSe:POWer:SWEep:HCOPy:DEVice:SIZE?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice:SIZE " + value.ToCsvString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:DEVice
        //     Defines the output device. The setting is fixed to FILE, i.e. the hardcopy is
        //     stored in a file.
        //     device: FILE| PRINter
        public HcopyDestinationEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:DEVice?").ToScpiEnum<HcopyDestinationEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:DEVice " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_HardCopy_Device Clone()
        {
            RsSmab_Sense_Power_Sweep_HardCopy_Device rsSmab_Sense_Power_Sweep_HardCopy_Device = new RsSmab_Sense_Power_Sweep_HardCopy_Device(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_HardCopy_Device);
            return rsSmab_Sense_Power_Sweep_HardCopy_Device;
        }
    }
}
