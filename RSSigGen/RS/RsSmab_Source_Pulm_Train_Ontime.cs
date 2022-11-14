using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Ontime commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_Ontime
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:ONTime:POINts
        //     Queries the number of on and off time entries and repetitions in the selected
        //     list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:PULM:TRAin:ONTime:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:ONTime
        //     Enters the pulse on/off times values in the selected list.
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:PULM:TRAin:ONTime?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:ONTime " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Pulm_Train_Ontime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Ontime", core, parent);
        }
    }
}
