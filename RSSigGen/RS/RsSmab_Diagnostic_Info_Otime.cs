using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info_Otime
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DIAGnostic:INFO:OTIMe:SET
        //     No additional help available
        public int Set
        {
            get
            {
                return _grpBase.IO.QueryInt32("DIAGnostic:INFO:OTIMe:SET?");
            }
            set
            {
                _grpBase.IO.Write($"DIAGnostic:INFO:OTIMe:SET {value}");
            }
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:OTIMe
        //     Queries the operating hours of the instrument so far.
        //     operationTime: integer Range: 0 to INT_MAX
        public int Value => _grpBase.IO.QueryInt32("DIAGnostic:INFO:OTIMe?");

        internal RsSmab_Diagnostic_Info_Otime(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Otime", core, parent);
        }
    }
}
