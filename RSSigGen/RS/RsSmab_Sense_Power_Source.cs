using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SOURce
        //     Determines the signal to be measured. Note: When measuring the RF signal, the
        //     sensor considers the corresponding correction factor at that frequency, and uses
        //     the level setting of the instrument as reference level.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   source:
        //     A| USER| RF
        public void Set(PowSensSourceEnum source)
        {
            Set(source, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SOURce
        //     Determines the signal to be measured. Note: When measuring the RF signal, the
        //     sensor considers the corresponding correction factor at that frequency, and uses
        //     the level setting of the instrument as reference level.
        //
        // Параметры:
        //   source:
        //     A| USER| RF
        //
        //   channel:
        //     Repeated capability selector
        public void Set(PowSensSourceEnum source, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SOURce
        //     Determines the signal to be measured. Note: When measuring the RF signal, the
        //     sensor considers the corresponding correction factor at that frequency, and uses
        //     the level setting of the instrument as reference level.
        //     source: A| USER| RF
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public PowSensSourceEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:SOURce
        //     Determines the signal to be measured. Note: When measuring the RF signal, the
        //     sensor considers the corresponding correction factor at that frequency, and uses
        //     the level setting of the instrument as reference level.
        //     source: A| USER| RF
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public PowSensSourceEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":POWer:SOURce?").ToScpiEnum<PowSensSourceEnum>();
        }
    }
}
