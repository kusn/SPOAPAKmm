using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Am_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Am_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:STATe
        //     Activates amplitude modulation.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:STATe
        //     Activates amplitude modulation.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(bool state, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:AM" + repCapCmdValue + ":STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:STATe
        //     Activates amplitude modulation.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        public bool Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:STATe
        //     Activates amplitude modulation.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public bool Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:AM" + repCapCmdValue + ":STATe?");
        }
    }
}
