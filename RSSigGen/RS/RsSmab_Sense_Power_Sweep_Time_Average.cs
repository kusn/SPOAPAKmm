using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Average commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Average
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:AVERage:[COUNt]
        //     Selects the averaging factor in time mode. The count number determines how many
        //     measurement cycles are used to form a measurement result. Higher averaging counts
        //     reduce noise but increase the measurement time. Averaging requires a stable trigger
        //     event so that the measurement cycles have the same timing.
        //     count: 1| 2| 4| 8| 16| 32| 64| 128| 256| 512| 1024
        public MeasRespTimeAverageEnum Count
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:TIME:AVERage:COUNt?").ToScpiEnum<MeasRespTimeAverageEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:AVERage:COUNt " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Time_Average(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Average", core, parent);
        }
    }
}
