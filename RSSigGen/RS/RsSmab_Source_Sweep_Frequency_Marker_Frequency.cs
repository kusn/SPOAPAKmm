using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency_Marker_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Frequency_Marker_Frequency
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Sweep_Frequency_Marker_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FREQuency
        //     Sets the frequency of the selected marker.
        //     Used Repeated Capabilities default values:
        //     MarkerRepCap.Nr0 (settable in the interface "Marker")
        //
        // Параметры:
        //   frequency:
        //     float
        public void Set(double frequency)
        {
            Set(frequency, MarkerRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FREQuency
        //     Sets the frequency of the selected marker.
        //
        // Параметры:
        //   frequency:
        //     float
        //
        //   marker:
        //     Repeated capability selector
        public void Set(double frequency, MarkerRepCap marker)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(marker);
            _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:MARKer" + repCapCmdValue + ":FREQuency " + frequency.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FREQuency
        //     Sets the frequency of the selected marker.
        //     frequency: float
        //     Used Repeated Capabilities default values:
        //     MarkerRepCap.Nr0 (settable in the interface "Marker")
        public double Get()
        {
            return Get(MarkerRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FREQuency
        //     Sets the frequency of the selected marker.
        //     frequency: float
        //
        // Параметры:
        //   marker:
        //     Repeated capability selector
        public double Get(MarkerRepCap marker)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(marker);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:SWEep:FREQuency:MARKer" + repCapCmdValue + ":FREQuency?");
        }
    }
}
