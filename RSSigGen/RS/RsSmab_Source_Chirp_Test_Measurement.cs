using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp_Test_Measurement commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Chirp_Test_Measurement
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:TEST:MEASurement:DELay
        //     No additional help available
        public bool Delay
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:CHIRp:TEST:MEASurement:DELay?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CHIRp:TEST:MEASurement:DELay " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Chirp_Test_Measurement(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Measurement", core, parent);
        }
    }
}
