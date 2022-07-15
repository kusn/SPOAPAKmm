using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Correction_Cset_Data_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Correction_Cset_Data_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:FREQuency:POINts
        //     Queries the number of frequency/level values in the selected table.
        //     points: integer Range: 0 to 10000
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:CORRection:CSET:DATA:FREQuency:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:CORRection:CSET:DATA:FREQuency
        //     Enters the frequency value in the table selected with [:SOURce<hw>]:CORRection:CSET[:SELect].
        //     frequency: Frequency#1[, Frequency#2, ...] String of values with default unit
        //     Hz.
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:CORRection:CSET:DATA:FREQuency?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:CORRection:CSET:DATA:FREQuency " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Correction_Cset_Data_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
