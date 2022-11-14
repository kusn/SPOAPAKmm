using System.Collections.Generic;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Slist commands group definition
    //     Sub-classes count: 4
    //     Commands count: 2
    //     Total commands count: 9
    public class RsSmab_Slist
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Slist_Clear _clear;

        private RsSmab_Slist_Element _element;

        private RsSmab_Slist_Scan _scan;

        private RsSmab_Slist_Sensor _sensor;

        //
        // Сводка:
        //     Clear commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Slist_Clear Clear => _clear ?? (_clear = new RsSmab_Slist_Clear(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Element commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        //     Repeated Capability: ChannelRepCap, default value after init: ChannelRepCap.Nr1
        public RsSmab_Slist_Element Element => _element ?? (_element = new RsSmab_Slist_Element(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Scan commands group
        //     Sub-classes count: 1
        //     Commands count: 2
        //     Total commands count: 3
        public RsSmab_Slist_Scan Scan => _scan ?? (_scan = new RsSmab_Slist_Scan(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Sensor commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Slist_Sensor Sensor => _sensor ?? (_sensor = new RsSmab_Slist_Sensor(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SLISt:[LIST]
        //     Returns a list of all detected sensors in a comma-separated string.
        //     sensorList: String of comma-separated entries Each entry contains information
        //     on the sensor type, serial number and interface. The order of the entries does
        //     not correspond to the order the sensors are displayed in the "NRP Sensor Mapping"
        //     dialog.
        public List<string> List => _grpBase.IO.QueryStringArray("SLISt:LIST?").ToStringList();

        internal RsSmab_Slist(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Slist", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Slist Clone()
        {
            RsSmab_Slist rsSmab_Slist = new RsSmab_Slist(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Slist);
            return rsSmab_Slist;
        }

        //
        // Сводка:
        //     SLISt:CLEar:[ALL]
        //     Removes all R&S NRP power sensors from the list.
        public void ClearAll()
        {
            _grpBase.IO.Write("SLISt:CLEar:ALL");
        }

        //
        // Сводка:
        //     SLISt:CLEar:[ALL]
        //     Same as ClearAll, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ClearAllAndWait()
        {
            ClearAllAndWait(-1);
        }

        //
        // Сводка:
        //     SLISt:CLEar:[ALL]
        //     Same as ClearAll, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ClearAllAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SLISt:CLEar:ALL", opcTimeoutMs);
        }
    }
}
