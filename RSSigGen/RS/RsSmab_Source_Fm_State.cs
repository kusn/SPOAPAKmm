using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Fm_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Fm_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Fm_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:STATe
        //     Activates frequency modulation.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
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
        //     [SOURce<HW>]:FM<CH>:STATe
        //     Activates frequency modulation.
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
            _grpBase.IO.Write("SOURce<HwInstance>:FM" + repCapCmdValue + ":STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:STATe
        //     Activates frequency modulation.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Fm")
        public bool Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:FM<CH>:STATe
        //     Activates frequency modulation.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public bool Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:FM" + repCapCmdValue + ":STATe?");
        }
    }
}
