using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_List_Index commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Source_List_Index
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:INDex:STARt
        //     Sets the start and stop index of the index range which defines a subgroup of
        //     frequency/level value pairs in the current list.
        public int Start
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:INDex:STARt?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:LIST:INDex:STARt {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:INDex:STOP
        //     Sets the start and stop index of the index range which defines a subgroup of
        //     frequency/level value pairs in the current list.
        //     stop: integer Index range Only values inside this range are processed in list
        //     mode Range: 0 to list length
        public int Stop
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:INDex:STOP?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:LIST:INDex:STOP {value}");
            }
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LIST:INDex
        //     Sets the list index in LIST:MODE STEP. After the trigger signal, the instrument
        //     processes the frequency and level settings of the selected index.
        //     index: integer
        public int Value
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:LIST:INDex?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:LIST:INDex {value}");
            }
        }

        internal RsSmab_Source_List_Index(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Index", core, parent);
        }
    }
}
