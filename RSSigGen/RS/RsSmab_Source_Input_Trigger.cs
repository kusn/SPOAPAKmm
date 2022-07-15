using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Input_Trigger commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Input_Trigger
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce]:INPut:TRIGger:SLOPe
        //     Sets the polarity of the active slope of an applied instrument trigger.
        //     slope: NEGative| POSitive
        public SlopeTypeEnum Slope
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:INPut:TRIGger:SLOPe?").ToScpiEnum<SlopeTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:INPut:TRIGger:SLOPe " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Input_Trigger(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Trigger", core, parent);
        }
    }
}
