using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto_File_Year
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:[FILE]:YEAR:STATe
        //     Uses the date parameters (year, month or day) for the automatic naming. You can
        //     activate each of the date parameters separately.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("HCOPy:FILE:NAME:AUTO:FILE:YEAR:STATe?");
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:FILE:YEAR:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_HardCopy_File_Name_Auto_File_Year(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Year", core, parent);
        }
    }
}
