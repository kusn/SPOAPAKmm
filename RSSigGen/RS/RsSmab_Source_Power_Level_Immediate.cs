using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Level_Immediate commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_Power_Level_Immediate
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:[LEVel]:[IMMediate]:OFFSet
        //     Sets the level offset of a downstream instrument. The level at the RF output
        //     is not changed. To query the resulting level, as it is at the output of the downstream
        //     instrument, use the command [:​SOURce<hw>]:​POWer[:​LEVel][:​IMMediate][:​AMPLitude].
        //     See "RF frequency and level display with a downstream instrument". Note: The
        //     level offset also affects the RF level sweep.
        //     offset: float Range: -100 to 100 , Unit: dB Level offset is always expreced in
        //     dB; linear units (V, W, etc.) are not supported
        public double Offset
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:LEVel:IMMediate:OFFSet?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LEVel:IMMediate:OFFSet " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:[LEVel]:[IMMediate]:RCL
        //     Determines whether the current level is retained or if the stored level setting
        //     is adopted when an instrument configuration is loaded.
        //     rcl: INCLude| EXCLude INCLude Takes the current level when an instrument configuration
        //     is loaded. EXCLude Retains the current level when an instrument configuration
        //     is loaded.
        public InclExclEnum Recall
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:LEVel:IMMediate:RCL?").ToScpiEnum<InclExclEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LEVel:IMMediate:RCL " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:[LEVel]:[IMMediate]:[AMPLitude]
        //     Sets the RF level applied to the DUT. To activate the RF output use command :​OUTPut<hw>[:​STATe]
        //     ("RF On"/"RF Off") . Table Header: The following applies POWer = RF output level
        //     + OFFSet, where: - POWer is the values set with [:​SOURce<hw>]:​POWer[:​LEVel][:​IMMediate][:​AMPLitude],
        //     - RF output level is set with POWer:POWer, - OFFSet is set with OFFSet
        //     amplitude: float The following settings influence the value range: OFFSet set
        //     with the command OFFSet Numerical value Sets the level UP|DOWN Varies the level
        //     step by step. The level is increased or decreased by the value set with the command
        //     POWer. Range: (Level_min + OFFSet) to (Level_max + OFFStet) , Unit: dBm
        public double Amplitude
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:LEVel:IMMediate:AMPLitude?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LEVel:IMMediate:AMPLitude " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Power_Level_Immediate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Immediate", core, parent);
        }
    }
}
