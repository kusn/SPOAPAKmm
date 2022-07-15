using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Noise commands group definition
    //     Sub-classes count: 2
    //     Commands count: 1
    //     Total commands count: 5
    public class RsSmab_Source_Noise
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Noise_Bandwidth _bandwidth;

        private RsSmab_Source_Noise_Level _level;

        //
        // Сводка:
        //     Bandwidth commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Noise_Bandwidth Bandwidth => _bandwidth ?? (_bandwidth = new RsSmab_Source_Noise_Bandwidth(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Level commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Noise_Level Level => _level ?? (_level = new RsSmab_Source_Noise_Level(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:NOISe:DISTribution
        //     Sets the distribution of the noise power density.
        //     distribution: GAUSs| EQUal
        public NoisDistribEnum Distribution
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:NOISe:DISTribution?").ToScpiEnum<NoisDistribEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:NOISe:DISTribution " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Noise(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Noise", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Noise Clone()
        {
            RsSmab_Source_Noise rsSmab_Source_Noise = new RsSmab_Source_Noise(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Noise);
            return rsSmab_Source_Noise;
        }
    }
}
