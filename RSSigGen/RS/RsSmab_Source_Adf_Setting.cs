using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Adf_Setting commands group definition
    //     Sub-classes count: 0
    //     Commands count: 4
    //     Total commands count: 4
    public class RsSmab_Source_Adf_Setting
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:SETTing:CATalog
        //     Queries the files with settings in the default directory. Listed are files with
        //     the file extension *.adf/*.ils/*.vor. Refer to "Accessing Files in the Default
        //     or in a Specified Directory" for general information on file handling in the
        //     default and in a specific directory.
        //     avionicAdfCatNames: filename1,filename2,... Returns a string of filenames separated
        //     by commas.
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:ADF:SETTing:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:SETTing:STORe
        //     Saves the current settings into the selected file; the file extension (*.adf/*.ils/*.vor)
        //     is assigned automatically. Refer to "Accessing Files in the Default or in a Specified
        //     Directory" for general information on file handling in the default and in a specific
        //     directory.
        //     Filename: "filename" Filename or complete file path
        public string Store
        {
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:SETTing:STORe " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Adf_Setting(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Setting", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:SETTing:DELete
        //     Deletes the selected file from the default or the specified directory. Deleted
        //     are files with extension *.adf/*.ils/*.vor. Refer to "Accessing Files in the
        //     Default or in a Specified Directory" for general information on file handling
        //     in the default and in a specific directory.
        //
        // Параметры:
        //   filename:
        //     "filename" Filename or complete file path; file extension can be omitted
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ADF:SETTing:DELete " + filename.EncloseByQuotes());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:SETTing:LOAD
        //     Loads the selected file from the default or the specified directory. Loaded are
        //     files with extension *.adf/*.ils/*.vor. Refer to "Accessing Files in the Default
        //     or in a Specified Directory" for general information on file handling in the
        //     default and in a specific directory.
        //
        // Параметры:
        //   filename:
        //     "filename" Filename or complete file path; file extension can be omitted
        public void Load(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ADF:SETTing:LOAD " + filename.EncloseByQuotes());
        }
    }
}
