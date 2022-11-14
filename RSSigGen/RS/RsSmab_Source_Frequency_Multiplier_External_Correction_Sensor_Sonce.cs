using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor_Sonce commands
    //     group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor_Sonce
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Frequency_Multiplier_External_Correction_Sensor_Sonce(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sonce", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:SENSor<CH>:SONCe
        //     No additional help available
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:SENSor" + repCapCmdValue + ":SONCe");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:SENSor<CH>:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(ChannelRepCap channel)
        {
            SetAndWait(channel, -1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:SENSor<CH>:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(ChannelRepCap channel, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:SENSor" + repCapCmdValue + ":SONCe", opcTimeoutMs);
        }
    }
}
