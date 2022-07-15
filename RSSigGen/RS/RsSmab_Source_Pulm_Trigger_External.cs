using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Trigger_External commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Pulm_Trigger_External
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRIGger:EXTernal:IMPedance
        //     No additional help available
        public InpImpRfEnum Impedance
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PULM:TRIGger:EXTernal:IMPedance?").ToScpiEnum<InpImpRfEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRIGger:EXTernal:IMPedance " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Pulm_Trigger_External(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("External", core, parent);
        }
    }
}
