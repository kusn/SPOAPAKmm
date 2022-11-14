using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_ValRf commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_ValRf
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:VALRf:SLOPe
        //     No additional help available
        public SlopeTypeEnum Slope
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:VALRf:SLOPe?").ToScpiEnum<SlopeTypeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VALRf:SLOPe " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_ValRf(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("ValRf", core, parent);
        }
    }
}
