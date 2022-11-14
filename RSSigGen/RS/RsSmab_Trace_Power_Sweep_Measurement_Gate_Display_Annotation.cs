using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Gate_Display_Annotation commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Gate_Display_Annotation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TRACe:[POWer]:SWEep:MEASurement:GATE:DISPlay:ANNotation:[STATe]
        //     Activates th eindication of the time gate borders and values in the measurement
        //     diagram and in the hardcopy file. The gate settings are performed with the CALC:POW:SWE:TIME:GATE:…
        //     commands.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("TRACe:POWer:SWEep:MEASurement:GATE:DISPlay:ANNotation:STATe?");
            }
            set
            {
                _grpBase.IO.Write("TRACe:POWer:SWEep:MEASurement:GATE:DISPlay:ANNotation:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Trace_Power_Sweep_Measurement_Gate_Display_Annotation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Annotation", core, parent);
        }
    }
}
