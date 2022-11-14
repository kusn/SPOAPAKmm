using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_All_Measure commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_All_Measure
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Calibration_All_Measure(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measure", core, parent);
        }

        private bool _Get(string queryArgs)
        {
            return _grpBase.IO.QueryBoolean(("CALibration:ALL:MEASure? " + queryArgs).TrimEnd());
        }

        //
        // Сводка:
        //     CALibration:ALL:[MEASure]
        //     Starts all internal adjustments that do not need external measuring equipment.
        //     NOTICE! High power at the RF output applied during internal adjustment can destroy
        //     a connected DUT (device under test) . How to: See "Running internal adjustments".
        //     measure: 0| 1| OFF| ON
        //
        // Параметры:
        //   force:
        //     string
        public bool Get(string force)
        {
            string queryArgs = _grpBase.Core.ComposeCmdArg(new ArgSingle(force, 0, DataType.String));
            return _Get(queryArgs);
        }

        //
        // Сводка:
        //     CALibration:ALL:[MEASure]
        //     Starts all internal adjustments that do not need external measuring equipment.
        //     NOTICE! High power at the RF output applied during internal adjustment can destroy
        //     a connected DUT (device under test) . How to: See "Running internal adjustments".
        //     measure: 0| 1| OFF| ON
        public bool Get()
        {
            return _Get("");
        }
    }
}
