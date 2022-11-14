using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor_Bangle commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Vor_Bangle
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:[BANGle]:DIRection
        //     Sets the reference position of the phase information.
        //     direction: FROM| TO FROM The bearing angle is measured between the geographic
        //     north and the connection line from beacon to airplane. TO The bearing angle is
        //     measured between the geographic north and the connection line from airplane to
        //     beacon.
        public AvionicVorDirEnum Direction
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:VOR:BANGle:DIRection?").ToScpiEnum<AvionicVorDirEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:BANGle:DIRection " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:[BANGle]
        //     Sets the bearing angle between the VAR signal and the reference signal. The orientation
        //     of the angle can be set with [:SOURce<hw>]:VOR[:BANGle]:DIRection.
        //     bangle: float Range: 0 to 360
        public double Value
        {
            get
            {
                return _grpBase.IO.QueryDouble("SOURce<HwInstance>:VOR:BANGle?");
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:VOR:BANGle " + value.ToDoubleString());
            }
        }

        internal RsSmab_Source_Vor_Bangle(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Bangle", core, parent);
        }
    }
}
