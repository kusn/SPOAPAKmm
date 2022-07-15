using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Ils_Mbeacon commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 17
    public class RsSmab_Source_Ils_Mbeacon
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Ils_Mbeacon_Comid _comid;

        private RsSmab_Source_Ils_Mbeacon_Frequency _frequency;

        private RsSmab_Source_Ils_Mbeacon_Marker _marker;

        //
        // Сводка:
        //     Comid commands group
        //     Sub-classes count: 1
        //     Commands count: 9
        //     Total commands count: 11
        public RsSmab_Source_Ils_Mbeacon_Comid Comid => _comid ?? (_comid = new RsSmab_Source_Ils_Mbeacon_Comid(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Ils_Mbeacon_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Ils_Mbeacon_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Marker commands group
        //     Sub-classes count: 0
        //     Commands count: 3
        //     Total commands count: 3
        public RsSmab_Source_Ils_Mbeacon_Marker Marker => _marker ?? (_marker = new RsSmab_Source_Ils_Mbeacon_Marker(_grpBase.Core, _grpBase));

        internal RsSmab_Source_Ils_Mbeacon(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mbeacon", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Ils_Mbeacon Clone()
        {
            RsSmab_Source_Ils_Mbeacon rsSmab_Source_Ils_Mbeacon = new RsSmab_Source_Ils_Mbeacon(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Ils_Mbeacon);
            return rsSmab_Source_Ils_Mbeacon;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:PRESet
        //     Sets the parameters of the ILS marker beacons component to their default values
        //     (*RST values specified for the commands) . For other ILS preset commands, see
        //     ILS:PRESet.
        public void Preset()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:ILS:MBEacon:PRESet");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void PresetAndWait()
        {
            PresetAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:[ILS]:MBEacon:PRESet
        //     Same as Preset, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void PresetAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:ILS:MBEacon:PRESet", opcTimeoutMs);
        }
    }
}
