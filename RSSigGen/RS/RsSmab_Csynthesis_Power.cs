using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Csynthesis_Power_Step _step;

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Csynthesis_Power_Step Step => _step ?? (_step = new RsSmab_Csynthesis_Power_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CSYNthesis:POWer
        //     Sets the power level of the generated clock signal.
        //     power: float Numerical value Sets the level UP|DOWN Varies the level step by
        //     step. The level is increased or decreased by the value set with the command method
        //     RsSmab.Csynthesis.Power.Value. Range: -24 to 10
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:POWer?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:POWer " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Csynthesis_Power Clone()
        {
            RsSmab_Csynthesis_Power rsSmab_Csynthesis_Power = new RsSmab_Csynthesis_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Csynthesis_Power);
            return rsSmab_Csynthesis_Power;
        }
    }
}
