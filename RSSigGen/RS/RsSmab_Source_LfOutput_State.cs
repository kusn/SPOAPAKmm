using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_LfOutput_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_LfOutput_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:[STATe]
        //     Activates LF signal output.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:[STATe]
        //     Activates LF signal output.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(bool state, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce:LFOutput" + repCapCmdValue + ":STATe " + state.ToBooleanString());
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:[STATe]
        //     Activates LF signal output.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public bool Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput<CH>:[STATe]
        //     Activates LF signal output.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public bool Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryBoolean("SOURce:LFOutput" + repCapCmdValue + ":STATe?");
        }
    }
}
