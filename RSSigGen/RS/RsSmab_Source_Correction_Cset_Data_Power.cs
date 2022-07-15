using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset_Data_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Correction_Cset_Data_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:POWer:POINts
        //     Queries the number of frequency/level values in the selected table.
        //     points: integer Range: 0 to 10000
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:CORRection:CSET:DATA:POWer:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:POWer
        //     Enters the level values to the table selected with [:SOURce<hw>]:CORRection:CSET[:SELect].
        //     power: Power#1[, Power#2, ...] String of values with default unit dB. *RST: 0
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:CORRection:CSET:DATA:POWer?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:CSET:DATA:POWer " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Correction_Cset_Data_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
