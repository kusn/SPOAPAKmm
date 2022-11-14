using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_HardCopy_File_Name_Auto_File_Prefix
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:[FILE]:PREFix:STATe
        //     Uses the prefix for the automatic generation of the file name, provided PREF:STAT
        //     is activated.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("HCOPy:FILE:NAME:AUTO:FILE:PREFix:STATe?");
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:FILE:PREFix:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     HCOPy:FILE:[NAME]:AUTO:[FILE]:PREFix
        //     Uses the prefix for the automatic generation of the file name, provided PREF:STAT
        //     is activated.
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("HCOPy:FILE:NAME:AUTO:FILE:PREFix?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("HCOPy:FILE:NAME:AUTO:FILE:PREFix " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_HardCopy_File_Name_Auto_File_Prefix(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Prefix", core, parent);
        }
    }
}
