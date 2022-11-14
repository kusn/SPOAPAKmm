using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Output_Afixed_Range
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     OUTPut<HW>:AFIXed:RANGe:LOWer
        //     Queries the settable minimum/maximum value in mode OUTPut:AMODe FIXed, i.e. when
        //     the attenuator is not being adjusted. See method RsSmab.Output.Amode
        //     lower: float Unit: dBm
        public double Lower => _grpBase.IO.QueryDouble("OUTPut<HwInstance>:AFIXed:RANGe:LOWer?");

        //
        // Сводка:
        //     OUTPut<HW>:AFIXed:RANGe:UPPer
        //     Queries the settable minimum/maximum value in mode OUTPut:AMODe FIXed, i.e. when
        //     the attenuator is not being adjusted. See method RsSmab.Output.Amode
        //     upper: float Unit: dBm
        public double Upper => _grpBase.IO.QueryDouble("OUTPut<HwInstance>:AFIXed:RANGe:UPPer?");

        internal RsSmab_Output_Afixed_Range(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Range", core, parent);
        }
    }
}
