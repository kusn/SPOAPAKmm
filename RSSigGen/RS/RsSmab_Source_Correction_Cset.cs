using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset commands group definition
    //     Sub-classes count: 1
    //     Commands count: 3
    //     Total commands count: 8
    public class RsSmab_Source_Correction_Cset
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Correction_Cset_Data _data;

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_Source_Correction_Cset_Data Data => _data ?? (_data = new RsSmab_Source_Correction_Cset_Data(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce]:CORRection:CSET:CATalog
        //     Queries a list of available user correction tables.
        //     catalog: string List of list filenames, separated by commas
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce:CORRection:CSET:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:[SELect]
        //     Selects or creates a file for the user correction data. If the file with the
        //     selected name does not exist, a new file is created.
        //     filename: string Filename or complete file path; file extension can be omitted.
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:CORRection:CSET:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:CSET:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Correction_Cset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Cset", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Correction_Cset Clone()
        {
            RsSmab_Source_Correction_Cset rsSmab_Source_Correction_Cset = new RsSmab_Source_Correction_Cset(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Correction_Cset);
            return rsSmab_Source_Correction_Cset;
        }

        //
        // Сводка:
        //     [SOURce]:CORRection:CSET:DELete
        //     Deletes the specified user correction list file.
        //
        // Параметры:
        //   filename:
        //     string Filename or complete file path; file extension is optional.
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce:CORRection:CSET:DELete " + filename.EncloseByQuotes());
        }
    }
}
