using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Roscillator_External commands group definition
    //     Sub-classes count: 2
    //     Commands count: 3
    //     Total commands count: 6
    public class RsSmab_Source_Roscillator_External
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_Roscillator_External_Frequency _frequency;

        private RsSmab_Source_Roscillator_External_RfOff _rfOff;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Source_Roscillator_External_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Source_Roscillator_External_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     RfOff commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Source_Roscillator_External_RfOff RfOff => _rfOff ?? (_rfOff = new RsSmab_Source_Roscillator_External_RfOff(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:MLRange
        //     Queries the minimum locking range for the selected external reference frequency.
        //     Depending on the RF hardware version, and the installed options, the minimum
        //     locking range vaies. For more information, see data sheet.
        //     minLockRange: string
        public string Mlrange => _grpBase.IO.QueryString("SOURce:ROSCillator:EXTernal:MLRange?").TrimStringResponse();

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:NSBandwidth
        //     Queries the nominal synchronization bandwidth for the selected external reference
        //     frequency and synchronization bandwidth.
        //     nomBandwidth: string
        public string NsBandwidth => _grpBase.IO.QueryString("SOURce:ROSCillator:EXTernal:NSBandwidth?").TrimStringResponse();

        //
        // Сводка:
        //     [SOURce]:ROSCillator:EXTernal:SBANdwidth
        //     Selects the synchronization bandwidth for the external reference signal. Depending
        //     on the RF hardware version, and the installed options, the synchronizsation bandwidth
        //     varies. For more information, see data sheet.
        //     sbandwidth: WIDE| NARRow NARRow The synchronization bandwidth is a few Hz. WIDE
        //     Uses the widest possible synchronization bandwidth.
        public FilterWidthEnum Sbandwidth
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce:ROSCillator:EXTernal:SBANdwidth?").ToScpiEnum<FilterWidthEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce:ROSCillator:EXTernal:SBANdwidth " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Roscillator_External(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("External", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_Roscillator_External Clone()
        {
            RsSmab_Source_Roscillator_External rsSmab_Source_Roscillator_External = new RsSmab_Source_Roscillator_External(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_Roscillator_External);
            return rsSmab_Source_Roscillator_External;
        }
    }
}
