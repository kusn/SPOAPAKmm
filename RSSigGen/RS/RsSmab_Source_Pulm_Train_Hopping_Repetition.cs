using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Hopping_Repetition commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_Hopping_Repetition
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:REPetition:POINts
        //     No additional help available
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:PULM:TRAin:HOPPing:REPetition:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:REPetition
        //     No additional help available
        public List<int> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiIntegerArray("SOURce<HwInstance>:PULM:TRAin:HOPPing:REPetition?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:HOPPing:REPetition " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Pulm_Train_Hopping_Repetition(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Repetition", core, parent);
        }
    }
}
