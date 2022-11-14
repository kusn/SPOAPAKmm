﻿using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Dexchange_Afile commands group definition
    //     Sub-classes count: 1
    //     Commands count: 3
    //     Total commands count: 5
    public class RsSmab_Source_Pulm_Train_Dexchange_Afile
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator _separator;

        //
        // Сводка:
        //     Separator commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator Separator => _separator ?? (_separator = new RsSmab_Source_Pulm_Train_Dexchange_Afile_Separator(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:AFILe:CATalog
        //     Queries the available ASCII files in the current or specified directory.
        //     catalog: string List of ASCII files *.txt or *.csv, separated by commas.
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:AFILe:EXTension
        //     Determines the extension of the ASCII file for import or export, or to query
        //     existing files.
        //     extension: TXT| CSV
        public DexchExtensionEnum Extension
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:EXTension?").ToScpiEnum<DexchExtensionEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:EXTension " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DEXChange:AFILe:SELect
        //     Selects the ASCII file to be imported or exported.
        //     filename: string Filename or complete file path; file extension can be omitted.
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DEXChange:AFILe:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Pulm_Train_Dexchange_Afile(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Afile", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Train_Dexchange_Afile Clone()
        {
            RsSmab_Source_Pulm_Train_Dexchange_Afile rsSmab_Source_Pulm_Train_Dexchange_Afile = new RsSmab_Source_Pulm_Train_Dexchange_Afile(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Train_Dexchange_Afile);
            return rsSmab_Source_Pulm_Train_Dexchange_Afile;
        }
    }
}
