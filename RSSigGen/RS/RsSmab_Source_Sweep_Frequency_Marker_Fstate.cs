using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Frequency_Marker_Fstate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Frequency_Marker_Fstate
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Sweep_Frequency_Marker_Fstate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Fstate", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FSTate
        //     Activates the selected marker.
        //     Used Repeated Capabilities default values:
        //     MarkerRepCap.Nr0 (settable in the interface "Marker")
        //
        // Параметры:
        //   fstate:
        //     0| 1| OFF| ON
        public void Set(bool fstate)
        {
            Set(fstate, MarkerRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FSTate
        //     Activates the selected marker.
        //
        // Параметры:
        //   fstate:
        //     0| 1| OFF| ON
        //
        //   marker:
        //     Repeated capability selector
        public void Set(bool fstate, MarkerRepCap marker)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(marker);
            _grpBase.IO.Write("SOURce<HwInstance>:SWEep:FREQuency:MARKer" + repCapCmdValue + ":FSTate " + fstate.ToBooleanString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FSTate
        //     Activates the selected marker.
        //     fstate: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     MarkerRepCap.Nr0 (settable in the interface "Marker")
        public bool Get()
        {
            return Get(MarkerRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:[FREQuency]:MARKer<CH>:FSTate
        //     Activates the selected marker.
        //     fstate: 0| 1| OFF| ON
        //
        // Параметры:
        //   marker:
        //     Repeated capability selector
        public bool Get(MarkerRepCap marker)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(marker);
            return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:SWEep:FREQuency:MARKer" + repCapCmdValue + ":FSTate?");
        }
    }
}
