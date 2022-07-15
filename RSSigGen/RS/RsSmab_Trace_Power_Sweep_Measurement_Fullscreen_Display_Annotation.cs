using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Fullscreen_Display_Annotation commands group
    //     definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Fullscreen_Display_Annotation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TRACe:[POWer]:SWEep:MEASurement:FULLscreen:DISPlay:ANNotation:[STATe]
        //     Selects fullscreen display of the measurement diagram on the display and in the
        //     hardcopy file.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("TRACe:POWer:SWEep:MEASurement:FULLscreen:DISPlay:ANNotation:STATe?");
            }
            set
            {
                _grpBase.IO.Write("TRACe:POWer:SWEep:MEASurement:FULLscreen:DISPlay:ANNotation:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Trace_Power_Sweep_Measurement_Fullscreen_Display_Annotation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Annotation", core, parent);
        }
    }
}
