using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Mbeacon_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Ils_Mbeacon_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:FREQuency:MODE
        //     Sets the carrier frequency mode of the ILS marker beacon signal.
        //     mode: USER| PREDefined
        public AvionicCarrFreqModeMrkBcnEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:MBEacon:FREQuency:MODE?").ToScpiEnum<AvionicCarrFreqModeMrkBcnEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:FREQuency:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:FREQuency
        //     Sets the carrier frequency for the ILS marker beacon signal.
        //     carrierFreq: float Range: 100E3 to 6E9
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:MBEacon:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Ils_Mbeacon_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
