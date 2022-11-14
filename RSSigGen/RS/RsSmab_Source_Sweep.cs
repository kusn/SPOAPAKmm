using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep commands group definition
    //     Sub-classes count: 4
    //     Commands count: 2
    //     Total commands count: 35
    public class RsSmab_Source_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Sweep_Combined _combined;

        private RsSmab_Source_Sweep_Marker _marker;

        private RsSmab_Source_Sweep_Power _power;

        private RsSmab_Source_Sweep_Frequency _frequency;

        //
        // Сводка:
        //     Combined commands group
        //     Sub-classes count: 1
        //     Commands count: 5
        //     Total commands count: 6
        public RsSmab_Source_Sweep_Combined Combined => _combined ?? (_combined = new RsSmab_Source_Sweep_Combined(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Marker commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_Source_Sweep_Marker Marker => _marker ?? (_marker = new RsSmab_Source_Sweep_Marker(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 4
        //     Commands count: 6
        //     Total commands count: 11
        public RsSmab_Source_Sweep_Power Power => _power ?? (_power = new RsSmab_Source_Sweep_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 4
        //     Commands count: 7
        //     Total commands count: 15
        public RsSmab_Source_Sweep_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Sweep_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:GENeration
        //     Selects frequency sweep type.
        //     sweepType: STEPped| ANALog STEPped Performs a frequency sweep. ANALog Performs
        //     a continuous analog frequency sweep (ramp) , synchronized with the sweep time
        //     TIME.
        public FreqSweepTypeEnum Generation
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:GENeration?").ToScpiEnum<FreqSweepTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:GENeration " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Sweep Clone()
        {
            RsSmab_Source_Sweep rsSmab_Source_Sweep = new RsSmab_Source_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Sweep);
            return rsSmab_Source_Sweep;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:RESet:[ALL]
        //     Resets all active sweeps to the starting point.
        public void ResetAll()
        {
            _grpBase.IO.Write("SOURce<HwInstance>:SWEep:RESet:ALL");
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:RESet:[ALL]
        //     Same as ResetAll, but waits for the operation to complete before continuing further.
        //     Use the RsSmab.Utilities.OpcTimeout to set the timeout value.
        public void ResetAllAndWait()
        {
            ResetAllAndWait(-1);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:RESet:[ALL]
        //     Same as ResetAll, but waits for the operation to complete before continuing further.
        //     The entered opcTimeoutMs is only valid for this call.
        public void ResetAllAndWait(int opcTimeoutMs)
        {
            _grpBase.IO.WriteWithOpc("SOURce<HwInstance>:SWEep:RESet:ALL", opcTimeoutMs);
        }
    }
}
