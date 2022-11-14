using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor_Var commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Vor_Var
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:VAR:FREQuency
        //     Sets the frequency of the variable and the reference signal. As the two signals
        //     must have the same frequency, the setting is valid for both signals.
        //     frequency: float Range: 10 to 60
        public double Frequency
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:VAR:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:VAR:FREQuency " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:VAR:[DEPTh]
        //     Sets the AM modulation depth of the 30Hz variable signal.
        //     depth: float Range: 0 to 100
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:VAR:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:VAR:DEPTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Vor_Var(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Var", core, parent);
        }
    }
}
