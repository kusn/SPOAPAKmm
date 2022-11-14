using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List commands group definition
    //     Sub-classes count: 8
    //     Commands count: 8
    //     Total commands count: 34
    public class RsSmab_Source_List
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_List_Dexchange _dexchange;

        private RsSmab_Source_List_Dwell _dwell;

        private RsSmab_Source_List_Frequency _frequency;

        private RsSmab_Source_List_Index _index;

        private RsSmab_Source_List_Learn _learn;

        private RsSmab_Source_List_Mode _mode;

        private RsSmab_Source_List_Power _power;

        private RsSmab_Source_List_Trigger _trigger;

        //
        // Сводка:
        //     Dexchange commands group
        //     Sub-classes count: 2
        //     Commands count: 2
        //     Total commands count: 8
        public RsSmab_Source_List_Dexchange Dexchange => _dexchange ?? (_dexchange = new RsSmab_Source_List_Dexchange(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dwell commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_Source_List_Dwell Dwell => _dwell ?? (_dwell = new RsSmab_Source_List_Dwell(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_List_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_List_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Index commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_List_Index Index => _index ?? (_index = new RsSmab_Source_List_Index(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Learn commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_List_Learn Learn => _learn ?? (_learn = new RsSmab_Source_List_Learn(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_List_Mode Mode => _mode ?? (_mode = new RsSmab_Source_List_Mode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_List_Power Power => _power ?? (_power = new RsSmab_Source_List_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trigger commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Source_List_Trigger Trigger => _trigger ?? (_trigger = new RsSmab_Source_List_Trigger(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:CATalog
        //     Queries the available list files in the specified directory.
        //     catalog: string List of list filenames, separated by commas
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SOURce<HwInstance>:LIST:CATalog?").ToStringList();

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:FREE
        //     Queries the amount of free memory (in bytes) for list mode lists.
        //     free: integer Range: 0 to INT_MAX
        public int Free => _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:FREE?");

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:RMODe
        //     No additional help available
        public LmodRunModeEnum Rmode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:RMODe?").ToScpiEnum<LmodRunModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:RMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:RUNNing
        //     Queries the current state of the list mode.
        //     state: 0| 1| OFF| ON 1 Signal generation based on the list mode is active.
        public bool Running => _grpBase.IO.QueryBoolean("SOURce<HwInstance>:LIST:RUNNing?");

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:SELect
        //     Selects or creates a data list in list mode. If the list with the selected name
        //     does not exist, a new list is created.
        //     filename: string Filename or complete file path; file extension can be omitted.
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_List(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("List", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_List Clone()
        {
            RsSmab_Source_List rsSmab_Source_List = new RsSmab_Source_List(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_List);
            return rsSmab_Source_List;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DELete
        //     Deletes the specified list. Refer to "Accessing Files in the Default or in a
        //     Specified Directory" for general information on file handling in the default
        //     and in a specific directory.
        //
        // Параметры:
        //   filename:
        //     string Filename or complete file path; file extension is optional.
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SOURce<HwInstance>:LIST:DELete " + filename.EncloseByQuotes());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DELete:ALL
        //     Deletes all lists in the set directory. Table Header: This command can only be
        //     executed, if: - No list file is selected., - List mode is disabled.
        public void DeleteAll()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:LIST:DELete:ALL");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DELete:ALL
        //     Same as DeleteAll, but waits for the operation to complete before continuing
        //     further. Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void DeleteAllAndWait()
        {
            DeleteAllAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DELete:ALL
        //     Same as DeleteAll, but waits for the operation to complete before continuing
        //     further. The entered opcTimeoutMs is only valid for this call.
        public void DeleteAllAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:LIST:DELete:ALL", opcTimeoutMs);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:RESet
        //     Jumps to the beginning of the list.
        public void Reset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:LIST:RESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:RESet
        //     Same as Reset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ResetAndWait()
        {
            ResetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:RESet
        //     Same as Reset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ResetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:LIST:RESet", opcTimeoutMs);
        }
    }
}
