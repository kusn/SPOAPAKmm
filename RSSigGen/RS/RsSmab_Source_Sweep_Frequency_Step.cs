using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency_Step commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Sweep_Frequency_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:STEP:LOGarithmic
        //     Sets a logarithmically determined step width for the RF frequency sweep. The
        //     value is added at each sweep step to the current frequency. See "Correlating
        //     Parameters in Sweep Mode".
        //     logarithmic: float The unit is mandatory. Range: 0.01 to 100, Unit: PCT
        public double Logarithmic
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:FREQuency:STEP:LOGarithmic?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:STEP:LOGarithmic " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:STEP:[LINear]
        //     Sets the step width for linear sweeps. See "Correlating Parameters in Sweep Mode".
        //     Omit the optional keywords so that the command is SCPI-compliant.
        //     linear: float Range: 0.001 Hz to (STOP - STARt)
        public double Linear
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:FREQuency:STEP:LINear?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:STEP:LINear " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Sweep_Frequency_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
