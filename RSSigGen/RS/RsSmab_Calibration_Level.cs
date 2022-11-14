using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calibration_Level commands group definition
    //     Sub-classes count: 8
    //     Commands count: 2
    //     Total commands count: 17
    public class RsSmab_Calibration_Level
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_Level_Alinearize _alinearize;

        private RsSmab_Calibration_Level_Amplifier _amplifier;

        private RsSmab_Calibration_Level_Attenuator _attenuator;

        private RsSmab_Calibration_Level_DetAtt _detAtt;

        private RsSmab_Calibration_Level_Dlinearize _dlinearize;

        private RsSmab_Calibration_Level_Opu _opu;

        private RsSmab_Calibration_Level_SwAmplifier _swAmplifier;

        private RsSmab_Calibration_Level_Measure _measure;

        //
        // Сводка:
        //     Alinearize commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_Alinearize Alinearize => _alinearize ?? (_alinearize = new RsSmab_Calibration_Level_Alinearize(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Amplifier commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Calibration_Level_Amplifier Amplifier => _amplifier ?? (_amplifier = new RsSmab_Calibration_Level_Amplifier(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Attenuator commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Calibration_Level_Attenuator Attenuator => _attenuator ?? (_attenuator = new RsSmab_Calibration_Level_Attenuator(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     DetAtt commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_DetAtt DetAtt => _detAtt ?? (_detAtt = new RsSmab_Calibration_Level_DetAtt(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dlinearize commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_Dlinearize Dlinearize => _dlinearize ?? (_dlinearize = new RsSmab_Calibration_Level_Dlinearize(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Opu commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Calibration_Level_Opu Opu => _opu ?? (_opu = new RsSmab_Calibration_Level_Opu(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SwAmplifier commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_SwAmplifier SwAmplifier => _swAmplifier ?? (_swAmplifier = new RsSmab_Calibration_Level_SwAmplifier(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Measure commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Level_Measure Measure => _measure ?? (_measure = new RsSmab_Calibration_Level_Measure(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CALibration:LEVel:BWIDth
        //     No additional help available
        public CalPowBandwidthEnum Bandwidth
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration:LEVel:BWIDth?").ToScpiEnum<CalPowBandwidthEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration:LEVel:BWIDth " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     CALibration<HW>:LEVel:STATe
        //     No additional help available
        public StateExtendedEnum State
        {
            get
            {
                return _grpBase.IO.QueryString("CALibration<HwInstance>:LEVel:STATe?").ToScpiEnum<StateExtendedEnum>();
            }
            set
            {
                _grpBase.IO.Write("CALibration<HwInstance>:LEVel:STATe " + value.ToScpiString());
            }
        }

        internal RsSmab_Calibration_Level(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Level", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration_Level Clone()
        {
            RsSmab_Calibration_Level rsSmab_Calibration_Level = new RsSmab_Calibration_Level(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration_Level);
            return rsSmab_Calibration_Level;
        }
    }
}
