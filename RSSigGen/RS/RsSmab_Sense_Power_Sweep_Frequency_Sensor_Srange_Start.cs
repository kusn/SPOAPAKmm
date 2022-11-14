using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Sweep_Frequency_Sensor_Srange_Start(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Start", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:SRANge:STARt
        //     Sets the start frequency for the frequency power analysis with separate frequencies.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   start:
        //     integer Range: 0 to 1E12
        public void Set(int start)
        {
            Set(start, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:SRANge:STARt
        //     Sets the start frequency for the frequency power analysis with separate frequencies.
        //
        // Параметры:
        //   start:
        //     integer Range: 0 to 1E12
        //
        //   channel:
        //     Repeated capability selector
        public void Set(int start, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write($"SENSe{repCapCmdValue}:POWer:SWEep:FREQuency:SENSor:SRANge:STARt {start}");
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:SRANge:STARt
        //     Sets the start frequency for the frequency power analysis with separate frequencies.
        //     start: integer Range: 0 to 1E12
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public int Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SWEep:FREQuency:[SENSor]:SRANge:STARt
        //     Sets the start frequency for the frequency power analysis with separate frequencies.
        //     start: integer Range: 0 to 1E12
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public int Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryInt32("SENSe" + repCapCmdValue + ":POWer:SWEep:FREQuency:SENSor:SRANge:STARt?");
        }
    }
}
