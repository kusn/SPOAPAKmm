using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Protect_State commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Protect_State
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_System_Protect_State(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("State", core, parent);
        }

        private void _Set(string setArgs, LevelRepCap level)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(level);
            _grpBase.IO.Write(("SYSTem:PROTect" + repCapCmdValue + ":STATe " + setArgs).TrimEnd());
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   key:
        //     integer The respective functions are disabled when the protection level is activated.
        //     No password is required for activation of a level. A password must be entered
        //     to deactivate the protection level. The default password for the first level
        //     is 123456. This protection level is required to unlock internal adjustments for
        //     example.
        //
        //   level:
        //     Repeated capability selector
        public void Set(bool state, int key, LevelRepCap level)
        {
            string setArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(state, 0, DataType.Boolean), new ArgSingle(key, 1, DataType.Integer));
            _Set(setArgs, level);
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   level:
        //     Repeated capability selector
        public void Set(bool state, LevelRepCap level)
        {
            string setArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(state, 0, DataType.Boolean));
            _Set(setArgs, level);
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //     Used Repeated Capabilities default values:
        //     LevelRepCap.Nr1 (settable in the interface "Protect")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        //
        //   key:
        //     integer The respective functions are disabled when the protection level is activated.
        //     No password is required for activation of a level. A password must be entered
        //     to deactivate the protection level. The default password for the first level
        //     is 123456. This protection level is required to unlock internal adjustments for
        //     example.
        public void Set(bool state, int key)
        {
            Set(state, key, LevelRepCap.Default);
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //     Used Repeated Capabilities default values:
        //     LevelRepCap.Nr1 (settable in the interface "Protect")
        //
        // Параметры:
        //   state:
        //     0| 1| OFF| ON
        public void Set(bool state)
        {
            Set(state, LevelRepCap.Default);
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //     state: 0| 1| OFF| ON
        //     Used Repeated Capabilities default values:
        //     LevelRepCap.Nr1 (settable in the interface "Protect")
        public bool Get()
        {
            return Get(LevelRepCap.Default);
        }

        //
        // Сводка:
        //     SYSTem:PROTect<CH>:[STATe]
        //     Activates and deactivates the specified protection level.
        //     state: 0| 1| OFF| ON
        //
        // Параметры:
        //   level:
        //     Repeated capability selector
        public bool Get(LevelRepCap level)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(level);
            return _grpBase.IO.QueryBoolean("SYSTem:PROTect" + repCapCmdValue + ":STATe?");
        }
    }
}
