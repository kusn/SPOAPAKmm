using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Phase commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Source_Phase
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Phase_Reference _reference;

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Phase_Reference Reference => _reference ?? (_reference = new RsSmab_Source_Phase_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:PHASe
        //     Sets the phase variation relative to the current phase.
        //     phase: float Range: -36000 to 36000 , Unit: DEG
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:PHASe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PHASe " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Phase(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Phase", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Phase Clone()
        {
            RsSmab_Source_Phase rsSmab_Source_Phase = new RsSmab_Source_Phase(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Phase);
            return rsSmab_Source_Phase;
        }
    }
}
