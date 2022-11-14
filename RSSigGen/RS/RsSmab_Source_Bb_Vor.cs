using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Vor commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 5
    public class RsSmab_Source_Bb_Vor
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Bb_Vor_Setting _setting;

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Bb_Vor_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Bb_Vor_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:BB:VOR:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:BB:VOR:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:BB:VOR:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Bb_Vor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Vor", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Bb_Vor Clone()
        {
            RsSmab_Source_Bb_Vor rsSmab_Source_Bb_Vor = new RsSmab_Source_Bb_Vor(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Bb_Vor);
            return rsSmab_Source_Bb_Vor;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:VOR:PRESet
        //     No additional help available
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:VOR:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:VOR:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:VOR:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:BB:VOR:PRESet", opcTimeoutMs);
        }
    }
}
