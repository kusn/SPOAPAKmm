using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Chirp_Compression commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Chirp_Compression
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CHIRp:COMPression:RATio
        //     Queries the pulse compression ratio (= product of pulse width (s) and bandwidth
        //     (Hz) ).
        //     ratio: float Range: 0 to 80E6
        public double Ratio => _grpBase.IO.QueryDouble("SOURce<HwInstance>:CHIRp:COMPression:RATio?");

        internal RsSmab_Source_Chirp_Compression(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Compression", core, parent);
        }
    }
}
