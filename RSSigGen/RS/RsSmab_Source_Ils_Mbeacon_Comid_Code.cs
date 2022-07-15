using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Mbeacon_Comid_Code commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Ils_Mbeacon_Comid_Code
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:COMid:CODE:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:MBEacon:COMid:CODE:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:COMid:CODE:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:COMid:CODE
        //     Sets the coding of the COM/ID signal by the international short name of the airport
        //     (e.g. MUC for the Munich airport) . The COM/ID tone is sent according to the
        //     selected code, see "Morse Code Settings". If no coding is set, the COM/ID tone
        //     is sent uncoded (key down) .
        //     code: string
        public string Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:MBEacon:COMid:CODE?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:COMid:CODE " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_Source_Ils_Mbeacon_Comid_Code(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Code", core, parent);
        }
    }
}
