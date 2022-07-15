using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Frequency_Timing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Frequency_Timing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:FREQuency:TIMing:[MODE]
        //     Selects the mode in terms of speed and precision of the response of a measurement.
        //     mode: FAST| NORMal| HPRecision | FAST| NORMal FAST Selection FAST leads to a
        //     fast measurement with a short integration time for each measurement step. NORMal
        //     NORMal leads to a longer but more precise measurement due to a higher integration
        //     time for each step.
        public MeasRespTimingModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:FREQuency:TIMing:MODE?").ToScpiEnum<MeasRespTimingModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:FREQuency:TIMing:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Frequency_Timing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Timing", core, parent);
        }
    }
}
