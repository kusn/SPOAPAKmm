using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Sweep_Frequency_Step commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_LfOutput_Sweep_Frequency_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:STEP:LOGarithmic
        //     Sets the step width factor for logarithmic sweeps to calculate the frequencies
        //     of the steps. For information on how the value is calculated and the interdependency
        //     with other parameters, see "Correlating Parameters in Sweep Mode"
        //     logarithmic: float The unit is mandatory Range: 0.01 to 100, Unit: PCT
        public double Logarithmic
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:STEP:LOGarithmic?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:STEP:LOGarithmic " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput:SWEep:[FREQuency]:STEP:[LINear]
        //     Sets the step width for the linear sweep. For information on how the value is
        //     calculated and the interdependency with other parameters, see "Correlating Parameters
        //     in Sweep Mode"
        //     linear: float Range: 0.1 to STOP-STARt
        public double Linear
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:STEP:LINear?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LFOutput:SWEep:FREQuency:STEP:LINear " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_LfOutput_Sweep_Frequency_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
