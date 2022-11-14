using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Dwell_List commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_List_Dwell_List
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DWELl:LIST:POINts
        //     Queries the number (points) of dwell time entries in the selected list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:DWELl:LIST:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:DWELl:LIST
        //     Enters the dwell time values in the selected list in µs.
        //     dwell: Dwell#1{, Dwell#2, ...} | block data You can either enter the data as
        //     a list of numbers, or as binary block data. The list of numbers can be of any
        //     length, with the list entries separated by commas. In binary block format, 8
        //     (4) bytes are always interpreted as a floating-point number with double accuracy.
        //     See also :​FORMat[:​DATA] for more details.
        public List<int> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiIntegerArray("SOURce<HwInstance>:LIST:DWELl:LIST?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:DWELl:LIST " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_List_Dwell_List(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("List", core, parent);
        }
    }
}
