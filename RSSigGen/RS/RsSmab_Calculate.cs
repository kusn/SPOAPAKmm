using RSSigGen.InstrumentDrivers.Internal;


namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Calculate commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 12
    public class RsSmab_Calculate
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power _power;

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 12
        public RsSmab_Calculate_Power Power => _power ?? (_power = new RsSmab_Calculate_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Calculate", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate Clone()
        {
            RsSmab_Calculate rsSmab_Calculate = new RsSmab_Calculate(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate);
            return rsSmab_Calculate;
        }
    }
}
