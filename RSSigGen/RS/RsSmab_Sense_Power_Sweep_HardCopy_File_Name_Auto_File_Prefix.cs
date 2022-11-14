using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:PREFix:STATe
        //     Activates the usage of the prefix in the automatic file name.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:PREFix:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:PREFix:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:HCOPy:FILE:[NAME]:AUTO:[FILE]:PREFix
        //     Sets the prefix part in the automatic file name.
        //     prefix: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:PREFix?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:HCOPy:FILE:NAME:AUTO:FILE:PREFix " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Sense_Power_Sweep_HardCopy_File_Name_Auto_File_Prefix(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Prefix", core, parent);
        }
    }
}
