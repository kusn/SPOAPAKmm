using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Step commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Frequency_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:STEP:MODE
        //     Defines the type of step size to vary the RF frequency at discrete steps with
        //     the commands FREQ UP or FREQ DOWN.
        //     mode: DECimal| USER DECimal Increases or decreases the level in steps of ten.
        //     USER Increases or decreases the level in increments, set with the command FREQ:STEP[:INCR].
        public FreqStepModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:FREQuency:STEP:MODE?").ToScpiEnum<FreqStepModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:STEP:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:STEP:[INCRement]
        //     Sets the step width. You can use this value to vary the RF frequency with command
        //     FREQ UP or FREQ DOWN, if you have activated FREQ:STEP:MODE USER. Note: This value
        //     also applies to the step width of the rotary knob on the instrument and, in user-defined
        //     step mode, increases or decreases the frequency.
        //     increment: float Range: 0 Hz to RFmax - 100 kHz
        public double Increment
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:FREQuency:STEP:INCRement?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:STEP:INCRement " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Frequency_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
