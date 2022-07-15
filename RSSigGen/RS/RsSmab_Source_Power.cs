using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power commands group definition
    //     Sub-classes count: 8
    //     Commands count: 8
    //     Total commands count: 37
    public class RsSmab_Source_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Power_Alc _alc;

        private RsSmab_Source_Power_Attenuation _attenuation;

        private RsSmab_Source_Power_Emf _emf;

        private RsSmab_Source_Power_Limit _limit;

        private RsSmab_Source_Power_Range _range;

        private RsSmab_Source_Power_Spc _spc;

        private RsSmab_Source_Power_Step _step;

        private RsSmab_Source_Power_Level _level;

        //
        // Сводка:
        //     Alc commands group
        //     Sub-classes count: 2
        //     Commands count: 5
        //     Total commands count: 8
        public RsSmab_Source_Power_Alc Alc => _alc ?? (_alc = new RsSmab_Source_Power_Alc(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Attenuation commands group
        //     Sub-classes count: 1
        //     Commands count: 3
        //     Total commands count: 4
        public RsSmab_Source_Power_Attenuation Attenuation => _attenuation ?? (_attenuation = new RsSmab_Source_Power_Attenuation(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Emf commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Power_Emf Emf => _emf ?? (_emf = new RsSmab_Source_Power_Emf(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Limit commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Power_Limit Limit => _limit ?? (_limit = new RsSmab_Source_Power_Limit(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Range commands group
        //     Sub-classes count: 0
        //     Commands count: 4
        //     Total commands count: 4
        public RsSmab_Source_Power_Range Range => _range ?? (_range = new RsSmab_Source_Power_Range(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Spc commands group
        //     Sub-classes count: 0
        //     Commands count: 6
        //     Total commands count: 6
        public RsSmab_Source_Power_Spc Spc => _spc ?? (_spc = new RsSmab_Source_Power_Spc(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Step commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Power_Step Step => _step ?? (_step = new RsSmab_Source_Power_Step(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Level commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Source_Power_Level Level => _level ?? (_level = new RsSmab_Source_Power_Level(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:LBEHaviour
        //     behaviour: AUTO| UNINterrupted| MONotone| CVSWr| HDUN UNINterrupted|MONotone
        //     Uninterrupted level settings and strictly monotone modes. CVSWr Constant VSWR
        //     HDUN High dynamic uninterrupted level settings.
        public PowLevBehaviourEnum Lbehaviour
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:LBEHaviour?").ToScpiEnum<PowLevBehaviourEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LBEHaviour " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:LMODe
        //     Sets the RF level mode.
        //     levMode: NORMal| LOWNoise| LOWDistortion NORMal Supplies the RF signal with the
        //     standard power level of the instrument. LOWNoise Supplies a very low noise sinewave
        //     signal. LOWDistortion Supplies a very pure sinewave signal.
        public PowLevModeEnum Lmode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:LMODe?").ToScpiEnum<PowLevModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:LMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:MANual
        //     Sets the level for the subsequent sweep step if SWEep:POWer:MODE. Use a separate
        //     command for each sweep step.
        //     manual: float You can select any level within the setting range, where: STARt
        //     is set with POWer:STARt STOP is set with POWer:STOP OFFSet is set with OFFSet
        //     Range: (STARt + OFFSet) to (STOP + OFFSet) , Unit: dBm
        public double Manual
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:MANual?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:MANual " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:MODE
        //     Selects the operating mode of the instrument to set the output level.
        //     mode: CW| FIXed| SWEep CW|FIXed Operates at a constant level. CW and FIXed are
        //     synonyms. To set the output level value, use the command [:​SOURcehw]:​POWer[:​LEVel][:​IMMediate][:​AMPLitude].
        //     SWEep Sets sweep mode. Set the range and current level with the commands: POWer:STARt
        //     and POWer:STOP, POWer:MANual.
        public LfFreqModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:MODE?").ToScpiEnum<LfFreqModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:MODE " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:POWer
        //     Sets the level at the RF output connector. This value does not consider a specified
        //     offset. The command [:​SOURce<hw>]:​POWer[:​LEVel][:​IMMediate][:​AMPLitude]
        //     sets the level of the "Level" display, that means the level containing offset.
        //     See "RF frequency and level display with a downstream instrument".
        //     power: float Level at the RF output, without level offset Range: See data sheet
        //     , Unit: dBm
        public double Power
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:POWer?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:POWer " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:STARt
        //     Sets the RF start/stop level in sweep mode.
        public double Start
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:STARt?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:STARt " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:STOP
        //     Sets the RF start/stop level in sweep mode.
        //     stop: float Sets the setting range calculated as follows: (Level_min + OFFSet)
        //     to (Level_max + OFFSet) Where the values are set with the commands: OFFSet POWer:STARt
        //     POWer:STOP Range: Minimum level to maximum level , Unit: dBm
        public double Stop
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:POWer:STOP?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:STOP " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     [SOURce]:POWer:WIGNore
        //     Ignores level range warnings.
        //     state: 0| 1| OFF| ON
        public bool Wignore
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce:POWer:WIGNore?");
            }
            set
            {
                _grpBase.IO.Write("SOURce:POWer:WIGNore " + value.ToBooleanString());
            }
        }

        internal RsSmab_Source_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Power Clone()
        {
            RsSmab_Source_Power rsSmab_Source_Power = new RsSmab_Source_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Power);
            return rsSmab_Source_Power;
        }
    }
}
