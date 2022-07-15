using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_OffTime commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_OffTime
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:OFFTime:POINts
        //     Queries the number of on and off time entries and repetitions in the selected
        //     list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:PULM:TRAin:OFFTime:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:OFFTime
        //     Enters the pulse on/off times values in the selected list.
        //     offTime: Offtime#1{, Offtime#2, ...} | binary block data List of comma-separated
        //     numeric values or binary block data, where: The list of numbers can be of any
        //     length. In binary block format, 8 (4) bytes are always interpreted as a floating-point
        //     number with double accuracy. See :​FORMat[:​DATA] for details. The maximum length
        //     is 2047 values. Range: 0 ns to 5 ms
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:PULM:TRAin:OFFTime?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:OFFTime " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Pulm_Train_OffTime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("OffTime", core, parent);
        }
    }
}
