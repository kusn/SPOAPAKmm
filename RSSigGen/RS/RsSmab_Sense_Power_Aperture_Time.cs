using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Aperture_Time commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Aperture_Time
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Aperture_Time(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Time", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:TIMe
        //     Defines the aperture time (size of the acquisition interval) for the corresponding
        //     sensor.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   apTime:
        //     float Range: depends on connected power sensor
        public void Set(double apTime)
        {
            Set(apTime, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:TIMe
        //     Defines the aperture time (size of the acquisition interval) for the corresponding
        //     sensor.
        //
        // Параметры:
        //   apTime:
        //     float Range: depends on connected power sensor
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double apTime, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:APERture:TIMe " + apTime.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:TIMe
        //     Defines the aperture time (size of the acquisition interval) for the corresponding
        //     sensor.
        //     apTime: float Range: depends on connected power sensor
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:APERture:TIMe
        //     Defines the aperture time (size of the acquisition interval) for the corresponding
        //     sensor.
        //     apTime: float Range: depends on connected power sensor
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:APERture:TIMe?");
        }
    }
}
