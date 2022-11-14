using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Sweep_Marker_Output commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Sweep_Marker_Output
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:SWEep:MARKer:OUTPut:POLarity
        //     Selects the polarity of the marker signal.
        //     polarity: NORMal| INVerted NORMal Marker level is high when after reaching the
        //     mark. INVerted Marker level is low after reaching the mark.
        public NormalInvertedEnum Polarity
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:SWEep:MARKer:OUTPut:POLarity?").ToScpiEnum<NormalInvertedEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:SWEep:MARKer:OUTPut:POLarity " + value.ToScpiString());
            }
        }

        internal RsSmab_Source_Sweep_Marker_Output(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Output", core, parent);
        }
    }
}
