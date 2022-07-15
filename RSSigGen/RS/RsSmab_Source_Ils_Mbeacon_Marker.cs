using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Mbeacon_Marker commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Ils_Mbeacon_Marker
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:MARKer:FREQuency
        //     Sets the modulation frequency of the marker signal for the ILS marker beacon
        //     modulation signal.
        //     frequency: 400| 1300| 3000 Unit: Hz
        public int Frequency
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:ILS:MBEacon:MARKer:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:ILS:MBEacon:MARKer:FREQuency {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:[MARKer]:DEPTh
        //     Sets the modulation depth of the marker signal for the ILS marker beacon signal.
        //     depth: float Range: 0 to 100
        public double Depth
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:ILS:MBEacon:MARKer:DEPTh?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:MARKer:DEPTh " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:[MARKer]:PULSed
        //     Activates the modulation of a pulsed marker signal (morse coding) .
        //     pulsed: 0| 1| OFF| ON
        public bool Pulsed
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:MBEacon:MARKer:PULSed?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:MARKer:PULSed " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Ils_Mbeacon_Marker(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Marker", core, parent);
        }
    }
}
