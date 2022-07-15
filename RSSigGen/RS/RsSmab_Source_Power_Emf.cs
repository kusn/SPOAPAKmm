using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Emf commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Power_Emf
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:EMF:STATe
        //     Displays the signal level as voltage of the EMF. The displayed value represents
        //     the voltage over a 50 Ohm load.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:POWer:EMF:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:EMF:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Power_Emf(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Emf", core, parent);
        }
    }
}
