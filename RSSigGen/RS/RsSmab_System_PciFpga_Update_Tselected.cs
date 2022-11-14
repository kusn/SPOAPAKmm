using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_PciFpga_Update_Tselected commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_PciFpga_Update_Tselected
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:PCIFpga:UPDate:TSELected:CATalog
        //     No additional help available
        public string Catalog => _grpBase.IO.QueryString("SYSTem:PCIFpga:UPDate:TSELected:CATalog?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:PCIFpga:UPDate:TSELected:STEP
        //     No additional help available
        public string Step
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:PCIFpga:UPDate:TSELected:STEP?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:PCIFpga:UPDate:TSELected:STEP " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_PciFpga_Update_Tselected(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Tselected", core, parent);
        }
    }
}
