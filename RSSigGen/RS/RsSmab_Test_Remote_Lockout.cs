using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Remote_Lockout commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Test_Remote_Lockout
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TEST<HW>:REMote:LOCKout:[STATe]
        //     No additional help available
        public bool State
        {
            set
            {
                _grpBase.IO.Write("TEST<HwInstance>:REMote:LOCKout:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Test_Remote_Lockout(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Lockout", core, parent);
        }
    }
}
