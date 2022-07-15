using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Unit commands group definition
    //     Sub-classes count: 1
    //     Commands count: 0
    //     Total commands count: 1
    public class RsSmab_Sense_Unit
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Unit_Power _power;

        //
        // Сводка:
        //     Power commands group
        //     Sub-classes count: 0
        //     Commands count: 1
        //     Total commands count: 1
        public RsSmab_Sense_Unit_Power Power => _power ?? (_power = new RsSmab_Sense_Unit_Power(_grpBase.Core, _grpBase));

        internal RsSmab_Sense_Unit(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Unit", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Unit Clone()
        {
            RsSmab_Sense_Unit rsSmab_Sense_Unit = new RsSmab_Sense_Unit(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Unit);
            return rsSmab_Sense_Unit;
        }
    }
}
