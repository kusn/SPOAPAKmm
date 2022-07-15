using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Alc_Edetector commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Power_Alc_Edetector
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:EDETector:FACTor
        //     No additional help available
        public double Factor => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:ALC:EDETector:FACTor?");

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:EDETector:LEVel
        //     No additional help available
        public double Level => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:ALC:EDETector:LEVel?");

        internal RsSmab_Source_Power_Alc_Edetector(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Edetector", core, parent);
        }
    }
}
