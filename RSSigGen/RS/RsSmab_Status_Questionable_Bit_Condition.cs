using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Questionable_Bit_Condition commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Status_Questionable_Bit_Condition
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Status_Questionable_Bit_Condition(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Condition", core, parent);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:CONDition
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public string Get()
        {
            return Get(BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:CONDition
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public string Get(BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            return _grpBase.IO.QueryString("STATus:QUEStionable:BIT" + repCapCmdValue + ":CONDition?").TrimStringResponse();
        }
    }
}
