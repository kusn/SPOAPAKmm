using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Attenuation_RfOff commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Power_Attenuation_RfOff
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ATTenuation:RFOFf:MODE
        //     Selects the state the attenuator is to assume if the RF signal is switched off.
        //     mode: UNCHanged| FATTenuation FATTenuation The step attenuator switches to maximum
        //     attenuation UNCHanged Retains the current setting and keeps the output impedance
        //     constant during RF off.
        public PowAttRfOffModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ATTenuation:RFOFf:MODE?").ToScpiEnum<PowAttRfOffModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ATTenuation:RFOFf:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Power_Attenuation_RfOff(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("RfOff", core, parent);
        }
    }
}
