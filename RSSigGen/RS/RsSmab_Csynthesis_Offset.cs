using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Csynthesis_Offset
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     CSYNthesis:OFFSet:STATe
        //     Activates a DC offset.
        //     state: 0| 1| OFF| ON
        public bool State
        {
            get
            {
                return _grpBase.IO.QueryBoolean("CSYNthesis:OFFSet:STATe?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:OFFSet:STATe " + value.ToBooleanString());
            }
        }

        //
        // Сводка:
        //     CSYNthesis:OFFSet
        //     Sets the value of the DC offset.
        //     offset: float Range: -5 to 5
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("CSYNthesis:OFFSet?");
            }
            set
            {
                _grpBase.IO.Write("CSYNthesis:OFFSet " + value.ToDoubleString());
            }
        }

        internal RsSmab_Csynthesis_Offset(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Offset", core, parent);
        }
    }
}
