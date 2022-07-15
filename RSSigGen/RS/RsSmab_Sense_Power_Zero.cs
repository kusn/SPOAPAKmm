using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Zero commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Zero
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Zero(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Zero", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:ZERO
        //     Performs zeroing of the sensor. Zeroing is required after warm-up, i.e. after
        //     connecting the sensor. Note: Switch off or disconnect the RF power source from
        //     the sensor before zeroing. Table Header: We recommend that you zero in regular
        //     intervals (at least once a day) , if: - The temperature has varied more than
        //     about 5 °C., - The sensor has been replaced., - You want to measure very low
        //     power.
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:ZERO");
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:ZERO
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(ChannelRepCap channel)
        {
            SetAndWait(channel, -1);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:ZERO
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(ChannelRepCap channel, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.WriteWithOpc("SENSe" + repCapCmdValue + ":POWer:ZERO", opcTimeoutMs);
        }
    }
}
