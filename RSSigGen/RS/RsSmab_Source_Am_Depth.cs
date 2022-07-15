using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_Depth commands group definition
    //     Sub-classes count: 2
    //     Commands count: 2
    //     Total commands count: 4
    public class RsSmab_Source_Am_Depth
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Am_Depth_Exponential _exponential;

        private RsSmab_Source_Am_Depth_Linear _linear;

        //
        // Сводка:
        //     Exponential commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_Depth_Exponential Exponential => _exponential ?? (_exponential = new RsSmab_Source_Am_Depth_Exponential(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Linear commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Am_Depth_Linear Linear => _linear ?? (_linear = new RsSmab_Source_Am_Depth_Linear(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:AM:DEPTh:SUM
        //     Sets the total depth of the LF signal when using combined signal sources in amplitude
        //     modulation.
        //     amDepthSum: float Range: 0 to 100
        public double Sum
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:AM:DEPTh:SUM?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:AM:DEPTh:SUM " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Am_Depth(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Depth", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Am_Depth Clone()
        {
            RsSmab_Source_Am_Depth rsSmab_Source_Am_Depth = new RsSmab_Source_Am_Depth(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Am_Depth);
            return rsSmab_Source_Am_Depth;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:[DEPTh]
        //     Sets the depth of the amplitude modulation in percent.
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        //
        // Параметры:
        //   depth:
        //     float Range: 0 to 100
        public void Set(double depth)
        {
            Set(depth, GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:[DEPTh]
        //     Sets the depth of the amplitude modulation in percent.
        //
        // Параметры:
        //   depth:
        //     float Range: 0 to 100
        //
        //   generatorIx:
        //     Repeated capability selector
        public void Set(double depth, GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            _grpBase.IO.Write("SOURce<HwInstance>:AM" + repCapCmdValue + ":DEPTh " + depth.ToDoubleString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:[DEPTh]
        //     Sets the depth of the amplitude modulation in percent.
        //     depth: float Range: 0 to 100
        //     Used Repeated Capabilities default values:
        //     GeneratorIxRepCap.Nr1 (settable in the interface "Am")
        public double Get()
        {
            return Get(GeneratorIxRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:AM<CH>:[DEPTh]
        //     Sets the depth of the amplitude modulation in percent.
        //     depth: float Range: 0 to 100
        //
        // Параметры:
        //   generatorIx:
        //     Repeated capability selector
        public double Get(GeneratorIxRepCap generatorIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(generatorIx);
            return _grpBase.IO.QueryDouble("SOURce<HwInstance>:AM" + repCapCmdValue + ":DEPTh?");
        }
    }
}
