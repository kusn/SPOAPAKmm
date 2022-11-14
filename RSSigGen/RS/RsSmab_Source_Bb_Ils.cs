using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Ils commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 5
    public class RsSmab_Source_Bb_Ils
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Bb_Ils_Setting _setting;

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Bb_Ils_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Bb_Ils_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:BB:ILS:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:BB:ILS:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Bb_Ils(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ils", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Bb_Ils Clone()
        {
            RsSmab_Source_Bb_Ils rsSmab_Source_Bb_Ils = new RsSmab_Source_Bb_Ils(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Bb_Ils);
            return rsSmab_Source_Bb_Ils;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:PRESet
        //     No additional help available
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:ILS:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[BB]:ILS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:BB:ILS:PRESet", opcTimeoutMs);
        }
    }
}
