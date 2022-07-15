using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Frequency_Multiplier_External_Correction_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Frequency_Multiplier_External_Correction_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:POWer:POINts
        //     No additional help available
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:POWer:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:FREQuency:MULTiplier:EXTernal:CORRection:POWer
        //     No additional help available
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:POWer?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:FREQuency:MULTiplier:EXTernal:CORRection:POWer " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Frequency_Multiplier_External_Correction_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
