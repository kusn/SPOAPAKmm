using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Ils_Setting commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Bb_Ils_Setting
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:SETTing:STORe
        //     No additional help available
        public string Store
        {
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:BB:ILS:SETTing:STORe " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Bb_Ils_Setting(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Setting", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:SETTing:DELete
        //     No additional help available
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:ILS:SETTing:DELete " + filename.EncloseByQuotes());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:SETTing:LOAD
        //     No additional help available
        public void Load(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:ILS:SETTing:LOAD " + filename.EncloseByQuotes());
        }
    }
}
