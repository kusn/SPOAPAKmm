using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power commands group definition
    //     Sub-classes count: 5
    //     Commands count: 4
    //     Total commands count: 18
    public class RsSmab_Sense_Power_Sweep_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Power_Reference _reference;

        private RsSmab_Sense_Power_Sweep_Power_Spacing _spacing;

        private RsSmab_Sense_Power_Sweep_Power_Timing _timing;

        private RsSmab_Sense_Power_Sweep_Power_Yscale _yscale;

        private RsSmab_Sense_Power_Sweep_Power_Sensor _sensor;

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Power_Reference Reference => _reference ?? (_reference = new RsSmab_Sense_Power_Sweep_Power_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Spacing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Power_Spacing Spacing => _spacing ?? (_spacing = new RsSmab_Sense_Power_Sweep_Power_Spacing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Timing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Power_Timing Timing => _timing ?? (_timing = new RsSmab_Sense_Power_Sweep_Power_Timing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Yscale commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Power_Yscale Yscale => _yscale ?? (_yscale = new RsSmab_Sense_Power_Sweep_Power_Yscale(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Power_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Sense_Power_Sweep_Power_Sensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:RMODe
        //     Selects single or continuous mode for measurement mode power in power analysis.
        //     rmode: SINGle| CONTinuous
        public RepeatModeEnum Rmode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:POWer:RMODe?").ToScpiEnum<RepeatModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:RMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:STARt
        //     Sets the start level for the power versus power measurement.
        //     start: float Range: -145 to 20
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:POWer:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:STEPs
        //     Sets the number of measurement steps for the power versus power measurement.
        //     steps: integer Range: 10 to 1000
        public int Steps
        {
            get
            {
                return _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:POWer:STEPs?");
            }
            set
            {
                _grpBase.IO.Write($"SENSe:POWer:SWEep:POWer:STEPs {value}");
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:STOP
        //     Sets the stop level for the power versus power measurement.
        //     stop: float Range: -145 to 20
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:POWer:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:STOP " + value.ToDoubleString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Power Clone()
        {
            RsSmab_Sense_Power_Sweep_Power rsSmab_Sense_Power_Sweep_Power = new RsSmab_Sense_Power_Sweep_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Power);
            return rsSmab_Sense_Power_Sweep_Power;
        }
    }
}
