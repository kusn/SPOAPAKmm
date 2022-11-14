using RSSigGen.InstrumentDrivers.Internal;
namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Frequency
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep_Frequency_Math _math;

        //
        // Сводка:
        //     Math commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        //     Repeated Capability: MathRepCap, default value after init: MathRepCap.Nr1
        public RsSmab_Calculate_Power_Sweep_Frequency_Math Math => _math ?? (_math = new RsSmab_Calculate_Power_Sweep_Frequency_Math(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power_Sweep_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power_Sweep_Frequency Clone()
        {
            RsSmab_Calculate_Power_Sweep_Frequency rsSmab_Calculate_Power_Sweep_Frequency = new RsSmab_Calculate_Power_Sweep_Frequency(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power_Sweep_Frequency);
            return rsSmab_Calculate_Power_Sweep_Frequency;
        }
    }
}
