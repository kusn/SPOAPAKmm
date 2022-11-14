using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Internal_Adjust commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Roscillator_Internal_Adjust
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:[INTernal]:ADJust:VALue
        //     Specifies the frequency correction value (adjustment value) .
        //     value: integer
        public int Value
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce:ROSCillator:INTernal:ADJust:VALue?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce:ROSCillator:INTernal:ADJust:VALue {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:[INTernal]:ADJust:[STATe]
        //     Determines whether the calibrated (off) or a user-defined (on) adjustment value
        //     is used for fine adjustment of the frequency.
        //     state: 0| 1| OFF| ON 0 Fine adjustment with the calibrated frequency value 1
        //     User-defined adjustment value. The instrument is no longer in the calibrated
        //     state. The calibration value is, however, not changed. The instrument resumes
        //     the calibrated state if you send SOURce:ROSCillator:INTernal:ADJust:STATe 0.
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce:ROSCillator:INTernal:ADJust:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:INTernal:ADJust:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Roscillator_Internal_Adjust(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Adjust", core, parent);
        }
    }
}
