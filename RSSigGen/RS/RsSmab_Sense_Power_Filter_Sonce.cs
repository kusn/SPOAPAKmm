using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_Sonce commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Filter_Sonce
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Filter_Sonce(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sonce", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:SONCe
        //     Starts searching the optimum filter length for the current measurement conditions.
        //     You can check the result with command SENS1:POW:FILT:LENG:USER? in filter mode
        //     USER (FILTer:TYPE) .
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FILTer:SONCe");
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void SetAndWait(ChannelRepCap channel)
        {
            SetAndWait(channel, -1);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:SONCe
        //     Same as Set, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void SetAndWait(ChannelRepCap channel, int opcTimeoutMs)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.WriteWithOpc("SENSe" + repCapCmdValue + ":POWer:FILTer:SONCe", opcTimeoutMs);
        }
    }
}
