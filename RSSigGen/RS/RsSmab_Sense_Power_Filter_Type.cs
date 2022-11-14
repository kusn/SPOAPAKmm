using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Filter_Type commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Filter_Type
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Filter_Type(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Type", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:TYPE
        //     Selects the filter mode. The filter length is the multiplier for the time window
        //     and thus directly affects the measurement time.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   type:
        //     AUTO| USER| NSRatio AUTO Automatically selects the filter length, depending on
        //     the measured value. The higher the power, the shorter the filter length, and
        //     vice versa. USER Allows you to set the filter length manually. As the filter-length
        //     takes effect as a multiplier of the measurement time, you can achieve constant
        //     measurement times. NSRatio Selects the filter length (averaging factor) according
        //     to the criterion that the intrinsic noise of the sensor (2 standard deviations)
        //     does not exceed the specified noise content. You can define the noise content
        //     with command FILTer:NSRatio. Note: To avoid long settling times when the power
        //     is low, you can limit the averaging factor limited with the "timeout" parameter
        //     (FILTer:NSRatio:MTIMe) .
        public void Set(PowSensFiltTypeEnum type)
        {
            Set(type, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:TYPE
        //     Selects the filter mode. The filter length is the multiplier for the time window
        //     and thus directly affects the measurement time.
        //
        // Параметры:
        //   type:
        //     AUTO| USER| NSRatio AUTO Automatically selects the filter length, depending on
        //     the measured value. The higher the power, the shorter the filter length, and
        //     vice versa. USER Allows you to set the filter length manually. As the filter-length
        //     takes effect as a multiplier of the measurement time, you can achieve constant
        //     measurement times. NSRatio Selects the filter length (averaging factor) according
        //     to the criterion that the intrinsic noise of the sensor (2 standard deviations)
        //     does not exceed the specified noise content. You can define the noise content
        //     with command FILTer:NSRatio. Note: To avoid long settling times when the power
        //     is low, you can limit the averaging factor limited with the "timeout" parameter
        //     (FILTer:NSRatio:MTIMe) .
        //
        //   channel:
        //     Repeated capability selector
        public void Set(PowSensFiltTypeEnum type, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:FILTer:TYPE " + type.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:TYPE
        //     Selects the filter mode. The filter length is the multiplier for the time window
        //     and thus directly affects the measurement time.
        //     type: AUTO| USER| NSRatio AUTO Automatically selects the filter length, depending
        //     on the measured value. The higher the power, the shorter the filter length, and
        //     vice versa. USER Allows you to set the filter length manually. As the filter-length
        //     takes effect as a multiplier of the measurement time, you can achieve constant
        //     measurement times. NSRatio Selects the filter length (averaging factor) according
        //     to the criterion that the intrinsic noise of the sensor (2 standard deviations)
        //     does not exceed the specified noise content. You can define the noise content
        //     with command FILTer:NSRatio. Note: To avoid long settling times when the power
        //     is low, you can limit the averaging factor limited with the "timeout" parameter
        //     (FILTer:NSRatio:MTIMe) .
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public PowSensFiltTypeEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:FILTer:TYPE
        //     Selects the filter mode. The filter length is the multiplier for the time window
        //     and thus directly affects the measurement time.
        //     type: AUTO| USER| NSRatio AUTO Automatically selects the filter length, depending
        //     on the measured value. The higher the power, the shorter the filter length, and
        //     vice versa. USER Allows you to set the filter length manually. As the filter-length
        //     takes effect as a multiplier of the measurement time, you can achieve constant
        //     measurement times. NSRatio Selects the filter length (averaging factor) according
        //     to the criterion that the intrinsic noise of the sensor (2 standard deviations)
        //     does not exceed the specified noise content. You can define the noise content
        //     with command FILTer:NSRatio. Note: To avoid long settling times when the power
        //     is low, you can limit the averaging factor limited with the "timeout" parameter
        //     (FILTer:NSRatio:MTIMe) .
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public PowSensFiltTypeEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:FILTer:TYPE?").ToScpiEnum<PowSensFiltTypeEnum>();
        }
    }
}
