using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_External_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Roscillator_External_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:FREQuency:VARiable
        //     Specifies the user-defined external reference frequency.
        //     frequency: float Range: 1E6 to 100E6, Unit: Hz
        public double Variable
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce:ROSCillator:EXTernal:FREQuency:VARiable?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:EXTernal:FREQuency:VARiable " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:FREQuency
        //     Sets the frequency of the external reference.
        //     frequency: 100MHZ| 1GHZ| VARiable| 10MHZ
        public RoscFreqExtEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:EXTernal:FREQuency?").ToScpiEnum<RoscFreqExtEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:EXTernal:FREQuency " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Roscillator_External_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
