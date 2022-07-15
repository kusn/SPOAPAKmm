using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_Sensitivity_Linear commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Am_Sensitivity_Linear
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Am_Sensitivity_Linear(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Linear", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:SENSitivity:[LINear]
        //     For AM:TYPE LIN, sets the sensitivity of the external signal source for amplitude
        //     modulation.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        //
        // Параметры:
        //   sensitivity:
        //     float Range: 0 to 100
        public void Set(double sensitivity)
        {
            Set(sensitivity, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:SENSitivity:[LINear]
        //     For AM:TYPE LIN, sets the sensitivity of the external signal source for amplitude
        //     modulation.
        //
        // Параметры:
        //   sensitivity:
        //     float Range: 0 to 100
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(double sensitivity, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:AM" + repCapCmdValue + ":SENSitivity:LINear " + sensitivity.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:SENSitivity:[LINear]
        //     For AM:TYPE LIN, sets the sensitivity of the external signal source for amplitude
        //     modulation.
        //     sensitivity: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        public double Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:SENSitivity:[LINear]
        //     For AM:TYPE LIN, sets the sensitivity of the external signal source for amplitude
        //     modulation.
        //     sensitivity: float Range: 0 to 100
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public double Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:AM" + repCapCmdValue + ":SENSitivity:LINear?");
        }
    }
}
