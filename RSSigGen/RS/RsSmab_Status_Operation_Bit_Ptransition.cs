using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Operation_Bit_Ptransition commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Status_Operation_Bit_Ptransition
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Status_Operation_Bit_Ptransition(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ptransition", core, parent);
        }

        //
        // Сводка:
        //     STATus:OPERation:BIT<BITNR>:PTRansition
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public void Set(string ptransition)
        {
            Set(ptransition, BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:OPERation:BIT<BITNR>:PTRansition
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public void Set(string ptransition, BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            _grpBase.IO.Write("STATus:OPERation:BIT" + repCapCmdValue + ":PTRansition " + ptransition.EncloseByQuotes());
        }

        //
        // Сводка:
        //     STATus:OPERation:BIT<BITNR>:PTRansition
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     BitNumberNullRepCap.Nr0 (settable in the interface "Bit")
        public string Get()
        {
            return Get(BitNumberNullRepCap.Default);
        }

        //
        // Сводка:
        //     STATus:OPERation:BIT<BITNR>:PTRansition
        //     No additional help available
        //
        // Параметры:
        //   bitNumberNull:
        //     Repeated capability selector
        public string Get(BitNumberNullRepCap bitNumberNull)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(bitNumberNull);
            return _grpBase.IO.QueryString("STATus:OPERation:BIT" + repCapCmdValue + ":PTRansition?").TrimStringResponse();
        }
    }
}
