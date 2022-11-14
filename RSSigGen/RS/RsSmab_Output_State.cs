using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Output_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Output_State
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut<HW>:[STATe]:PON
        //     Defines the state of the RF output signal when the instrument is switched on.
        //     pon: OFF| UNCHanged
        public UnchOffEnum Pon
        {
            get
            {
                return _grpBase.IO.QueryString("OUTPut<HwInstance>:STATe:PON?").ToScpiEnum<UnchOffEnum>();
            }
            set
            {
                _grpBase.IO.Write("OUTPut<HwInstance>:STATe:PON " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     OUTPut<HW>:[STATe]
        //     Activates the RF output signal.
        //     state: 0| 1| OFF| ON
        public bool Value
        {
            get
            {
                return _grpBase.IO.QueryBoolean("OUTPut<HwInstance>:STATe?");
            }
            set
            {
                _grpBase.IO.Write("OUTPut<HwInstance>:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Output_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }
    }
}
