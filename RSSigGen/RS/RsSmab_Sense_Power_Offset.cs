using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Offset commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Sense_Power_Offset
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Offset_State _state;

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Offset_State State => _state ?? (_state = new RsSmab_Sense_Power_Offset_State(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Power_Offset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Offset", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Offset Clone()
        {
            RsSmab_Sense_Power_Offset rsSmab_Sense_Power_Offset = new RsSmab_Sense_Power_Offset(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Offset);
            return rsSmab_Sense_Power_Offset;
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:OFFSet
        //     Sets a level offset which is added to the measured level value after activation
        //     with command OFFSet:STATe. The level offset allows, e.g. to consider an attenuator
        //     in the signal path.
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        //
        // Параметры:
        //   offset:
        //     float Range: -100.0 to 100.0, Unit: dB
        public void Set(double offset)
        {
            Set(offset, ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:OFFSet
        //     Sets a level offset which is added to the measured level value after activation
        //     with command OFFSet:STATe. The level offset allows, e.g. to consider an attenuator
        //     in the signal path.
        //
        // Параметры:
        //   offset:
        //     float Range: -100.0 to 100.0, Unit: dB
        //
        //   channel:
        //     Repeated capability selector
        public void Set(double offset, ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            _grpBase.IO.Write("SENSe" + repCapCmdValue + ":POWer:OFFSet " + offset.ToDoubleString());
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:OFFSet
        //     Sets a level offset which is added to the measured level value after activation
        //     with command OFFSet:STATe. The level offset allows, e.g. to consider an attenuator
        //     in the signal path.
        //     offset: float Range: -100.0 to 100.0, Unit: dB
        //     Used Repeated Capabilities default values:
        //     ChannelRepCap.Nr1 (settable in the interface "Sense")
        public double Get()
        {
            return Get(ChannelRepCap.Default);
        }

        //
        // Сводка:
        //     SENSe<CH>:[POWer]:OFFSet
        //     Sets a level offset which is added to the measured level value after activation
        //     with command OFFSet:STATe. The level offset allows, e.g. to consider an attenuator
        //     in the signal path.
        //     offset: float Range: -100.0 to 100.0, Unit: dB
        //
        // Параметры:
        //   channel:
        //     Repeated capability selector
        public double Get(ChannelRepCap channel)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(channel);
            return _grpBase.IO.QueryDouble("SENSe" + repCapCmdValue + ":POWer:OFFSet?");
        }
    }
}
