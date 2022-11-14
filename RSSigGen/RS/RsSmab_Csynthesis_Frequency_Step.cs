using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Frequency_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CSYNthesis:FREQuency:STEP:MODE
        //     Defines the type of step size to vary the frequency and level at discrete steps.
        //     mode: DECimal| USER DECimal Increases or decreases the level in steps of 10.
        //     USER Increases or decreases the value in increments, set with the command: method
        //     RsSmab.Csynthesis.Frequency.Step.Value method RsSmab.Csynthesis.Power.Value
        public FreqStepModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CSYNthesis:FREQuency:STEP:MODE?").ToScpiEnum<FreqStepModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:FREQuency:STEP:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CSYNthesis:FREQuency:STEP
        //     Sets the step width of the rotary knob and, in user-defined step mode, increases
        //     or decreases the frequency.
        //     step: float Range: 0 to 14999E5
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:FREQuency:STEP?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:FREQuency:STEP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Frequency_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
