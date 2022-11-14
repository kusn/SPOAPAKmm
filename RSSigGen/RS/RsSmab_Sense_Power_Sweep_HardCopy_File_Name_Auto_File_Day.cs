using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:DAY:STATe
        //     Activates the usage of the day in the automatic file name.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:DAY:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:DAY:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:DAY
        //     Queries the day of the date part in the automatic file name.
        //     day: integer Range: 1 to 31
        public int Value => _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:DAY?");

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Day(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Day", core, parent);
        }
    }
}
