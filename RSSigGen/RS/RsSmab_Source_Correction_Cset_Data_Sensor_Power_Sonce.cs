using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Correction_Cset_Data_Sensor_Power_Sonce(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sonce", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:[SENSor<CH>]:[POWer]:SONCe
        //     Fills the selected user correction table with the level values measured by the
        //     power sensor for the given frequencies. To select the used power sensor set the
        //     suffix in key word SENSe.
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SOURce<HwInstance>:CORRection:CSET:DATA:SENSor" + repCapCmdValue + ":POWer:SONCe");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:[SENSor<CH>]:[POWer]:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(ChannelRepCap channel)
        {
            SetAndWait(channel, -1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:[SENSor<CH>]:[POWer]:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(ChannelRepCap channel, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:CORRection:CSET:DATA:SENSor" + repCapCmdValue + ":POWer:SONCe", opcTimeoutMs);
        }
    }
}
