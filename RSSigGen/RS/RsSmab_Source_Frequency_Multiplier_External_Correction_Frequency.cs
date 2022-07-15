using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency commands group
    //     definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:FREQuency:POINts
        //     No additional help available
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:FREQuency:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:FREQuency
        //     No additional help available
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:FREQuency?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:FREQuency " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Frequency_Multiplier_External_Correction_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
