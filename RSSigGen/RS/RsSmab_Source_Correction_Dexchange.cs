using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Dexchange commands group definition
    //     Sub-classes count: 2
    //     Commands count: 2
    //     Total commands count: 8
    public class RsSmab_Source_Correction_Dexchange
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Correction_Dexchange_Afile _afile;

        private RsSmab_Source_Correction_Dexchange_Execute _execute;

        //
        // Сводка:
        //     Afile commands group
        //     Sub-classes count: 1
        //     Commands count: 3
        //     Total commands count: 5
        public RsSmab_Source_Correction_Dexchange_Afile Afile => _afile ?? (_afile = new RsSmab_Source_Correction_Dexchange_Afile(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Correction_Dexchange_Execute Execute => _execute ?? (_execute = new RsSmab_Source_Correction_Dexchange_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:DEXChange:MODE
        //     Determines import or export of a user correction list. Specify the source or
        //     destination file with the command CORRection:DEXChange:SELect.
        //     mode: IMPort| EXPort
        public DexchModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:CORRection:DEXChange:MODE?").ToScpiEnum<DexchModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:DEXChange:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:DEXChange:SELect
        //     Selects the ASCII file for import or export, containing a user correction list.
        //     filename: string Filename or complete file path; file extension can be omitted.
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:CORRection:DEXChange:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:DEXChange:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Correction_Dexchange(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dexchange", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Correction_Dexchange Clone()
        {
            RsSmab_Source_Correction_Dexchange rsSmab_Source_Correction_Dexchange = new RsSmab_Source_Correction_Dexchange(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Correction_Dexchange);
            return rsSmab_Source_Correction_Dexchange;
        }
    }
}
