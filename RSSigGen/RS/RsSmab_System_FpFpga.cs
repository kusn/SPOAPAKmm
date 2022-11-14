using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_FpFpga commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_FpFpga
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:FPFPga:UPDate
        //     No additional help available
        public string Update
        {
            set
            {
                _grpBase.IO.Write("SYSTem:FPFPga:UPDate " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_FpFpga(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("FpFpga", core, parent);
        }
    }
}
