using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_Vor_Reference commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_Source_Vor_Reference
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     [SOURce<HW>]:VOR:REFerence:[DEViation]
        //     Sets the frequency deviation of the reference signal on the FM carrier.
        //     deviation: integer Range: 0 to 960
        public int Deviation
        {
            get
            {
                return _grpBase.IO.QueryInt32("SOURce<HwInstance>:VOR:REFerence:DEViation?");
            }
            set
            {
                _grpBase.IO.Write($"SOURce<HwInstance>:VOR:REFerence:DEViation {value}");
            }
        }

        internal RsSmab_Source_Vor_Reference(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Reference", core, parent);
        }
    }
}
