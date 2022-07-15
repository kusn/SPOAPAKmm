using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Calculate_Power_Sweep_Time
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Calculate_Power_Sweep_Time_Gate _gate;

        private RsSmab_Calculate_Power_Sweep_Time_Math _math;

        //
        // Сводка:
        //     Gate commands group
        //     Sub-classes count: 6
        //     Commands count: 0
        //     Total commands count: 6
        //     Repeated Capability: GateRepCap, default value after init: GateRepCap.Nr1
        public RsSmab_Calculate_Power_Sweep_Time_Gate Gate => _gate ?? (_gate = new RsSmab_Calculate_Power_Sweep_Time_Gate(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Math commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        //     Repeated Capability: MathRepCap, default value after init: MathRepCap.Nr1
        public RsSmab_Calculate_Power_Sweep_Time_Math Math => _math ?? (_math = new RsSmab_Calculate_Power_Sweep_Time_Math(_grpBase.Core, _grpBase));

        internal RsSmab_Calculate_Power_Sweep_Time(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Time", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Calculate_Power_Sweep_Time Clone()
        {
            RsSmab_Calculate_Power_Sweep_Time rsSmab_Calculate_Power_Sweep_Time = new RsSmab_Calculate_Power_Sweep_Time(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Calculate_Power_Sweep_Time);
            return rsSmab_Calculate_Power_Sweep_Time;
        }
    }
}
