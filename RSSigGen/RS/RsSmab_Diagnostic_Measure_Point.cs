using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Measure_Point
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Measure_Point(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Point", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic<HW>:[MEASure]:POINt
        //     Triggers the voltage measurement at the specified test point and returns the
        //     measured voltage. For more information, see R&S SMA100B Service Manual.
        //     value: valueunit
        //
        // Параметры:
        //   name:
        //     test point identifier Test point name, as queried with the command method RsSmab.Diagnostic.Point.Catalog
        public string Get(string name)
        {
            return _grpBase.IO.QueryString("DIAGnostic<HwInstance>:MEASure:POINt? " + name.EncloseByQuotes()).TrimStringResponse();
        }
    }
}
