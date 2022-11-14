using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train commands group definition
    //     Sub-classes count: 5
    //     Commands count: 3
    //     Total commands count: 30
    public class RsSmab_Source_Pulm_Train
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Pulm_Train_Dexchange _dexchange;

        private RsSmab_Source_Pulm_Train_Hopping _hopping;

        private RsSmab_Source_Pulm_Train_OffTime _offTime;

        private RsSmab_Source_Pulm_Train_Ontime _ontime;

        private RsSmab_Source_Pulm_Train_Repetition _repetition;

        //
        // Сводка:
        //     Dexchange commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 8
        public RsSmab_Source_Pulm_Train_Dexchange Dexchange => _dexchange ?? (_dexchange = new RsSmab_Source_Pulm_Train_Dexchange(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Hopping commands group
        //     Sub-classes count: 5
        //     Commands count: 3
        //     Total commands count: 13
        public RsSmab_Source_Pulm_Train_Hopping Hopping => _hopping ?? (_hopping = new RsSmab_Source_Pulm_Train_Hopping(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     OffTime commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_OffTime OffTime => _offTime ?? (_offTime = new RsSmab_Source_Pulm_Train_OffTime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ontime commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Ontime Ontime => _ontime ?? (_ontime = new RsSmab_Source_Pulm_Train_Ontime(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Repetition commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Pulm_Train_Repetition Repetition => _repetition ?? (_repetition = new RsSmab_Source_Pulm_Train_Repetition(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:CATalog
        //     Queries the available pulse train files in the specified directory.
        //     catalog: string List of list filenames, separated by commas
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:PULM:TRAin:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:SELect
        //     Selects or creates a data list in pulse train mode. If the list with the selected
        //     name does not exist, a new list is created.
        //     filename: string Filename or complete file path; file extension can be omitted.
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRAin:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Pulm_Train(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Train", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Pulm_Train Clone()
        {
            RsSmab_Source_Pulm_Train rsSmab_Source_Pulm_Train = new RsSmab_Source_Pulm_Train(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Pulm_Train);
            return rsSmab_Source_Pulm_Train;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:DELete
        //     Deletes the specified pulse train file. Refer to "Accessing Files in the Default
        //     or in a Specified Directory" for general information on file handling in the
        //     default and in a specific directory.
        //
        // Параметры:
        //   filename:
        //     string Filename or complete file path; file extension is optional.
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:DELete " + filename.EncloseByQuotes());
        }
    }
}
