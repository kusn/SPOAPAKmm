using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info_PoCount
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DIAGnostic:INFO:POCount:SET
        //     No additional help available
        public int Set
        {
            get
            {
                return _grpBase.IO.QueryInt32("DIAGnostic:INFO:POCount:SET?");
            }
            set
            {
                _grpBase.IO.Write($"DIAGnostic:INFO:POCount:SET {value}");
            }
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:POCount
        //     Queris how often the instrument has been turned on so far.
        //     powerOnCount: integer Range: 0 to INT_MAX
        public int Value => _grpBase.IO.QueryInt32("DIAGnostic:INFO:POCount?");

        internal RsSmab_Diagnostic_Info_PoCount(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("PoCount", core, parent);
        }
    }
}
