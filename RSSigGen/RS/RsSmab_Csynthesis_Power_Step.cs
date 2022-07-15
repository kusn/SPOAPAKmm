using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Power_Step
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CSYNthesis:POWer:STEP:MODE
        //     Defines the type of step size to vary the frequency and level at discrete steps.
        //     mode: DECimal| USER DECimal Increases or decreases the level in steps of 10.
        //     USER Increases or decreases the value in increments, set with the command: method
        //     RsSmab.Csynthesis.Frequency.Step.Value method RsSmab.Csynthesis.Power.Value
        public FreqStepModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("CSYNthesis:POWer:STEP:MODE?").ToScpiEnum<FreqStepModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:POWer:STEP:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CSYNthesis:POWer:STEP:[INCRement]
        //     Sets the step width of the rotary knob and, in user-defined step mode, increases
        //     or decreases the level.
        //     increment: float Range: 0 to 35
        public double Increment
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:POWer:STEP:INCRement?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:POWer:STEP:INCRement " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Power_Step(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Step", core, parent);
        }
    }
}
