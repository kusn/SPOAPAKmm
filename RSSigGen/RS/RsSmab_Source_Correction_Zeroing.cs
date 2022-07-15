using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Zeroing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Correction_Zeroing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:ZERoing:STATe
        //     Activates the zeroing procedure before filling the user correction data acquired
        //     by a sensor.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:CORRection:ZERoing:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:ZERoing:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Correction_Zeroing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Zeroing", core, parent);
        }
    }
}
