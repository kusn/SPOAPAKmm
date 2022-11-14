using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils commands group definition
    //     Sub-classes count: 5
    //     Commands count: 3
    //     Total commands count: 96
    public class RsSmab_Source_Ils
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Ils_Gs _gs;

        private RsSmab_Source_Ils_Gslope _gslope;

        private RsSmab_Source_Ils_Localizer _localizer;

        private RsSmab_Source_Ils_Setting _setting;

        private RsSmab_Source_Ils_Mbeacon _mbeacon;

        //
        // Сводка:
        //     Gs commands group
        //     Sub-classes count: 5
        //     Commands count: 6
        //     Total commands count: 20
        public RsSmab_Source_Ils_Gs Gs => _gs ?? (_gs = new RsSmab_Source_Ils_Gs(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Gslope commands group
        //     Sub-classes count: 5
        //     Commands count: 6
        //     Total commands count: 20
        public RsSmab_Source_Ils_Gslope Gslope => _gslope ?? (_gslope = new RsSmab_Source_Ils_Gslope(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Localizer commands group
        //     Sub-classes count: 6
        //     Commands count: 6
        //     Total commands count: 32
        public RsSmab_Source_Ils_Localizer Localizer => _localizer ?? (_localizer = new RsSmab_Source_Ils_Localizer(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Setting commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Source_Ils_Setting Setting => _setting ?? (_setting = new RsSmab_Source_Ils_Setting(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mbeacon commands group
        //     Sub-classes count: 3
        //     Commands count: 1
        //     Total commands count: 17
        public RsSmab_Source_Ils_Mbeacon Mbeacon => _mbeacon ?? (_mbeacon = new RsSmab_Source_Ils_Mbeacon(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:STATe
        //     Activates/deactivates the VOR modulation.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:ILS:STATe?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:TYPE
        //     Selects the ILS modulation type.
        //     type: GS| LOCalize| GSLope| MBEacon
        public AvionicIlsTypeEnum Type
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:ILS:TYPE?").ToScpiEnum<AvionicIlsTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:ILS:TYPE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Ils(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ils", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Ils Clone()
        {
            RsSmab_Source_Ils rsSmab_Source_Ils = new RsSmab_Source_Ils(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Ils);
            return rsSmab_Source_Ils;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:PRESet
        //     Sets the parameters of the digital standard to their default values (*RST values
        //     specified for the commands) . Not affected is the state set with the command
        //     SOURce<hw>:VOR:STATe.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ILS:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:ILS:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ILS:PRESet", opcTimeoutMs);
        }
    }
}
