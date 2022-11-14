using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Unit_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Unit_Power
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Sense_Unit_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     SENSe<CH>:UNIT:[POWer]
        //     Selects the unit (Watt, dBm or dBμV) of measurement result display, queried with
        //     :​READ<ch>[:​POWer]?.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   power:
        //     DBM| DBUV| WATT
        public void Set(UnitPowSensEnum power)
        {
            Set(power, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:UNIT:[POWer]
        //     Selects the unit (Watt, dBm or dBμV) of measurement result display, queried with
        //     :​READ<ch>[:​POWer]?.
        //
        // Параметры:
        //   power:
        //     DBM| DBUV| WATT
        //
        //   channel:
        //     Repeated capability selector
        public void Set(UnitPowSensEnum power, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":UNIT:POWer " + power.ToScpiString());
        }

        //
        // Сводка:
        //     SENSe<CH>:UNIT:[POWer]
        //     Selects the unit (Watt, dBm or dBμV) of measurement result display, queried with
        //     :​READ<ch>[:​POWer]?.
        //     power: DBM| DBUV| WATT
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public UnitPowSensEnum Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:UNIT:[POWer]
        //     Selects the unit (Watt, dBm or dBμV) of measurement result display, queried with
        //     :​READ<ch>[:​POWer]?.
        //     power: DBM| DBUV| WATT
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public UnitPowSensEnum Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryString("SENSe" + repCapCmdValue + ":UNIT:POWer?").ToScpiEnum<UnitPowSensEnum>();
        }
    }
}
