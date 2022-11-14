using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist_Scan_Usensor commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Slist_Scan_Usensor
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Slist_Scan_Usensor(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Usensor", core, parent);
        }

        //
        // Сводка:
        //     SLISt:SCAN:USENsor
        //     Scans for R&S NRP power sensors connected over a USB interface.
        //
        // Параметры:
        //   deviceId:
        //     String or Integer Range: 0 to 999999
        //
        //   serial:
        //     integer Range: 0 to 999999
        public void Set(string deviceId, int serial)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(deviceId, 0, DataType.String), new ArgSingle(serial, 1, DataType.Integer));
            _grpBase.IO.Write("SLISt:SCAN:USENsor " + text);
        }
    }
}
