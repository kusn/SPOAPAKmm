using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Output_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Roscillator_Output_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:OUTPut:FREQuency:MODE
        //     Sets the output reference frequency.
        //     outpFreqMode: DER10M| DER100M| OFF| LOOPthrough OFF Disables the output. DER10M|DER100M
        //     Sets the output reference frequency to 10 MHz or 100 MHz. The reference frequency
        //     is derived from the internal reference frequency. LOOPthrough This option is
        //     unavailable for ROSCillator:EXTernal:FREQuency 1GHZ. Forwards the input reference
        //     frequency to the reference frequency output.
        public RoscOutpFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:OUTPut:FREQuency:MODE?").ToScpiEnum<RoscOutpFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:OUTPut:FREQuency:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Roscillator_Output_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
