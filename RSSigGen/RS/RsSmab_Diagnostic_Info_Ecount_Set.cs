using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info_Ecount_Set
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Info_Ecount_Set(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Set", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>:SET
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ErrorCountRepCap.Nr1 (settable in the interface "Ecount")
        public void Set(int ecount)
        {
            Set(ecount, ErrorCountRepCap.Default);
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>:SET
        //     No additional help available
        //
        // Параметры:
        //   errorCount:
        //     Repeated capability selector
        public void Set(int ecount, ErrorCountRepCap errorCount)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(errorCount);
            _grpBase.IO.Write($"DIAGnostic:INFO:ECOunt{repCapCmdValue}:SET {ecount}");
        }
    }
}
