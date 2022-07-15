using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time commands group definition
    //     Sub-classes count: 5
    //     Commands count: 5
    //     Total commands count: 30
    public class RsSmab_Sense_Power_Sweep_Time
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Average _average;

        private RsSmab_Sense_Power_Sweep_Time_Reference _reference;

        private RsSmab_Sense_Power_Sweep_Time_Spacing _spacing;

        private RsSmab_Sense_Power_Sweep_Time_Yscale _yscale;

        private RsSmab_Sense_Power_Sweep_Time_Sensor _sensor;

        //
        // Сводка:
        //     Average commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Average Average => _average ?? (_average = new RsSmab_Sense_Power_Sweep_Time_Average(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Reference commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Time_Reference Reference => _reference ?? (_reference = new RsSmab_Sense_Power_Sweep_Time_Reference(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Spacing commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Power_Sweep_Time_Spacing Spacing => _spacing ?? (_spacing = new RsSmab_Sense_Power_Sweep_Time_Spacing(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Yscale commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 4
        public RsSmab_Sense_Power_Sweep_Time_Yscale Yscale => _yscale ?? (_yscale = new RsSmab_Sense_Power_Sweep_Time_Yscale(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 15
        public RsSmab_Sense_Power_Sweep_Time_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Sense_Power_Sweep_Time_Sensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:RMODe
        //     Selects single or continuous mode for measurement mode time in power analysis.
        //     rmode: SINGle| CONTinuous
        public RepeatModeEnum Rmode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:TIME:RMODe?").ToScpiEnum<RepeatModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:RMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:STARt
        //     Sets the start time for the power versus time measurement. Value 0 defines the
        //     trigger point. By choosing a negative time value, the trace can be shifted in
        //     the diagram. It is possible, that the measurement cannot be performed over the
        //     complete time range because of limitations due to sensor settings. In this case,
        //     an error message is output.
        //     start: float Range: -1 to 1
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:TIME:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:STEPs
        //     Sets the number of measurement steps for the power versus time measurement. Value
        //     0 defines the trigger point.
        //     steps: integer Range: 10 to 1000
        public int Steps
        {
            get
            {
                return _grpBase.IO.QueryInt32("SENSe:POWer:SWEep:TIME:STEPs?");
            }
            set
            {
                _grpBase.IO.Write($"SENSe:POWer:SWEep:TIME:STEPs {value}");
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:STOP
        //     Sets the stop time for the power versus time measurement.
        //     stop: float Range: 0 to 2
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:TIME:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:STOP " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:TEVents
        //     Determines, whether the measurement data processing starts with a trigger event
        //     in one of the sensors (Logical OR) , or whether all channels have to be triggered
        //     (logical AND) . Each sensor evaluates a trigger event according to its setting
        //     independently. This function supports the internal or external trigger modes
        //     with multi-channel time measurements.
        //     triggerTevents: AND| OR
        public MeasRespYsCaleEventsEnum Tevents
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:TIME:TEVents?").ToScpiEnum<MeasRespYsCaleEventsEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:TEVents " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Time(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Time", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time Clone()
        {
            RsSmab_Sense_Power_Sweep_Time rsSmab_Sense_Power_Sweep_Time = new RsSmab_Sense_Power_Sweep_Time(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time);
            return rsSmab_Sense_Power_Sweep_Time;
        }
    }
}
