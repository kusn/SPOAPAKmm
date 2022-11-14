using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep_Frequency _frequency;

        private RsSmab_Calculate_Power_Sweep_Power _power;

        private RsSmab_Calculate_Power_Sweep_Time _time;

        //
        // Сводка:
        //     Frequency commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Calculate_Power_Sweep_Frequency Frequency => _frequency ?? (_frequency = new RsSmab_Calculate_Power_Sweep_Frequency(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Calculate_Power_Sweep_Power Power => _power ?? (_power = new RsSmab_Calculate_Power_Sweep_Power(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Time commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 8
        public RsSmab_Calculate_Power_Sweep_Time Time => _time ?? (_time = new RsSmab_Calculate_Power_Sweep_Time(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power_Sweep(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Sweep", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power_Sweep Clone()
        {
            RsSmab_Calculate_Power_Sweep rsSmab_Calculate_Power_Sweep = new RsSmab_Calculate_Power_Sweep(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power_Sweep);
            return rsSmab_Calculate_Power_Sweep;
        }
    }
}
