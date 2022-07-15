using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Noise_Level commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Noise_Level
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:NOISe:LEVel:RELative
        //     Queries the level of the noise signal per Hz in the total bandwidth.
        //     relative: float Range: -149.18 to -52.67
        public double Relative => _grpBase.IO.QueryDouble("SOURce<HwInstance>:NOISe:LEVel:RELative?");

        //
        // Сводка:
        //     [SOURce<HW>]:NOISe:LEVel:[ABSolute]
        //     Queries the level of the noise signal in the system bandwidth within the enabled
        //     bandwidth limitation.
        //     absolute: float Noise level within the bandwidth limitation
        public double Absolute => _grpBase.IO.QueryDouble("SOURce<HwInstance>:NOISe:LEVel:ABSolute?");

        internal RsSmab_Source_Noise_Level(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Level", core, parent);
        }
    }
}
