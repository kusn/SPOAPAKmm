using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Triangle commands group definition
    //     Sub-classes count: 2
    //     Commands count: 0
    //     Total commands count: 2
    public class RsSmab_Source_LfOutput_Shape_Triangle
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Shape_Triangle_Period _period;

        private RsSmab_Source_LfOutput_Shape_Triangle_Rise _rise;

        //
        // Сводка:
        //     Period commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Triangle_Period Period => _period ?? (_period = new RsSmab_Source_LfOutput_Shape_Triangle_Period(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Rise commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Triangle_Rise Rise => _rise ?? (_rise = new RsSmab_Source_LfOutput_Shape_Triangle_Rise(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LfOutput_Shape_Triangle(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Triangle", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Shape_Triangle Clone()
        {
            RsSmab_Source_LfOutput_Shape_Triangle rsSmab_Source_LfOutput_Shape_Triangle = new RsSmab_Source_LfOutput_Shape_Triangle(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Shape_Triangle);
            return rsSmab_Source_LfOutput_Shape_Triangle;
        }
    }
}
