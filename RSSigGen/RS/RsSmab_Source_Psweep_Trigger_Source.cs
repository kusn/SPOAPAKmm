﻿using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Psweep_Trigger_Source commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Psweep_Trigger_Source
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PSWeep:TRIGger:SOURce:ADVanced
        //     No additional help available
        public TrigSweepImmBusExtEnum Advanced
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:PSWeep:TRIGger:SOURce:ADVanced?").ToScpiEnum<TrigSweepImmBusExtEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PSWeep:TRIGger:SOURce:ADVanced " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Psweep_Trigger_Source(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Source", core, parent);
        }
    }
}
