using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Yscale commands group definition
    //     Sub-classes count: 1
    //     Commands count: 2
    //     Total commands count: 4
    public class RsSmab_Sense_Power_Sweep_Time_Yscale
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Sense_Power_Sweep_Time_Yscale_Auto _auto;

        //
        // Сводка:
        //     Auto commands group
        //     Sub-classes count: 0
        //     Commands count: 2
        //     Total commands count: 2
        public RsSmab_Sense_Power_Sweep_Time_Yscale_Auto Auto => _auto ?? (_auto = new RsSmab_Sense_Power_Sweep_Time_Yscale_Auto(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:MAXimum
        //     Sets the maximum value for the y axis of the measurement diagram.
        //     maximum: float Range: -200 to 100, Unit: dBm
        public double Maximum
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:TIME:YSCale:MAXimum?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:YSCale:MAXimum " + value.ToDoubleString());
            }
        }

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:YSCale:MINimum
        //     Sets the minimum value for the y axis of the measurement diagram.
        //     minimum: float Range: -200 to 100
        public double Minimum
        {
            get
            {
                return _grpBase.IO.QueryDouble("SENSe:POWer:SWEep:TIME:YSCale:MINimum?");
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:YSCale:MINimum " + value.ToDoubleString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Time_Yscale(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Yscale", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Sense_Power_Sweep_Time_Yscale Clone()
        {
            RsSmab_Sense_Power_Sweep_Time_Yscale rsSmab_Sense_Power_Sweep_Time_Yscale = new RsSmab_Sense_Power_Sweep_Time_Yscale(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Sense_Power_Sweep_Time_Yscale);
            return rsSmab_Sense_Power_Sweep_Time_Yscale;
        }
    }
}
