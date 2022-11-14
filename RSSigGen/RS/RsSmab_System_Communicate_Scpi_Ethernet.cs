using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Communicate_Scpi_Ethernet commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Communicate_Scpi_Ethernet
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:COMMunicate:SCPI:ETHernet:[ACTive]
        //     No additional help available
        public string Active => _grpBase.IO.QueryString("SYSTem:COMMunicate:SCPI:ETHernet:ACTive?").TrimStringResponse();

        internal RsSmab_System_Communicate_Scpi_Ethernet(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ethernet", core, parent);
        }
    }
}
