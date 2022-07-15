using System.Collections.Generic;
using System.Linq;
using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Pulm_Train_Hopping_Power commands group definition
    //     Sub-classes count: 0
    //     Commands count: 2
    //     Total commands count: 2
    public class RsSmab_Source_Pulm_Train_Hopping_Power
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:POWer:POINts
        //     No additional help available
        public int Points => _grpBase.IO.QueryInt32("SOURce<HwInstance>:PULM:TRAin:HOPPing:POWer:POINts?");

        //
        // Сводка:
        //     [SOURce<HW>]:PULM:TRAin:HOPPing:POWer
        //     No additional help available
        public List<double> Value
        {
            get
            {
                return _grpBase.IO.QueryBinaryOrAsciiFloatArray("SOURce<HwInstance>:PULM:TRAin:HOPPing:POWer?").ToList();
            }
            set
            {
                _grpBase.IO.Write("SOURce<HwInstance>:PULM:TRAin:HOPPing:POWer " + value.ToCsvString());
            }
        }

        internal RsSmab_Source_Pulm_Train_Hopping_Power(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Power", core, parent);
        }
    }
}
