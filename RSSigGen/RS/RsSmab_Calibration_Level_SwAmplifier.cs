using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level_SwAmplifier commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Calibration_Level_SwAmplifier
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CALibration:LEVel:SWAMplifier:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("CALibration:LEVel:SWAMplifier:STATe?");
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:SWAMplifier:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Calibration_Level_SwAmplifier(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("SwAmplifier", core, parent);
        }
    }
}
