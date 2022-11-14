using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Trigger_FpSweep_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Trigger_FpSweep_Source
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Trigger_FpSweep_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }

        //
        // Сводка:
        //     TRIGger<HW>:FPSWeep:SOURce
        //     Selects the trigger source for the combined RF frequency / level sweep. The parameter
        //     names correspond to the manual control. If needed, see table Table "Cross-reference
        //     between the manual and remote control " for selecting the trigger source with
        //     SCPI compliant parameter names.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        //
        // Параметры:
        //   fpTrigSource:
        //     AUTO| IMMediate | SINGle| BUS| EXTernal | EAUTo AUTO|IMMediate Executes the combined
        //     RF sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. as soon as a sweep is completed, the next one starts immediately.
        //     SINGle|BUS Executes one complete sweep cycle triggered by the GPIB commands SWEep:COMBined:EXECute
        //     or *TRG. The mode has to be set to [:SOURcehw]:SWEep:COMBined:MODE AUTO. EXTernal
        //     An external signal triggers the sweep. EAUTo An external signal triggers the
        //     sweep. As soon as one sweep is finished, the next sweep starts. A second trigger
        //     event stops the sweep at the current frequency and level value pairs, a third
        //     trigger event starts the trigger at the start values, and so on.
        public void Set(SingExtAutoEnum fpTrigSource)
        {
            Set(fpTrigSource, InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:FPSWeep:SOURce
        //     Selects the trigger source for the combined RF frequency / level sweep. The parameter
        //     names correspond to the manual control. If needed, see table Table "Cross-reference
        //     between the manual and remote control " for selecting the trigger source with
        //     SCPI compliant parameter names.
        //
        // Параметры:
        //   fpTrigSource:
        //     AUTO| IMMediate | SINGle| BUS| EXTernal | EAUTo AUTO|IMMediate Executes the combined
        //     RF sweep automatically. In this free-running mode, the trigger condition is met
        //     continuously. I.e. as soon as a sweep is completed, the next one starts immediately.
        //     SINGle|BUS Executes one complete sweep cycle triggered by the GPIB commands SWEep:COMBined:EXECute
        //     or *TRG. The mode has to be set to [:SOURcehw]:SWEep:COMBined:MODE AUTO. EXTernal
        //     An external signal triggers the sweep. EAUTo An external signal triggers the
        //     sweep. As soon as one sweep is finished, the next sweep starts. A second trigger
        //     event stops the sweep at the current frequency and level value pairs, a third
        //     trigger event starts the trigger at the start values, and so on.
        //
        //   inputIx:
        //     Repeated capability selector
        public void Set(SingExtAutoEnum fpTrigSource, InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            _grpBase.IO.Write("TRIGger" + repCapCmdValue + ":FPSWeep:SOURce " + fpTrigSource.ToScpiString());
        }

        //
        // Сводка:
        //     TRIGger<HW>:FPSWeep:SOURce
        //     Selects the trigger source for the combined RF frequency / level sweep. The parameter
        //     names correspond to the manual control. If needed, see table Table "Cross-reference
        //     between the manual and remote control " for selecting the trigger source with
        //     SCPI compliant parameter names.
        //     fpTrigSource: AUTO| IMMediate | SINGle| BUS| EXTernal | EAUTo AUTO|IMMediate
        //     Executes the combined RF sweep automatically. In this free-running mode, the
        //     trigger condition is met continuously. I.e. as soon as a sweep is completed,
        //     the next one starts immediately. SINGle|BUS Executes one complete sweep cycle
        //     triggered by the GPIB commands SWEep:COMBined:EXECute or *TRG. The mode has to
        //     be set to [:SOURcehw]:SWEep:COMBined:MODE AUTO. EXTernal An external signal triggers
        //     the sweep. EAUTo An external signal triggers the sweep. As soon as one sweep
        //     is finished, the next sweep starts. A second trigger event stops the sweep at
        //     the current frequency and level value pairs, a third trigger event starts the
        //     trigger at the start values, and so on.
        //     Used Repeated Capabilities default values:
        //     InputIxRepCap.Nr1 (settable in the interface "Trigger")
        public SingExtAutoEnum Get()
        {
            return Get(InputIxRepCap.Default);
        }

        //
        // Сводка:
        //     TRIGger<HW>:FPSWeep:SOURce
        //     Selects the trigger source for the combined RF frequency / level sweep. The parameter
        //     names correspond to the manual control. If needed, see table Table "Cross-reference
        //     between the manual and remote control " for selecting the trigger source with
        //     SCPI compliant parameter names.
        //     fpTrigSource: AUTO| IMMediate | SINGle| BUS| EXTernal | EAUTo AUTO|IMMediate
        //     Executes the combined RF sweep automatically. In this free-running mode, the
        //     trigger condition is met continuously. I.e. as soon as a sweep is completed,
        //     the next one starts immediately. SINGle|BUS Executes one complete sweep cycle
        //     triggered by the GPIB commands SWEep:COMBined:EXECute or *TRG. The mode has to
        //     be set to [:SOURcehw]:SWEep:COMBined:MODE AUTO. EXTernal An external signal triggers
        //     the sweep. EAUTo An external signal triggers the sweep. As soon as one sweep
        //     is finished, the next sweep starts. A second trigger event stops the sweep at
        //     the current frequency and level value pairs, a third trigger event starts the
        //     trigger at the start values, and so on.
        //
        // Параметры:
        //   inputIx:
        //     Repeated capability selector
        public SingExtAutoEnum Get(InputIxRepCap inputIx)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(inputIx);
            return _grpBase.IO.QueryString("TRIGger" + repCapCmdValue + ":FPSWeep:SOURce?").ToScpiEnum<SingExtAutoEnum>();
        }
    }
}
