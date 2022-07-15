using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Limit commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Power_Limit
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:LIMit:[AMPLitude]
        //     Limits the maximum RF output level in CW and sweep mode. It does not influence
        //     the "Level" display or the response to the query [:​SOURce<hw>]:​POWer[:​LEVel][:​IMMediate][:​AMPLitude].
        //     amplitude: float Range: depends on the installed options
        public double Amplitude
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:LIMit:AMPLitude?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LIMit:AMPLitude " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Power_Limit(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Limit", core, parent);
        }
    }
}
