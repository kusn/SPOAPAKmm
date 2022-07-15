using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_Depth_Linear commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Am_Depth_Linear
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Source_Am_Depth_Linear(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Linear", core, parent);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:DEPTh:LINear
        //     Sets the depth of the linear amplitude modulation in percent / volt.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        //
        // Параметры:
        //   depthLin:
        //     float Range: 0 to 100
        public void Set(double depthLin)
        {
            Set(depthLin, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:DEPTh:LINear
        //     Sets the depth of the linear amplitude modulation in percent / volt.
        //
        // Параметры:
        //   depthLin:
        //     float Range: 0 to 100
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(double depthLin, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:AM" + repCapCmdValue + ":DEPTh:LINear " + depthLin.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:DEPTh:LINear
        //     Sets the depth of the linear amplitude modulation in percent / volt.
        //     depthLin: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        public double Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:DEPTh:LINear
        //     Sets the depth of the linear amplitude modulation in percent / volt.
        //     depthLin: float Range: 0 to 100
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public double Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:AM" + repCapCmdValue + ":DEPTh:LINear?");
        }
    }
}
