using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Questionable_Bit_Event commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Status_Questionable_Bit_Event
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Status_Questionable_Bit_Event(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Event", core, parent);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:[EVENt]
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public string Get()
        {
            return Get(BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:QUEStionable:BIT<BITNR>:[EVENt]
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public string Get(BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            return _grpBase.IO.QueryString("STATus:QUEStionable:BIT" + repCapCmdValue + ":EVENt?").TrimStringResponse();
        }
    }
}
