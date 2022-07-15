using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_List_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:POWer:AMODe
        //     No additional help available
        public PowAttModeEnum Amode
        {
            get
            {
                return _grpBase.IO.QueryString("SOURce<HwInstance>:LIST:POWer:AMODe?").ToScpiEnum<PowAttModeEnum>();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:POWer:AMODe " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:POWer:POINts
        //     Queries the number (points) of level entries in the selected list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:POWer:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:POWer
        //     Enters the level values in the selected list. The number of level values must
        //     correspond to the number of frequency values. Existing data is overwritten.
        //     power: Power#1{, Power#2, ...} | block data You can either enter the data as
        //     a list of numbers, or as binary block data. The list of numbers can be of any
        //     length, with the list entries separated by commas. In binary block format, 8
        //     (4) bytes are always interpreted as a floating-point number with double accuracy.
        //     See also :​FORMat[:​DATA]. Range: depends on the installed options , Unit: dBm
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:LIST:POWer?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:LIST:POWer " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_List_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
