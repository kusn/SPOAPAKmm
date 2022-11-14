using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Status_Device commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Status_Device
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Status_Device(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Device", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:STATus:[DEVice]
        //     Queries if a sensor is connected to the instrument.
        //     status: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:STATus:[DEVice]
        //     Queries if a sensor is connected to the instrument.
        //     status: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("SENSe" + repCapCmdValue + ":POWer:STATus:DEVice?");
        }
    }
}
