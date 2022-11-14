using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Output_Afixed _afixed;

        private RsSmab_Output_All _all;

        private RsSmab_Output_Filter _filter;

        private RsSmab_Output_Fproportional _fproportional;

        private RsSmab_Output_Protection _protection;

        private RsSmab_Output_User _user;

        private RsSmab_Output_State _state;

        //
        // Сводка:
        //     Afixed commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Output_Afixed Afixed => _afixed ?? (_afixed = new RsSmab_Output_Afixed(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     All commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Output_All All => _all ?? (_all = new RsSmab_Output_All(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Filter commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Output_Filter Filter => _filter ?? (_filter = new RsSmab_Output_Filter(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Fproportional commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Output_Fproportional Fproportional => _fproportional ?? (_fproportional = new RsSmab_Output_Fproportional(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Protection commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Output_Protection Protection => _protection ?? (_protection = new RsSmab_Output_Protection(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     User commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Output_User User => _user ?? (_user = new RsSmab_Output_User(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     State commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Output_State State => _state ?? (_state = new RsSmab_Output_State(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     OUTPut<HW>:AMODe
        //     Sets the step attenuator mode at the RF output.
        //     amode: AUTO| FIXed AUTO The step attenuator adjusts the level settings automatically,
        //     within the full variation range. FIXed The step attenuator and amplifier stages
        //     are fixed at the current position, providing level settings with constant output
        //     VSWR. The resulting variation range is calculated according to the position.
        public PowAttModeOutEnum Amode
        {
            get
            {
                return _grpBase.IO.QueryString("OUTPut<HwInstance>:AMODe?").ToScpiEnum<PowAttModeOutEnum>();
            }
            set
            {
                _grpBase.IO.Write("OUTPut<HwInstance>:AMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     OUTPut<HW>:IMPedance
        //     Queries the impedance of the RF outputs.
        //     impedance: G1K| G50| G10K
        public InpImpRfEnum Impedance => _grpBase.IO.QueryString("OUTPut<HwInstance>:IMPedance?").ToScpiEnum<InpImpRfEnum>();

        internal RsSmab_Output(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Output", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Output Clone()
        {
            RsSmab_Output rsSmab_Output = new RsSmab_Output(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Output);
            return rsSmab_Output;
        }
    }
}
