using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Combined_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Combined_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:COMBined:FREQuency:STARt
        //     Sets the start frequency of the combined RF frequency / level sweep. See "Correlating
        //     Parameters in Sweep Mode".
        //     combFreqStart: float Range: -59999E5 to 12E9
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:COMBined:FREQuency:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:COMBined:FREQuency:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:COMBined:FREQuency:STOP
        //     Sets the end frequency of the combined RF frequency / level sweep.
        //     combFreqStop: float Range: -59999E5 to 12E9
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:COMBined:FREQuency:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:COMBined:FREQuency:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Combined_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
