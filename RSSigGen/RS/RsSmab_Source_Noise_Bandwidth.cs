using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Noise_Bandwidth commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Noise_Bandwidth
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:NOISe:BWIDth:STATe
        //     Activates noise bandwidth limitation.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:NOISe:BWIDth:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:NOISe:BWIDth:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:NOISe:BANDwidth
        //     Sets the noise level in the system bandwidth when bandwidth limitation is enabled.
        //     bwidth: float Range: 100E3 to 10E6
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:NOISe:BANDwidth?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:NOISe:BANDwidth " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Noise_Bandwidth(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bandwidth", core, parent);
        }
    }
}
