using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto_File_Day
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:[FILE]:DAY:STATe
        //     Uses the date parameters (year, month or day) for the automatic naming. You can
        //     activate each of the date parameters separately.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("HCOPy:FILE:NAME:AUTO:FILE:DAY:STATe?");
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:FILE:DAY:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_HardCopy_File_Name_Auto_File_Day(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Day", core, parent);
        }
    }
}
