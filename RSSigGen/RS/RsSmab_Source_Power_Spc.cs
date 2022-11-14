using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Spc commands group definition
    //     Sub-classes count: 0
    //     Commands count: 6
    //     Total commands count: 6
    public class RsSmab_Source_Power_Spc
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:CRANge
        //     No additional help available
        public double Crange
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:SPC:CRANge?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:SPC:CRANge " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:DELay
        //     No additional help available
        public int Delay
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:POWer:SPC:DELay?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:POWer:SPC:DELay {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:PEAK
        //     No additional help available
        public bool Peak
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:POWer:SPC:PEAK?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:SPC:PEAK " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:SELect
        //     No additional help available
        public PowCntrlSelectEnum Select
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:SPC:SELect?").ToScpiEnum<PowCntrlSelectEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:SPC:SELect " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:POWer:SPC:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:SPC:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:SPC:TARGet
        //     No additional help available
        public double Target
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:SPC:TARGet?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:SPC:TARGet " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Power_Spc(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Spc", core, parent);
        }
    }
}
