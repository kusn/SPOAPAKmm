using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_Image
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:IMAGe:FORMat
        //     Selects the graphic format for the hard copy. You can use both commands alternatively.
        public HcopyImgFormatEnum Format
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:IMAGe:FORMat?").ToScpiEnum<HcopyImgFormatEnum>();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:IMAGe:FORMat " + value.ToScpiString());
            }
        }

        internal RsSmab_HardCopy_Image(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Image", core, parent);
        }
    }
}
