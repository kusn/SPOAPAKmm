using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Csynthesis_Frequency _frequency;

        private RsSmab_Csynthesis_Offset _offset;

        private RsSmab_Csynthesis_Phase _phase;

        private RsSmab_Csynthesis_Power _power;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_Csynthesis_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Csynthesis_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Offset commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Csynthesis_Offset Offset => _offset ?? (_offset = new RsSmab_Csynthesis_Offset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Phase commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Csynthesis_Phase Phase => _phase ?? (_phase = new RsSmab_Csynthesis_Phase(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 3
        public RsSmab_Csynthesis_Power Power => _power ?? (_power = new RsSmab_Csynthesis_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CSYNthesis:OTYPe
        //     Defines the shape of the generated clock signal.
        //     mode: SESine| DSQuare| CMOS| DSINe SESine = single-ended sine DSINe = differential
        //     sine DSQuare = differential square CMOS = CMOS
        public ClkSynOutTypeEnum Otype
        {
            get
            {
                return _grpBase.IO.QueryString("CSYNthesis:OTYPe?").ToScpiEnum<ClkSynOutTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:OTYPe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CSYNthesis:STATe
        //     Activates the clock synthesis.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("CSYNthesis:STATe?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     CSYNthesis:VOLTage
        //     Sets the voltage for the CMOS signal.
        //     voltage: float Range: 0.8 to 2.7
        public double Voltage
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:VOLTage?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:VOLTage " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Csynthesis", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Csynthesis Clone()
        {
            RsSmab_Csynthesis rsSmab_Csynthesis = new RsSmab_Csynthesis(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Csynthesis);
            return rsSmab_Csynthesis;
        }
    }
}
