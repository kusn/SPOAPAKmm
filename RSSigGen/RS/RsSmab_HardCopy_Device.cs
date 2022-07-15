using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_Device
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:DEVice:LANGuage
        //     Selects the graphic format for the hard copy. You can use both commands alternatively.
        //     language: BMP| JPG| XPM| PNG
        public HcopyImgFormatEnum Language
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:DEVice:LANGuage?").ToScpiEnum<HcopyImgFormatEnum>();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:DEVice:LANGuage " + value.ToScpiString());
            }
        }

        internal RsSmab_HardCopy_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }
    }
}
