using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_LffSweep_Source_Advanced commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trigger_LffSweep_Source_Advanced
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trigger_LffSweep_Source_Advanced(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Advanced", core, parent);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce:ADVanced
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        public void Set(TrigSweepImmBusExtEnum lfTrigSourAdv)
        {
            Set(lfTrigSourAdv, InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce:ADVanced
        //     No additional help available
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public void Set(TrigSweepImmBusExtEnum lfTrigSourAdv, InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("TRIGger" + repCapCmdValue + ":LFFSweep:SOURce:ADVanced " + lfTrigSourAdv.ToScpiString());
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce:ADVanced
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        public TrigSweepImmBusExtEnum Get()
        {
            return Get(InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce:ADVanced
        //     No additional help available
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public TrigSweepImmBusExtEnum Get(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            return _grpBase.IO.QueryString("TRIGger" + repCapCmdValue + ":LFFSweep:SOURce:ADVanced?").ToScpiEnum<TrigSweepImmBusExtEnum>();
        }
    }
}
