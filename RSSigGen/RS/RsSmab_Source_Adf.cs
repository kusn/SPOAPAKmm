using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Adf commands group definition
    //     Sub-classes count: 2
    //     Commands count: 2
    //     Total commands count: 16
    public class RsSmab_Source_Adf
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Adf_Comid _comid;

        private RsSmab_Source_Adf_Setting _setting;

        //
        // Сводка:
        //     Comid commands group
        //     Sub-classes count: 0
        //     Commands count: 10
        //     Total commands count: 10
        public RsSmab_Source_Adf_Comid Comid => _comid ?? (_comid = new RsSmab_Source_Adf_Comid(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Source_Adf_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Adf_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:STATe
        //     Activates/deactivates the VOR modulation.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ADF:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ADF:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Adf(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Adf", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Adf Clone()
        {
            RsSmab_Source_Adf rsSmab_Source_Adf = new RsSmab_Source_Adf(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Adf);
            return rsSmab_Source_Adf;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:PRESet
        //     Sets the parameters of the digital standard to their default values (*RST values
        //     specified for the commands) . Not affected is the state set with the command
        //     SOURce<hw>:VOR:STATe.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ADF:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ADF:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ADF:PRESet", opcTimeoutMs);
        }
    }
}
