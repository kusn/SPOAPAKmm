using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Power_Step commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Power_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:STEP:[LOGarithmic]
        //     Sets a logarithmically determined step size for the RF level sweep. The level
        //     is increased by a logarithmically calculated fraction of the current level. See
        //     "Correlating Parameters in Sweep Mode".
        //     logarithmic: float The unit dB is mandatory. Range: 0.01 to 139 dB, Unit: dB
        public double Logarithmic
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:POWer:STEP:LOGarithmic?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:STEP:LOGarithmic " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Sweep_Power_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
