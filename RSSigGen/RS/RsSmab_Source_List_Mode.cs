using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Mode commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_List_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:MODE:ADVanced
        //     No additional help available
        public AutoManualModeEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:MODE:ADVanced?").ToScpiEnum<AutoManualModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:MODE:ADVanced " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:MODE
        //     Sets the list mode. The instrument processes the list according to the selected
        //     mode and trigger source. See LIST:TRIG:SOUR AUTO, SING or EXT for the description
        //     of the trigger source settings.
        //     mode: AUTO| STEP AUTO Each trigger event triggers a complete list cycle. STEP
        //     Each trigger event triggers only one step in the list processing cycle. The list
        //     is processed in ascending order.
        public AutoStepEnum Value
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:MODE?").ToScpiEnum<AutoStepEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_List_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
