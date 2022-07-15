using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power_Timing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Power_Timing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:TIMing:[MODE]
        //     Selects the timing mode of the measurement.
        //     mode: FAST| NORMal| HPRecision | FAST| NORMal FAST Selection FAST leads to a
        //     fast measurement with a short integration times for each measurement step. NORMal
        //     NORMal leads to a longer but more precise measurement due to a higher integration
        //     time for each step.
        public MeasRespTimingModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:POWer:TIMing:MODE?").ToScpiEnum<MeasRespTimingModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:TIMing:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Power_Timing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Timing", core, parent);
        }
    }
}
