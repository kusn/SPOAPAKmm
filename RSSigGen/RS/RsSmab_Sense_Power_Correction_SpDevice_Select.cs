using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Correction_SpDevice_Select commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Correction_SpDevice_Select
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Correction_SpDevice_Select(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Select", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:SELect
        //     Several S-parameter tables can be stored in a sensor. The command selects a loaded
        //     data set for S-parameter correction for the corresponding sensor.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   select:
        //     float
        public void Set(double select)
        {
            Set(select, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:SELect
        //     Several S-parameter tables can be stored in a sensor. The command selects a loaded
        //     data set for S-parameter correction for the corresponding sensor.
        //
        // Параметры:
        //   select:
        //     float
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double select, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:CORRection:SPDevice:SELect " + select.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:SELect
        //     Several S-parameter tables can be stored in a sensor. The command selects a loaded
        //     data set for S-parameter correction for the corresponding sensor.
        //     select: float
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:CORRection:SPDevice:SELect
        //     Several S-parameter tables can be stored in a sensor. The command selects a loaded
        //     data set for S-parameter correction for the corresponding sensor.
        //     select: float
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:CORRection:SPDevice:SELect?");
        }
    }
}
