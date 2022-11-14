using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Am_Deviation commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Am_Deviation
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:AM:DEViation:MODE
        //     Selects the coupling mode. The coupling mode parameter also determines the mode
        //     for fixing the total depth.
        //     amDevMode: UNCoupled| TOTal| RATio UNCoupled Does not couple the LF signals.
        //     The deviation depth values of both paths are independent. TOTal Couples the deviation
        //     depth of both paths. RATio Couples the deviation depth ratio of both paths
        public ModulationDevModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:AM:DEViation:MODE?").ToScpiEnum<ModulationDevModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:AM:DEViation:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Am_Deviation(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Deviation", core, parent);
        }
    }
}
