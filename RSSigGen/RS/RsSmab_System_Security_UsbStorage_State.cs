using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Security_UsbStorage_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Security_UsbStorage_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Security_UsbStorage_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:USBStorage:[STATe]
        //     No additional help available
        public void Set(string secPassWord, bool usbStorState)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(secPassWord, 0, DataType.String), new ArgSingle(usbStorState, 1, DataType.Boolean));
            _grpBase.IO.Write("SYSTem:SECurity:USBStorage:STATe " + text);
        }

        //
        // Сводка:
        //     SYSTem:SECurity:USBStorage:[STATe]
        //     No additional help available
        public bool Get()
        {
            return _grpBase.IO.QueryBoolean("SYSTem:SECurity:USBStorage:STATe?");
        }
    }
}
