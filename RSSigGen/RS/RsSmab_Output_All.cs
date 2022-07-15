using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_All
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut:ALL:[STATe]
        //     Activates the RF output signal of the instrument.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("OUTPut:ALL:STATe?");
            }
            set
            {
                _grpBase.IO.Write("OUTPut:ALL:STATe " + value.ToBooleanString());
            }
        }

        internal RsSmab_Output_All(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("All", core, parent);
        }
    }
}
