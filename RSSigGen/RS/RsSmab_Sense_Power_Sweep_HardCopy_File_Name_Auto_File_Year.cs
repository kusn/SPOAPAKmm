using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:YEAR:STATe
        //     Activates the usage of the year in the automatic file name.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:YEAR:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:YEAR:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:YEAR
        //     Queries the year of the date part in the automatic file name.
        //     year: integer Range: 1784 to 8000
        public int Value => _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:YEAR?");

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Year(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Year", core, parent);
        }
    }
}
