using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Dexchange_Template_User commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_System_Dexchange_Template_User
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:DEXChange:TEMPlate:USER:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:DEXChange:TEMPlate:USER:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:DEXChange:TEMPlate:USER:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DEXChange:TEMPlate:USER:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:TEMPlate:USER:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Dexchange_Template_User(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("User", core, parent);
        }

        //
        // Сводка:
        //     SYSTem:DEXChange:TEMPlate:USER:DELete
        //     No additional help available
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SYSTem:DEXChange:TEMPlate:USER:DELete " + filename.EncloseByQuotes());
        }
    }
}
