using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Dexchange_Template_Predefined commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Dexchange_Template_Predefined
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DEXChange:TEMPlate:PREDefined:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:DEXChange:TEMPlate:PREDefined:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:DEXChange:TEMPlate:PREDefined:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DEXChange:TEMPlate:PREDefined:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:TEMPlate:PREDefined:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Dexchange_Template_Predefined(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Predefined", core, parent);
        }
    }
}
