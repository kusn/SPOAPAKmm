using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Power_Alc commands group definition
    //     Sub-classes count: 2
    //     Commands count: 5
    //     Total commands count: 8
    public class RsSmab_Source_Power_Alc
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Power_Alc_Edetector _edetector;

        private RsSmab_Source_Power_Alc_Sonce _sonce;

        //
        // Сводка:
        //     Edetector commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Power_Alc_Edetector Edetector => _edetector ?? (_edetector = new RsSmab_Source_Power_Alc_Edetector(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sonce commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Power_Alc_Sonce Sonce => _sonce ?? (_sonce = new RsSmab_Source_Power_Alc_Sonce(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:DSENsitivity
        //     Sets the sensitivity of the ALC detector.
        //     sensitivity: AUTO| FIXed AUTO Selects the optimum sensitivity automatically.
        //     FIXed Fixes the internal level detector.
        public PowAlcDetSensitivityEnum Dsensitivity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ALC:DSENsitivity?").ToScpiEnum<PowAlcDetSensitivityEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ALC:DSENsitivity " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:MODE
        //     Queries the currently set ALC mode. See POWer.
        //     powAlcMode: 0| AUTO| 1| PRESet| OFFTable| ON| OFF| ONSample| ONTable
        public AlcOnOffAutoEnum Mode => _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ALC:MODE?").ToScpiEnum<AlcOnOffAutoEnum>();

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:OMODe
        //     No additional help available
        public AlcOffModeEnum Omode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ALC:OMODe?").ToScpiEnum<AlcOffModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ALC:OMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:SEARch
        //     No additional help available
        public bool Search
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SOURce<HwInstance>:POWer:ALC:SEARch?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ALC:SEARch " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:POWer:ALC:[STATe]
        //     state: 0| OFF| AUTO| 1| ON| ONTable| PRESet| OFFTable AUTO Adjusts the output
        //     level to the operating conditions automatically. 1|ON Activates internal level
        //     control permanently. OFFTable Controls the level using attenuation values of
        //     the internal ALC table. 0|OFF Provided only for backward compatibility with other
        //     Rohde & Schwarz signal generators. The R&S SMA100B accepts these values and maps
        //     them automatically as follows: 0|OFF = OFFTable ONTable Starts with the attenuation
        //     setting from the table and continues with automatic level control.
        public PowAlcStateWithExtAlcEnum State
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:POWer:ALC:STATe?").ToScpiEnum<PowAlcStateWithExtAlcEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:POWer:ALC:STATe " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Power_Alc(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Alc", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Power_Alc Clone()
        {
            RsSmab_Source_Power_Alc rsSmab_Source_Power_Alc = new RsSmab_Source_Power_Alc(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Power_Alc);
            return rsSmab_Source_Power_Alc;
        }
    }
}
