using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Double commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Pulm_Double
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:DOUBle:DELay
        //     Sets the delay from the start of the first pulse to the start of the second pulse.
        //     delay: float
        public double Delay
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:DOUBle:DELay?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:DOUBle:DELay " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:DOUBle:STATe
        //     Provided for backward compatibility with former Rohde & Schwarz signal generators.
        //     Works like the command PULM:MODEDOUBle.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:PULM:DOUBle:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:DOUBle:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:DOUBle:WIDTh
        //     Sets the width of the second pulse.
        //     width: float
        public double Width
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PULM:DOUBle:WIDTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:DOUBle:WIDTh " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Pulm_Double(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Double", core, parent);
        }
    }
}
