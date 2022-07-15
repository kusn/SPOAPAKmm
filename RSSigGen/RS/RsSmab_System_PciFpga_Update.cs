using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_PciFpga_Update commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 5
    public class RsSmab_System_PciFpga_Update
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_PciFpga_Update_Check _check;

        private RsSmab_System_PciFpga_Update_Needed _needed;

        private RsSmab_System_PciFpga_Update_Tselected _tselected;

        //
        // Сводка:
        //     Check commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_PciFpga_Update_Check Check => _check ?? (_check = new RsSmab_System_PciFpga_Update_Check(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Needed commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_PciFpga_Update_Needed Needed => _needed ?? (_needed = new RsSmab_System_PciFpga_Update_Needed(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Tselected commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_System_PciFpga_Update_Tselected Tselected => _tselected ?? (_tselected = new RsSmab_System_PciFpga_Update_Tselected(_grpBase.Core, _grpBase));

        internal RsSmab_System_PciFpga_Update(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Update", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_PciFpga_Update Clone()
        {
            RsSmab_System_PciFpga_Update rsSmab_System_PciFpga_Update = new RsSmab_System_PciFpga_Update(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_PciFpga_Update);
            return rsSmab_System_PciFpga_Update;
        }

        //
        // Сводка:
        //     SYSTem:PCIFpga:UPDate
        //     No additional help available
        public void Set()
        {
            _grpBase.IO.Write("SYSTem:PCIFpga:UPDate");
        }

        //
        // Сводка:
        //     SYSTem:PCIFpga:UPDate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait()
        {
            SetAndWait(-1);
        }

        //
        // Сводка:
        //     SYSTem:PCIFpga:UPDate
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SYSTem:PCIFpga:UPDate", opcTimeoutMs);
        }
    }
}
