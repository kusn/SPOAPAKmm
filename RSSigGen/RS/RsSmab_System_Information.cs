﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Information commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Information
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:INFormation:SR
        //     No additional help available
        public string Sr
        {
            get
            {
                return _grpBase.IO.QueryString("SYSTem:INFormation:SR?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("SYSTem:INFormation:SR " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Information(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Information", core, parent);
        }
    }
}
