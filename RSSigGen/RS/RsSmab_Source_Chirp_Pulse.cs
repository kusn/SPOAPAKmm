using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp_Pulse commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Chirp_Pulse
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:PULSe:PERiod
        //     Sets the period of the generated modulation chirp. The period determines the
        //     repetition frequency of the internal signal.
        //     period: float Range: 5E-6 (2E-7 with K23) to 100
        public double Period
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:CHIRp:PULSe:PERiod?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:PULSe:PERiod " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:PULSe:WIDTh
        //     Sets the width of the generated pulse. The pulse width must be at least 1us less
        //     than the set pulse period.
        //     width: float Range: 2E-6 (1E-7 with K23) to 100
        public double Width
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:CHIRp:PULSe:WIDTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:PULSe:WIDTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Chirp_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }
    }
}
