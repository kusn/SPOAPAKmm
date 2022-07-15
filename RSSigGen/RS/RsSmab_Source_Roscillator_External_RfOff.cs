using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_External_RfOff commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Roscillator_External_RfOff
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:RFOFf:[STATe]
        //     Determines that the RF output is turned off when the external reference signal
        //     is selected, but missing.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce:ROSCillator:EXTernal:RFOFf:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:EXTernal:RFOFf:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Roscillator_External_RfOff(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("RfOff", core, parent);
        }
    }
}
