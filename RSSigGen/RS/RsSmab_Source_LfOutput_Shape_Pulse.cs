using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape_Pulse commands group definition
    //     Sub-classes count: 3
    //     Commands count: 0
    //     Total commands count: 3
    public class RsSmab_Source_LfOutput_Shape_Pulse
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Shape_Pulse_Dcycle _dcycle;

        private RsSmab_Source_LfOutput_Shape_Pulse_Period _period;

        private RsSmab_Source_LfOutput_Shape_Pulse_Width _width;

        //
        // Сводка:
        //     Dcycle commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Pulse_Dcycle Dcycle => _dcycle ?? (_dcycle = new RsSmab_Source_LfOutput_Shape_Pulse_Dcycle(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Period commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Pulse_Period Period => _period ?? (_period = new RsSmab_Source_LfOutput_Shape_Pulse_Period(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Width commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Shape_Pulse_Width Width => _width ?? (_width = new RsSmab_Source_LfOutput_Shape_Pulse_Width(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LfOutput_Shape_Pulse(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Pulse", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Shape_Pulse Clone()
        {
            RsSmab_Source_LfOutput_Shape_Pulse rsSmab_Source_LfOutput_Shape_Pulse = new RsSmab_Source_LfOutput_Shape_Pulse(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Shape_Pulse);
            return rsSmab_Source_LfOutput_Shape_Pulse;
        }
    }
}
