using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate_Power_Continuous
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Initiate_Power_Continuous(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Continuous", core, parent);
        }

        //
        // Сводка:
        //     INITiate<HW>:[POWer]:CONTinuous
        //     Switches the local state of the continuous power measurement by R&S NRP power
        //     sensors on and off. Switching off local state enhances the measurement performance
        //     during remote control. The remote measurement is triggered with :​READ<ch>[:​POWer]?)
        //     . This command also returns the measurement results. The local state is not affected,
        //     measurement results can be retrieved with local state on or off.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Initiate")
        //
        // Параметры:
        //   continuous:
        //     0| 1| OFF| ON
        public void Set(bool continuous)
        {
            Set(continuous, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     INITiate<HW>:[POWer]:CONTinuous
        //     Switches the local state of the continuous power measurement by R&S NRP power
        //     sensors on and off. Switching off local state enhances the measurement performance
        //     during remote control. The remote measurement is triggered with :​READ<ch>[:​POWer]?)
        //     . This command also returns the measurement results. The local state is not affected,
        //     measurement results can be retrieved with local state on or off.
        //
        // Параметры:
        //   continuous:
        //     0| 1| OFF| ON
        //
        //   channel:
        //     Repeated capability selector
        public void Set(bool continuous, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("INITiate" + repCapCmdValue + ":POWer:CONTinuous " + continuous.ToBooleanString());
        }

        //
        // Сводка:
        //     INITiate<HW>:[POWer]:CONTinuous
        //     Switches the local state of the continuous power measurement by R&S NRP power
        //     sensors on and off. Switching off local state enhances the measurement performance
        //     during remote control. The remote measurement is triggered with :​READ<ch>[:​POWer]?)
        //     . This command also returns the measurement results. The local state is not affected,
        //     measurement results can be retrieved with local state on or off.
        //     continuous: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Initiate")
        public bool Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     INITiate<HW>:[POWer]:CONTinuous
        //     Switches the local state of the continuous power measurement by R&S NRP power
        //     sensors on and off. Switching off local state enhances the measurement performance
        //     during remote control. The remote measurement is triggered with :​READ<ch>[:​POWer]?)
        //     . This command also returns the measurement results. The local state is not affected,
        //     measurement results can be retrieved with local state on or off.
        //     continuous: 0| 1| OFF| ON
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public bool Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryBoolean("INITiate" + repCapCmdValue + ":POWer:CONTinuous?");
        }
    }
}
