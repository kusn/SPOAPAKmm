using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Bb_Dme commands group definition
    //     Sub-classes count: 2
    //     Commands count: 2
    //     Total commands count: 6
    public class RsSmab_Source_Bb_Dme
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Bb_Dme_Setting _setting;

        private RsSmab_Source_Bb_Dme_Gaussian _gaussian;

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Bb_Dme_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Bb_Dme_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Gaussian commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Bb_Dme_Gaussian Gaussian => _gaussian ?? (_gaussian = new RsSmab_Source_Bb_Dme_Gaussian(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:BB:DME:STATe
        //     No additional help available
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:BB:DME:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:BB:DME:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Bb_Dme(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dme", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Bb_Dme Clone()
        {
            RsSmab_Source_Bb_Dme rsSmab_Source_Bb_Dme = new RsSmab_Source_Bb_Dme(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Bb_Dme);
            return rsSmab_Source_Bb_Dme;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:DME:PRESet
        //     No additional help available
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:BB:DME:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:DME:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:BB:DME:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:BB:DME:PRESet", opcTimeoutMs);
        }
    }
}
