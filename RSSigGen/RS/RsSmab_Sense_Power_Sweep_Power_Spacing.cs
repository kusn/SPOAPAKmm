using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Sense_Power_Sweep_Power_Spacing commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Sense_Power_Sweep_Power_Spacing
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SENSe:[POWer]:SWEep:POWer:SPACing:[MODE]
        //     Selects the spacing for the frequency power analysis.
        //     mode: LINear
        public MeasRespSpacingModeEnum Mode
        {
            get
            {
                return _grpBase.IO.QueryString("SENSe:POWer:SWEep:POWer:SPACing:MODE?").ToScpiEnum<MeasRespSpacingModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SENSe:POWer:SWEep:POWer:SPACing:MODE " + value.ToScpiString());
            }
        }

        internal RsSmab_Sense_Power_Sweep_Power_Spacing(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Spacing", core, parent);
        }
    }
}
