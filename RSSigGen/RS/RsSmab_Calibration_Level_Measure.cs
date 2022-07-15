using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_Measure commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_Measure
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calibration_Level_Measure(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measure", core, parent);
        }

        private bool _Get(string queryArgs)
        {
            return _grpBase.IO.QueryBoolean(("CALibration<HwInstance>:LEVel:MEASure? " + queryArgs).TrimEnd());
        }

        //
        // Сводка:
        //     CALibration<HW>:LEVel:[MEASure]
        //     No additional help available
        public bool Get(string force)
        {
            string queryArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(force, 0, DataType.String));
            return _Get(queryArgs);
        }

        //
        // Сводка:
        //     CALibration<HW>:LEVel:[MEASure]
        //     No additional help available
        public bool Get()
        {
            return _Get("");
        }
    }
}
