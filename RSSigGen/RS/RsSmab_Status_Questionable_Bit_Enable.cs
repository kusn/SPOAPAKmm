using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Questionable_Bit_Enable commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Status_Questionable_Bit_Enable
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Status_Questionable_Bit_Enable(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Enable", core, parent);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:ENABle
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public void Set(string enable)
        {
            Set(enable, BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:ENABle
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public void Set(string enable, BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            _grpBase.IO.Write("STATus:QUEStionable:BIT" + repCapCmdValue + ":ENABle " + enable.EncloseByQuotes());
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:ENABle
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public string Get()
        {
            return Get(BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:ENABle
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public string Get(BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            return _grpBase.IO.QueryString("STATus:QUEStionable:BIT" + repCapCmdValue + ":ENABle?").TrimStringResponse();
        }
    }
}
