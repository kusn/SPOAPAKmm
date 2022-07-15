using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Display_Permanent_Priority commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Display_Permanent_Priority
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Display_Permanent_Priority(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Priority", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:PRIority
        //     Selects average or peak power for permanent display.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   priority:
        //     AVERage| PEAK
        public void Set(PowSensDisplayPriorityEnum priority)
        {
            Set(priority, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:PRIority
        //     Selects average or peak power for permanent display.
        //
        // Параметры:
        //   priority:
        //     AVERage| PEAK
        //
        //   channel:
        //     Repeated capability selector
        public void Set(PowSensDisplayPriorityEnum priority, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:DISPlay:PERManent:PRIority " + priority.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:PRIority
        //     Selects average or peak power for permanent display.
        //     priority: AVERage| PEAK
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public PowSensDisplayPriorityEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DISPlay:PERManent:PRIority
        //     Selects average or peak power for permanent display.
        //     priority: AVERage| PEAK
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public PowSensDisplayPriorityEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:DISPlay:PERManent:PRIority?").ToScpiEnum<PowSensDisplayPriorityEnum>();
        }
    }
}
