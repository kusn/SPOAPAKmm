using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_DeviceFootprint_History commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_DeviceFootprint_History
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DFPRint:HISTory:COUNt
        //     No additional help available
        public string Count => _grpBase.IO.QueryString("SYSTem:DFPRint:HISTory:COUNt?").TrimStringResponse();

        //
        // Сводка:
        //     SYSTem:DFPRint:HISTory:ENTRy
        //     No additional help available
        public string Entry => _grpBase.IO.QueryString("SYSTem:DFPRint:HISTory:ENTRy?").TrimStringResponse();

        internal RsSmab_System_DeviceFootprint_History(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("History", core, parent);
        }
    }
}
