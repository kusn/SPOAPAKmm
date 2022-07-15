using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Frequency
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FREQuency
        //     Sets the RF frequency of the signal, if signal source "USER" is selected (SOURce)
        //     .
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   frequency:
        //     float
        public void Set(double frequency)
        {
            Set(frequency, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FREQuency
        //     Sets the RF frequency of the signal, if signal source "USER" is selected (SOURce)
        //     .
        //
        // Параметры:
        //   frequency:
        //     float
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double frequency, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FREQuency " + frequency.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FREQuency
        //     Sets the RF frequency of the signal, if signal source "USER" is selected (SOURce)
        //     .
        //     frequency: float
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FREQuency
        //     Sets the RF frequency of the signal, if signal source "USER" is selected (SOURce)
        //     .
        //     frequency: float
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:FREQuency?");
        }
    }
}
