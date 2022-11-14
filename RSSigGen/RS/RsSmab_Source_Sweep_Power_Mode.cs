using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Power_Mode commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Sweep_Power_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:MODE:ADVanced
        //     No additional help available
        public AutoManualModeEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:POWer:MODE:ADVanced?").ToScpiEnum<AutoManualModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:MODE:ADVanced " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:MODE
        //     Sets the cycle mode for the level sweep.
        //     mode: AUTO| MANual| STEP AUTO Each trigger triggers exactly one complete sweep.
        //     MANual The trigger system is not active. You can trigger every step individually
        //     with the command POWer:MANual. The level value increases at each step by the
        //     value that you define with POWer. Values directly entered with the command POWer:MANual
        //     are not taken into account. STEP Each trigger triggers one sweep step only. The
        //     level increases by the value entered with POWer.
        public AutoManStepEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:POWer:MODE?").ToScpiEnum<AutoManStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:POWer:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Power_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
