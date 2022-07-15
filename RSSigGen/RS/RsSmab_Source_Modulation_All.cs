using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Modulation_All commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Modulation_All
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:MODulation:[ALL]:[STATe]
        //     Activates all modulations that were active before the last switching off.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:MODulation:ALL:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:MODulation:ALL:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Modulation_All(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("All", core, parent);
        }
    }
}
