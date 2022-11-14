using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Time_Spacing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Time_Spacing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:TIME:SPACing:[MODE]
        //     Queries the sweep spacing for the power versus time measurement. The spacing
        //     is fixed to linear.
        //     mode: LINear
        public MeasRespSpacingModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:TIME:SPACing:MODE?").ToScpiEnum<MeasRespSpacingModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:TIME:SPACing:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Time_Spacing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Spacing", core, parent);
        }
    }
}
