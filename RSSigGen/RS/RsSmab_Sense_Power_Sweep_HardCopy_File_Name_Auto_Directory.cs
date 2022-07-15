using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:DIRectory
        //     Defines the directory into which the hardcopy files are stored if auto naming
        //     is activated (SENS:SWE:HCOP:FILE:AUTO:STAT ON) .
        //     directory: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:DIRectory?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:DIRectory " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_Directory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Directory", core, parent);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Deletes all files with extensions bmp , img, png, xpm and csv in the directory
        //     set for automatic naming.
        public void Clear()
        {
            _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:DIRectory:CLEar");
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAndWait()
        {
            ClearAndWait(-1);
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:DIRectory:CLEar
        //     Same as Clear, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:DIRectory:CLEar", opcTimeoutMs);
        }
    }
}
