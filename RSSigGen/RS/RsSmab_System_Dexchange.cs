using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Dexchange commands group definition
    //     Sub-classes count: 3
    //     Commands count: 5
    //     Total commands count: 12
    public class RsSmab_System_Dexchange
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_System_Dexchange_Execute _execute;

        private RsSmab_System_Dexchange_Template _template;

        private RsSmab_System_Dexchange_Transaction _transaction;

        //
        // Сводка:
        //     Execute commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Dexchange_Execute Execute => _execute ?? (_execute = new RsSmab_System_Dexchange_Execute(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Template commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 5
        public RsSmab_System_Dexchange_Template Template => _template ?? (_template = new RsSmab_System_Dexchange_Template(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Transaction commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_System_Dexchange_Transaction Transaction => _transaction ?? (_transaction = new RsSmab_System_Dexchange_Transaction(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SYSTem:DEXChange:CATalog
        //     No additional help available
        public List<string> Catalog => _grpBase.IO.QueryStringArray("SYSTem:DEXChange:CATalog?").ToStringList();

        //
        // Сводка:
        //     SYSTem:DEXChange:DEBug
        //     No additional help available
        public bool Debug
        {
            get
            {
                return _grpBase.IO.QueryBoolean("SYSTem:DEXChange:DEBug?");
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:DEBug " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     SYSTem:DEXChange:FORMat
        //     No additional help available
        public DevExpFormatEnum Format
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DEXChange:FORMat?").ToScpiEnum<DevExpFormatEnum>();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:FORMat " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     SYSTem:DEXChange:SELect
        //     No additional help available
        public string Select
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:DEXChange:SELect?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:DEXChange:SELect " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Dexchange(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Dexchange", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_System_Dexchange Clone()
        {
            RsSmab_System_Dexchange rsSmab_System_Dexchange = new RsSmab_System_Dexchange(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_System_Dexchange);
            return rsSmab_System_Dexchange;
        }

        //
        // Сводка:
        //     SYSTem:DEXChange:DELete
        //     No additional help available
        public void Delete(string filename)
        {
            _grpBase.IO.Write("SYSTem:DEXChange:DELete " + filename.EncloseByQuotes());
        }
    }
}
