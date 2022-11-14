using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_LffSweep_Source commands group definition
    //     Sub-classes count: 1
    //     Commands count: 1
    //     Total commands count: 2
    public class RsSmab_Trigger_LffSweep_Source
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Trigger_LffSweep_Source_Advanced _advanced;

        //
        // Сводка:
        //     Advanced commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Trigger_LffSweep_Source_Advanced Advanced => _advanced ?? (_advanced = new RsSmab_Trigger_LffSweep_Source_Advanced(_grpBase.Core, _grpBase));

        internal RsSmab_Trigger_LffSweep_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Trigger_LffSweep_Source Clone()
        {
            RsSmab_Trigger_LffSweep_Source rsSmab_Trigger_LffSweep_Source = new RsSmab_Trigger_LffSweep_Source(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Trigger_LffSweep_Source);
            return rsSmab_Trigger_LffSweep_Source;
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce
        //     Table Header: Selects the trigger source for the corresponding sweeps: - FSWeep
        //     - RF frequency, - LFFSweep - LF frequency, - PSWeep - RF level, - SWEep - all
        //     sweeps The source names of the parameters correspond to the values provided in
        //     manual control of the instrument. They differ from the SCPI-compliant names,
        //     but the instrument accepts both variants. Use the SCPI name, if compatibility
        //     is an important issue. Find the corresponding SCPI-compliant commands in Cross-reference
        //     between the manual and remote control.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        //
        // Параметры:
        //   source:
        //     AUTO| IMMediate | SINGle| BUS | EXTernal | EAUTo AUTO [IMMediate] Executes a
        //     sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. when a sweep is completed, the next one starts immediately.
        //     SINGle [BUS] Executes one complete sweep cycle. The following commands initiate
        //     a trigger event: *TRG SWEep:POWer:EXECute EXECute :​TRIGgerhw[:​SWEep][:​IMMediate],
        //     method RsSmab.Trigger.Sweep.Immediate.Set and method RsSmab.Trigger.Sweep.Immediate.Set.
        //     Set the sweep mode with the commands: SWEep:POWer:MODEAUTO|STEP MODEAUTO|STEP
        //     LFOutput:MODEAUTO|STEP In step mode (STEP) , the instrument executes only one
        //     step. EXTernal An external signal triggers the sweep. EAUTo An external signal
        //     triggers the sweep. When one sweep is finished, the next sweep starts. A second
        //     trigger event stops the sweep at the current frequency, a third trigger event
        //     starts the trigger at the start frequency, and so on.
        public void Set(SingExtAutoEnum source)
        {
            Set(source, InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce
        //     Table Header: Selects the trigger source for the corresponding sweeps: - FSWeep
        //     - RF frequency, - LFFSweep - LF frequency, - PSWeep - RF level, - SWEep - all
        //     sweeps The source names of the parameters correspond to the values provided in
        //     manual control of the instrument. They differ from the SCPI-compliant names,
        //     but the instrument accepts both variants. Use the SCPI name, if compatibility
        //     is an important issue. Find the corresponding SCPI-compliant commands in Cross-reference
        //     between the manual and remote control.
        //
        // Параметры:
        //   source:
        //     AUTO| IMMediate | SINGle| BUS | EXTernal | EAUTo AUTO [IMMediate] Executes a
        //     sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. when a sweep is completed, the next one starts immediately.
        //     SINGle [BUS] Executes one complete sweep cycle. The following commands initiate
        //     a trigger event: *TRG SWEep:POWer:EXECute EXECute :​TRIGgerhw[:​SWEep][:​IMMediate],
        //     method RsSmab.Trigger.Sweep.Immediate.Set and method RsSmab.Trigger.Sweep.Immediate.Set.
        //     Set the sweep mode with the commands: SWEep:POWer:MODEAUTO|STEP MODEAUTO|STEP
        //     LFOutput:MODEAUTO|STEP In step mode (STEP) , the instrument executes only one
        //     step. EXTernal An external signal triggers the sweep. EAUTo An external signal
        //     triggers the sweep. When one sweep is finished, the next sweep starts. A second
        //     trigger event stops the sweep at the current frequency, a third trigger event
        //     starts the trigger at the start frequency, and so on.
        //
        //   inputIx:
        //     Repeated capability selector
        public void Set(SingExtAutoEnum source, InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("TRIGger" + repCapCmdValue + ":LFFSweep:SOURce " + source.ToScpiString());
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce
        //     Table Header: Selects the trigger source for the corresponding sweeps: - FSWeep
        //     - RF frequency, - LFFSweep - LF frequency, - PSWeep - RF level, - SWEep - all
        //     sweeps The source names of the parameters correspond to the values provided in
        //     manual control of the instrument. They differ from the SCPI-compliant names,
        //     but the instrument accepts both variants. Use the SCPI name, if compatibility
        //     is an important issue. Find the corresponding SCPI-compliant commands in Cross-reference
        //     between the manual and remote control.
        //     source: AUTO| IMMediate | SINGle| BUS | EXTernal | EAUTo AUTO [IMMediate] Executes
        //     a sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. when a sweep is completed, the next one starts immediately.
        //     SINGle [BUS] Executes one complete sweep cycle. The following commands initiate
        //     a trigger event: *TRG SWEep:POWer:EXECute EXECute :​TRIGgerhw[:​SWEep][:​IMMediate],
        //     method RsSmab.Trigger.Sweep.Immediate.Set and method RsSmab.Trigger.Sweep.Immediate.Set.
        //     Set the sweep mode with the commands: SWEep:POWer:MODEAUTO|STEP MODEAUTO|STEP
        //     LFOutput:MODEAUTO|STEP In step mode (STEP) , the instrument executes only one
        //     step. EXTernal An external signal triggers the sweep. EAUTo An external signal
        //     triggers the sweep. When one sweep is finished, the next sweep starts. A second
        //     trigger event stops the sweep at the current frequency, a third trigger event
        //     starts the trigger at the start frequency, and so on.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        public SingExtAutoEnum Get()
        {
            return Get(InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:LFFSweep:SOURce
        //     Table Header: Selects the trigger source for the corresponding sweeps: - FSWeep
        //     - RF frequency, - LFFSweep - LF frequency, - PSWeep - RF level, - SWEep - all
        //     sweeps The source names of the parameters correspond to the values provided in
        //     manual control of the instrument. They differ from the SCPI-compliant names,
        //     but the instrument accepts both variants. Use the SCPI name, if compatibility
        //     is an important issue. Find the corresponding SCPI-compliant commands in Cross-reference
        //     between the manual and remote control.
        //     source: AUTO| IMMediate | SINGle| BUS | EXTernal | EAUTo AUTO [IMMediate] Executes
        //     a sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. when a sweep is completed, the next one starts immediately.
        //     SINGle [BUS] Executes one complete sweep cycle. The following commands initiate
        //     a trigger event: *TRG SWEep:POWer:EXECute EXECute :​TRIGgerhw[:​SWEep][:​IMMediate],
        //     method RsSmab.Trigger.Sweep.Immediate.Set and method RsSmab.Trigger.Sweep.Immediate.Set.
        //     Set the sweep mode with the commands: SWEep:POWer:MODEAUTO|STEP MODEAUTO|STEP
        //     LFOutput:MODEAUTO|STEP In step mode (STEP) , the instrument executes only one
        //     step. EXTernal An external signal triggers the sweep. EAUTo An external signal
        //     triggers the sweep. When one sweep is finished, the next sweep starts. A second
        //     trigger event stops the sweep at the current frequency, a third trigger event
        //     starts the trigger at the start frequency, and so on.
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public SingExtAutoEnum Get(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            return _grpBase.IO.QueryString("TRIGger" + repCapCmdValue + ":LFFSweep:SOURce?").ToScpiEnum<SingExtAutoEnum>();
        }
    }
}
