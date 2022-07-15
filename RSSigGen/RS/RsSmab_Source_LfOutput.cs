using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput commands group definition
    //     Sub-classes count: 8
    //     Commands count: 2
    //     Total commands count: 34
    //     Repeated Capability: LfOutputRepCap, default value after init: LfOutputRepCap.Nr1
    public class RsSmab_Source_LfOutput
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Bandwidth _bandwidth;

        private RsSmab_Source_LfOutput_Frequency _frequency;

        private RsSmab_Source_LfOutput_Internal _internal;

        private RsSmab_Source_LfOutput_Period _period;

        private RsSmab_Source_LfOutput_Shape _shape;

        private RsSmab_Source_LfOutput_Source _source;

        private RsSmab_Source_LfOutput_Sweep _sweep;

        private RsSmab_Source_LfOutput_State _state;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to LfOutputRepCap.Default
        //     Default value after init: LfOutputRepCap.Nr1
        public LfOutputRepCap RepCapLfOutput
        {
            get
            {
                return (LfOutputRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Bandwidth commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Bandwidth Bandwidth => _bandwidth ?? (_bandwidth = new RsSmab_Source_LfOutput_Bandwidth(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 5
        //     Total commands count: 5
        public RsSmab_Source_LfOutput_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_LfOutput_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Internal commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Internal Internal => _internal ?? (_internal = new RsSmab_Source_LfOutput_Internal(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Period commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Period Period => _period ?? (_period = new RsSmab_Source_LfOutput_Period(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Shape commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 10
        public RsSmab_Source_LfOutput_Shape Shape => _shape ?? (_shape = new RsSmab_Source_LfOutput_Shape(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Source commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_Source Source => _source ?? (_source = new RsSmab_Source_LfOutput_Source(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_Source_LfOutput_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Source_LfOutput_Sweep(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_LfOutput_State State => _state ?? (_state = new RsSmab_Source_LfOutput_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce]:LFOutput:OFFSet
        //     Sets a DC offset at the LF Output.
        //     offset: float Range: depends on lfo voltage
        public double Offset
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce:LFOutput:OFFSet?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:LFOutput:OFFSet " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce]:LFOutput:VOLTage
        //     Sets the voltage of the LF output.
        //     voltage: float Range: dynamic (see data sheet)
        public double Voltage
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce:LFOutput:VOLTage?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:LFOutput:VOLTage " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_LfOutput(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("LfOutput", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(LfOutputRepCap), _grpBase.GroupName, "RepCapLfOutput", LfOutputRepCap.Nr1);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput Clone()
        {
            RsSmab_Source_LfOutput rsSmab_Source_LfOutput = new RsSmab_Source_LfOutput(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput);
            return rsSmab_Source_LfOutput;
        }
    }
}
