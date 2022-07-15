using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calibration
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calibration_All _all;

        private RsSmab_Calibration_Csynthesis _csynthesis;

        private RsSmab_Calibration_Data _data;

        private RsSmab_Calibration_Detector _detector;

        private RsSmab_Calibration_FmOffset _fmOffset;

        private RsSmab_Calibration_Frequency _frequency;

        private RsSmab_Calibration_Level _level;

        private RsSmab_Calibration_LfOutput _lfOutput;

        private RsSmab_Calibration_Mode _mode;

        private RsSmab_Calibration_Roscillator _roscillator;

        private RsSmab_Calibration_Selected _selected;

        private RsSmab_Calibration_Tselected _tselected;

        //
        // Сводка:
        //     All commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Calibration_All All => _all ?? (_all = new RsSmab_Calibration_All(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Csynthesis commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_Csynthesis Csynthesis => _csynthesis ?? (_csynthesis = new RsSmab_Calibration_Csynthesis(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Data commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Calibration_Data Data => _data ?? (_data = new RsSmab_Calibration_Data(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Detector commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Calibration_Detector Detector => _detector ?? (_detector = new RsSmab_Calibration_Detector(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     FmOffset commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_FmOffset FmOffset => _fmOffset ?? (_fmOffset = new RsSmab_Calibration_FmOffset(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Calibration_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Calibration_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Level commands group
        //     Sub-classes count: 8
        //     Commands count: 2
        //     Total commands count: 17
        public RsSmab_Calibration_Level Level => _level ?? (_level = new RsSmab_Calibration_Level(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     LfOutput commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Calibration_LfOutput LfOutput => _lfOutput ?? (_lfOutput = new RsSmab_Calibration_LfOutput(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Mode commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Calibration_Mode Mode => _mode ?? (_mode = new RsSmab_Calibration_Mode(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Roscillator commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Calibration_Roscillator Roscillator => _roscillator ?? (_roscillator = new RsSmab_Calibration_Roscillator(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Selected commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Calibration_Selected Selected => _selected ?? (_selected = new RsSmab_Calibration_Selected(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Tselected commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Calibration_Tselected Tselected => _tselected ?? (_tselected = new RsSmab_Calibration_Tselected(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     CALibration<HW>:CONTinueonerror
        //     Continues the calibration even though an error was detected. By default adjustments
        //     are aborted on error.
        //     state: 0| 1| OFF| ON
        public bool ContinueOnError
        {
            get
            {
                return _grpBase.IO.QueryBoolean("CALibration<HwInstance>:CONTinueonerror?");
            }
            set
            {
                _grpBase.IO.Write("CALibration<HwInstance>:CONTinueonerror " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     CALibration<HW>:DEBug
        //     No additional help available
        public bool Debug
        {
            set
            {
                _grpBase.IO.Write("CALibration<HwInstance>:DEBug " + value.ToBooleanString());
            }
        }

        internal RsSmab_Calibration(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Calibration", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calibration Clone()
        {
            RsSmab_Calibration rsSmab_Calibration = new RsSmab_Calibration(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calibration);
            return rsSmab_Calibration;
        }
    }
}
