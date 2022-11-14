using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Identification commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Identification
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:IDENtification
        //     Selects the mode to determine the "IDN String" and the "OPT String" for the instrument,
        //     selected with command method RsSmab.System.Language. Note: While working in an
        //     emulation mode, the R&S SMA100B specific command set is disabled, that is, the
        //     SCPI command method RsSmab.System.Identification.Value is discarded.
        //     identification: AUTO| USER AUTO Automatically determines the strings. USER User-defined
        //     strings can be selected.
        public IecDevIdEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:IDENtification?").ToScpiEnum<IecDevIdEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:IDENtification " + value.ToScpiString());
            }
        }

        internal RsSmab_System_Identification(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Identification", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:IDENtification:PRESet
        //     Sets the *IDN and *OPT strings in user defined mode to default values.
        public void Preset()
        {
            _grpBase.IO.Write("SYSTem:IDENtification:PRESet");
        }

        //
        // Сводка:
        //     SYSTem:IDENtification:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:IDENtification:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:IDENtification:PRESet", opcTimeoutMs);
        }
    }
}
