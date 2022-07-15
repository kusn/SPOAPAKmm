using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate_FreqSweep_Continuous
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Initiate_FreqSweep_Continuous(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Continuous", core, parent);
        }

        //
        // Сводка:
        //     INITiate<HW>:FSWeep:CONTinuous
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Initiate")
        public void Set(bool freqSweepState)
        {
            Set(freqSweepState, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     INITiate<HW>:FSWeep:CONTinuous
        //     No additional help available
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(bool freqSweepState, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("INITiate" + repCapCmdValue + ":FSWeep:CONTinuous " + freqSweepState.ToBooleanString());
        }

        //
        // Сводка:
        //     INITiate<HW>:FSWeep:CONTinuous
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Initiate")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     INITiate<HW>:FSWeep:CONTinuous
        //     No additional help available
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("INITiate" + repCapCmdValue + ":FSWeep:CONTinuous?");
        }
    }
}
