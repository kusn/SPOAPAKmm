using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_Output_Alternate_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Roscillator_Output_Alternate_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:ROSCillator:OUTPut:ALTernate:FREQuency:MODE
        //     Sets the output reference frequency.
        //     outpFreqMode: LOOPthrough| DER1G| OFF OFF Disables the output. DER1G Sets the
        //     output reference frequency to 1 GHz. The reference frequency is derived from
        //     the internal reference frequency. LOOPthrough If ROSCillator:EXTernal:FREQuency1GHZ,
        //     forwards the input reference frequency to the reference frequency output.
        public Rosc1GoUtpFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:OUTPut:ALTernate:FREQuency:MODE?").ToScpiEnum<Rosc1GoUtpFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:OUTPut:ALTernate:FREQuency:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Roscillator_Output_Alternate_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
