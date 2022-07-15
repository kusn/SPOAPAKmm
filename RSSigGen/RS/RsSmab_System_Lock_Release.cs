using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Lock_Release commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_System_Lock_Release
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:LOCK:RELease:ALL
        //     Revokes the exclusive access to the instrument.
        public string All
        {
            set
            {
                _grpBase.IO.Write("SYSTem:LOCK:RELease:ALL " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     SYSTem:LOCK:RELease
        //     No additional help available
        public string Value
        {
            set
            {
                _grpBase.IO.Write("SYSTem:LOCK:RELease " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_System_Lock_Release(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Release", core, parent);
        }
    }
}
