using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Direct commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Direct
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Power_Direct(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Direct", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DIRect
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public void Set(string command)
        {
            Set(command, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:DIRect
        //     No additional help available
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public void Set(string command, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:DIRect " + command.EncloseByQuotes());
        }
    }
}
