using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Combined_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Combined_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:COMBined:POWer:STARt
        //     Sets the start level value of the combined RF frequency / level sweep. See "Correlating
        //     Parameters in Sweep Mode".
        //     combPowStart: float Range: -245 to 120
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:COMBined:POWer:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:COMBined:POWer:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:COMBined:POWer:STOP
        //     Sets the stop level value of the combined RF frequency / level sweep.
        //     combPowStop: float Range: -245 to 120
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:COMBined:POWer:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:COMBined:POWer:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Combined_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
