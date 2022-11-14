using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto_Directory
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:DIRectory
        //     Determines the path to save the hard copy, if you have enabled Automatic Naming.
        //     If the directory does not yet exist, the instrument automatically creates a new
        //     directory, using the instrument name and /var/user/ by default.
        //     directory: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:FILE:NAME:AUTO:DIRectory?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:DIRectory " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_HardCopy_File_Name_Auto_Directory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Directory", core, parent);
        }

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Deletes all files with extensions *.bmp, *.jpg, *.png and *.xpm in the directory
        //     set for automatic naming.
        public void Clear()
        {
            _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:DIRectory:CLEar");
        }

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAndWait()
        {
            ClearAndWait(-1);
        }

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("HCOPy:FILE:NAME:AUTO:DIRectory:CLEar", opcTimeoutMs);
        }
    }
}
