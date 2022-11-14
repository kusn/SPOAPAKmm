using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Trapeze commands group definition
    //     Sub-classes count: 4
    //     Commands count: 0
    //     Total commands count: 4
    public class RsSmab_Source_LfOutput_Shape_Trapeze
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Shape_Trapeze_Fall _fall;

        private RsSmab_Source_LfOutput_Shape_Trapeze_High _high;

        private RsSmab_Source_LfOutput_Shape_Trapeze_Period _period;

        private RsSmab_Source_LfOutput_Shape_Trapeze_Rise _rise;

        //
        // Сводка:
        //     Fall commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Trapeze_Fall Fall => _fall ?? (_fall = new RsSmab_Source_LfOutput_Shape_Trapeze_Fall(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     High commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Trapeze_High High => _high ?? (_high = new RsSmab_Source_LfOutput_Shape_Trapeze_High(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Period commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Trapeze_Period Period => _period ?? (_period = new RsSmab_Source_LfOutput_Shape_Trapeze_Period(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Rise commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Trapeze_Rise Rise => _rise ?? (_rise = new RsSmab_Source_LfOutput_Shape_Trapeze_Rise(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LfOutput_Shape_Trapeze(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trapeze", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Shape_Trapeze Clone()
        {
            RsSmab_Source_LfOutput_Shape_Trapeze rsSmab_Source_LfOutput_Shape_Trapeze = new RsSmab_Source_LfOutput_Shape_Trapeze(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Shape_Trapeze);
            return rsSmab_Source_LfOutput_Shape_Trapeze;
        }
    }
}
