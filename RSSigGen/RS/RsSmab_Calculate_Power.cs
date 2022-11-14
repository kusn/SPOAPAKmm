using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep _sweep;

        //
        // Сводка:
        //     Sweep commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_Calculate_Power_Sweep Sweep => _sweep ?? (_sweep = new RsSmab_Calculate_Power_Sweep(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power Clone()
        {
            RsSmab_Calculate_Power rsSmab_Calculate_Power = new RsSmab_Calculate_Power(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power);
            return rsSmab_Calculate_Power;
        }
    }
}
