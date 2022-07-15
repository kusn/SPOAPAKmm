using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Device commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Device
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DEVice:ID
        //     No additional help available
        public string Id => _grpBase.IO.QueryString("SYSTem:DEVice:ID?").TrimStringResponse();

        internal RsSmab_System_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }
    }
}
