using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Repetition commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_Repetition
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:REPetition:POINts
        //     Queries the number of on and off time entries and repetitions in the selected
        //     list.
        //     points: integer Range: 0 to INT_MAX
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:PULM:TRAin:REPetition:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:REPetition
        //     Sets the number of repetitions for each pulse on/off time value pair.
        //     repetition: Repetition#1{, Repetition#2, ...} 0 = ignore value pair Set "Repetition
        //     = 0" to skip a particular pulse without deleting the pulse on/off time value
        //     pair Range: 0 to 65535
        public List<int> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiIntegerArray("SOURce<HwInstance>:PULM:TRAin:REPetition?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:REPetition " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Pulm_Train_Repetition(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Repetition", core, parent);
        }
    }
}
