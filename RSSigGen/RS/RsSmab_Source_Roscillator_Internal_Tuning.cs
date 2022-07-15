using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Internal_Tuning commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Roscillator_Internal_Tuning
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:INTernal:TUNing:SLOPe
        //     Sets the sensitivity of the external tuning volatge.
        //     state: LOW| HIGH
        public LowHighEnum Slope
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:INTernal:TUNing:SLOPe?").ToScpiEnum<LowHighEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:INTernal:TUNing:SLOPe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:INTernal:TUNing:[STATe]
        //     Activates the EFC (external frequency control) .
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce:ROSCillator:INTernal:TUNing:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:INTernal:TUNing:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Roscillator_Internal_Tuning(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Tuning", core, parent);
        }
    }
}
