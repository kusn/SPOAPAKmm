using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Frequency commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_List_Frequency
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:FREQuency:POINts
        //     Queries the number (points) of frequency entries in the seleced list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:FREQuency:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:FREQuency
        //     Enters the frequency values in the selected list.
        //     frequency: Frequency#1{, Frequency#2, ...} | block data You can either enter
        //     the data as a list of numbers, or as binary block data. The list of numbers can
        //     be of any length, with the list entries separated by commas. In binary block
        //     format, 8 (4) bytes are always interpreted as a floating-point number with double
        //     accuracy. See also :​FORMat[:​DATA]. Range: 300 kHz to RFmax (depends on the
        //     installed options)
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:LIST:FREQuency?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:FREQuency " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_List_Frequency(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Frequency", core, parent);
        }
    }
}
