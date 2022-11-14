using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Power_Spacing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Power_Spacing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:POWer:SPACing:MODE
        //     Queries the level sweep spacing. The sweep spacing for level sweeps is always
        //     linear.
        //     mode: LINear
        public SpacingEnum Mode => _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:POWer:SPACing:MODE?").ToScpiEnum<SpacingEnum>();

        internal RsSmab_Source_Sweep_Power_Spacing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Spacing", core, parent);
        }
    }
}
