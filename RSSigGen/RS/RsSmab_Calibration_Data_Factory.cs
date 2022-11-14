using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Data_Factory commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Data_Factory
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:DATA:FACTory:DATE
        //     Queries the date of the last factory calibration.
        //     date: string
        public string Date => _grpBase.IO.QueryString("CALibration:DATA:FACTory:DATE?").TrimStringResponse();

        internal RsSmab_Calibration_Data_Factory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Factory", core, parent);
        }
    }
}
