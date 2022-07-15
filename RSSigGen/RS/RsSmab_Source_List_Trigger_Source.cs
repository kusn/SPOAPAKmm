using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Trigger_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_List_Trigger_Source
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:TRIGger:SOURce:ADVanced
        //     No additional help available
        public TrigSweepImmBusExtEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:TRIGger:SOURce:ADVanced?").ToScpiEnum<TrigSweepImmBusExtEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:TRIGger:SOURce:ADVanced " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:TRIGger:SOURce
        //     Selects the trigger source for processing lists. The designation of the parameters
        //     correspond to those in sweep mode. SCPI standard uses other designations for
        //     the parameters, which are also accepted by the instrument. The SCPI designation
        //     should be used if compatibility is an important consideration. For an overview,
        //     see the following table:
        //     • Rohde & Schwarz parameter / SCPI parameter / Applies to the list mode parameters:
        //     –
        //     • AUTO / IMMediate / [:SOURce<hw>]:LIST:MODE AUTO
        //     • SINGle / BUS / [:SOURce<hw>]:LIST:MODE AUTO or [:SOURce<hw>]:LIST:MODE STEP
        //     • EXTernal / EXTernal / [:SOURce<hw>]:LIST:MODE AUTO or [:SOURce<hw>]:LIST:MODE
        //     STEP
        //     source: AUTO| IMMediate| SINGle| BUS| EXTernal AUTO|IMMediate The trigger is
        //     free-running, i.e. the trigger condition is fulfilled continuously. The selected
        //     list is restarted as soon as it is finished. SINGle|BUS The list is triggered
        //     by the command LIST:TRIGger:EXECute. The list is executed once. EXTernal The
        //     list is triggered externally and executed once.
        public TrigSweepSourNoHopExtAutoEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:TRIGger:SOURce?").ToScpiEnum<TrigSweepSourNoHopExtAutoEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:TRIGger:SOURce " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_List_Trigger_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }
    }
}
