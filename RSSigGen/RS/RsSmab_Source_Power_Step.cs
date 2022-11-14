using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Step commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Power_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:STEP:MODE
        //     Defines the type of step width to vary the RF output power step-by-step with
        //     the commands POW UP or POW DOWN.
        //     mode: DECimal| USER DECimal Increases or decreases the level in steps of ten.
        //     USER Increases or decreases the level in increments, determined with the command
        //     POWer.
        public FreqStepModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:STEP:MODE?").ToScpiEnum<FreqStepModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:STEP:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:STEP:[INCRement]
        //     Specifies the step width in the appropriate path for POW:STEP:MODE USER. To adjust
        //     the level step-by-step with this increment value, use the command POW UP, or
        //     POW DOWN. Note: The command also sets "Variation Step" in the manual control,
        //     that means the user-defined step width for setting the level with the rotary
        //     knob or the [Up/Down] arrow keys.
        //     increment: float Range: 0 to 200, Unit: dB
        public double Increment
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:STEP:INCRement?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:STEP:INCRement " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Power_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
