using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Status_Questionable_Bit commands group definition
    //     Sub-classes count: 5
    //     Commands count: 0
    //     Total commands count: 5
    //     Repeated Capability: BitNumberNullRepCap, default value after init: BitNumberNullRepCap.Nr0
    public class RsSmab_Status_Questionable_Bit
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Status_Questionable_Bit_Condition _condition;

        private RsSmab_Status_Questionable_Bit_Enable _enable;

        private RsSmab_Status_Questionable_Bit_Ntransition _ntransition;

        private RsSmab_Status_Questionable_Bit_Ptransition _ptransition;

        private RsSmab_Status_Questionable_Bit_Event _event;

        //
        // Сводка:
        //     Repeated Capability default value numeric suffix. This value is used, if you
        //     do not explicitely set it in the set/get methods, or if you leave it to BitNumberNullRepCap.Default
        //     Default value after init: BitNumberNullRepCap.Nr0
        public BitNumberNullRepCap RepCapBitNumberNull
        {
            get
            {
                return (BitNumberNullRepCap)_grpBase.GetRepCapEnumValue();
            }
            set
            {
                _grpBase.SetRepCapEnumValue(value);
            }
        }

        //
        // Сводка:
        //     Condition commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Questionable_Bit_Condition Condition => _condition ?? (_condition = new RsSmab_Status_Questionable_Bit_Condition(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Enable commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Questionable_Bit_Enable Enable => _enable ?? (_enable = new RsSmab_Status_Questionable_Bit_Enable(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ntransition commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Questionable_Bit_Ntransition Ntransition => _ntransition ?? (_ntransition = new RsSmab_Status_Questionable_Bit_Ntransition(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Ptransition commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Questionable_Bit_Ptransition Ptransition => _ptransition ?? (_ptransition = new RsSmab_Status_Questionable_Bit_Ptransition(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Event commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Status_Questionable_Bit_Event Event => _event ?? (_event = new RsSmab_Status_Questionable_Bit_Event(_grpBase.Core, _grpBase));

        internal RsSmab_Status_Questionable_Bit(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bit", core, parent);
            _grpBase.RepCap = new RepeatedCapability(typeof(BitNumberNullRepCap), _grpBase.GroupName, "RepCapBitNumberNull", BitNumberNullRepCap.Nr0);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Status_Questionable_Bit Clone()
        {
            RsSmab_Status_Questionable_Bit rsSmab_Status_Questionable_Bit = new RsSmab_Status_Questionable_Bit(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Status_Questionable_Bit);
            return rsSmab_Status_Questionable_Bit;
        }
    }
}
