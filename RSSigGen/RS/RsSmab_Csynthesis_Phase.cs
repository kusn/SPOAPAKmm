using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Phase
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Csynthesis_Phase_Reference _reference;

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Csynthesis_Phase_Reference Reference => _reference ?? (_reference = new RsSmab_Csynthesis_Phase_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CSYNthesis:PHASe
        //     Shifts the phase of the generated clock signal.
        //     phase: float Range: -36000 to 36000
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:PHASe?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:PHASe " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Phase(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Phase", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Csynthesis_Phase Clone()
        {
            RsSmab_Csynthesis_Phase rsSmab_Csynthesis_Phase = new RsSmab_Csynthesis_Phase(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Csynthesis_Phase);
            return rsSmab_Csynthesis_Phase;
        }
    }
}
