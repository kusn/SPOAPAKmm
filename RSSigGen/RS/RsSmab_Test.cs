using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test commands group definition
    //     Sub-classes count: 7
    //     Commands count: 3
    //     Total commands count: 14
    public class RsSmab_Test
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Test_All _all;

        private RsSmab_Test_Device _device;

        private RsSmab_Test_Remote _remote;

        private RsSmab_Test_Res _res;

        private RsSmab_Test_Serror _serror;

        private RsSmab_Test_Sw _sw;

        private RsSmab_Test_Write _write;

        //
        // Сводка:
        //     All commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Test_All All => _all ?? (_all = new RsSmab_Test_All(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Device commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Test_Device Device => _device ?? (_device = new RsSmab_Test_Device(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Remote commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Test_Remote Remote => _remote ?? (_remote = new RsSmab_Test_Remote(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Res commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Test_Res Res => _res ?? (_res = new RsSmab_Test_Res(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Serror commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_Test_Serror Serror => _serror ?? (_serror = new RsSmab_Test_Serror(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sw commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Test_Sw Sw => _sw ?? (_sw = new RsSmab_Test_Sw(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Write commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Test_Write Write => _write ?? (_write = new RsSmab_Test_Write(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     TEST:LEVel
        //     No additional help available
        public SelftLevEnum Level
        {
            get
            {
                return _grpBase.IO.QueryString("TEST:LEVel?").ToScpiEnum<SelftLevEnum>();
            }
            set
            {
                _grpBase.IO.Write("TEST:LEVel " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     TEST:NRPTrigger
        //     No additional help available
        public bool NrpTrigger
        {
            set
            {
                _grpBase.IO.Write("TEST:NRPTrigger " + value.ToBooleanString());
            }
        }

        internal RsSmab_Test(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Test", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Test Clone()
        {
            RsSmab_Test rsSmab_Test = new RsSmab_Test(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Test);
            return rsSmab_Test;
        }

        //
        // Сводка:
        //     TEST:PRESet
        //     No additional help available
        public void Preset()
        {
            _grpBase.IO.Write("TEST:PRESet");
        }

        //
        // Сводка:
        //     TEST:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     TEST:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("TEST:PRESet", opcTimeoutMs);
        }
    }
}
