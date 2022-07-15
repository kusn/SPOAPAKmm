using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display_Annotation commands group
    //     definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display_Annotation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TRACe:[POWer]:SWEep:MEASurement:PULSe:DISPlay:ANNotation:[STATe]
        //     Activates the indication of the pulse data below the measurement diagram and
        //     storing the data in the hardcopy file. The parameters to be indicated can be
        //     selected with the following TRAC:SWE:MEAS:…. commands. Only six parameters are
        //     indicated at one time. Note: This command is only avalaible in time measurement
        //     mode and with R&S NRPZ81 power sensors.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("TRACe:POWer:SWEep:MEASurement:PULSe:DISPlay:ANNotation:STATe?");
            }
            set
            {
                _grpBase.IO.Write("TRACe:POWer:SWEep:MEASurement:PULSe:DISPlay:ANNotation:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Trace_Power_Sweep_Measurement_Pulse_Display_Annotation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Annotation", core, parent);
        }
    }
}
