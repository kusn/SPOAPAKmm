using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Csynthesis_Frequency_Step _step;

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Csynthesis_Frequency_Step Step => _step ?? (_step = new RsSmab_Csynthesis_Frequency_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CSYNthesis:FREQuency
        //     Sets the frequency of the generated clock signal.
        //     frequency: float Numerical value Sets the frequency UP|DOWN Varies the frequency
        //     step by step. The frequency is increased or decreased by the value set with the
        //     command method RsSmab.Csynthesis.Frequency.Step.Value. Range: 100E3 to 1.5E9
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:FREQuency?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:FREQuency " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Csynthesis_Frequency Clone()
        {
            RsSmab_Csynthesis_Frequency rsSmab_Csynthesis_Frequency = new RsSmab_Csynthesis_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Csynthesis_Frequency);
            return rsSmab_Csynthesis_Frequency;
        }
    }
}
