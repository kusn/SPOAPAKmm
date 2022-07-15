using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Attenuation commands group definition
    //     Sub-classes count: 1
    //     Commands count: 3
    //     Total commands count: 4
    public class RsSmab_Source_Power_Attenuation
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Power_Attenuation_RfOff _rfOff;

        //
        // Сводка:
        //     RfOff commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Power_Attenuation_RfOff RfOff => _rfOff ?? (_rfOff = new RsSmab_Source_Power_Attenuation_RfOff(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ATTenuation:MAXLevel
        //     No additional help available
        public double MaxLevel
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:ATTenuation:MAXLevel?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ATTenuation:MAXLevel " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ATTenuation:PATTenuator
        //     Selects the type of step attenuator used below 20 GHz.
        //     stepAttSel: MECHanical| ELECtronic MECHanical Uses the mechanical step attenuator
        //     at all frequencies. ELECtronic Uses the electronic step attenuator up to 20 GHz.
        public PowAttStepArtEnum Pattenuator
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ATTenuation:PATTenuator?").ToScpiEnum<PowAttStepArtEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ATTenuation:PATTenuator " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ATTenuation:STAGe
        //     No additional help available
        public double Stage => _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:ATTenuation:STAGe?");

        internal RsSmab_Source_Power_Attenuation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Attenuation", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Power_Attenuation Clone()
        {
            RsSmab_Source_Power_Attenuation rsSmab_Source_Power_Attenuation = new RsSmab_Source_Power_Attenuation(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Power_Attenuation);
            return rsSmab_Source_Power_Attenuation;
        }
    }
}
