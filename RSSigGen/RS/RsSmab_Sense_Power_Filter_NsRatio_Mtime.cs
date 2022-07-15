using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_NsRatio_Mtime commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Filter_NsRatio_Mtime
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Filter_NsRatio_Mtime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mtime", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio:MTIMe
        //     Sets an upper limit for the settling time of the auto-averaging filter in the
        //     NSRatio mode and thus limits the length of the filter. The filter type is set
        //     with command FILTer:TYPE.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   mtime:
        //     float Range: 1 to 999.99
        public void Set(double mtime)
        {
            Set(mtime, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio:MTIMe
        //     Sets an upper limit for the settling time of the auto-averaging filter in the
        //     NSRatio mode and thus limits the length of the filter. The filter type is set
        //     with command FILTer:TYPE.
        //
        // Параметры:
        //   mtime:
        //     float Range: 1 to 999.99
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double mtime, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FILTer:NSRatio:MTIMe " + mtime.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio:MTIMe
        //     Sets an upper limit for the settling time of the auto-averaging filter in the
        //     NSRatio mode and thus limits the length of the filter. The filter type is set
        //     with command FILTer:TYPE.
        //     mtime: float Range: 1 to 999.99
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:NSRatio:MTIMe
        //     Sets an upper limit for the settling time of the auto-averaging filter in the
        //     NSRatio mode and thus limits the length of the filter. The filter type is set
        //     with command FILTer:TYPE.
        //     mtime: float Range: 1 to 999.99
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:FILTer:NSRatio:MTIMe?");
        }
    }
}
