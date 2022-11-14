using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Info_Ecount_Name
    {
        private readonly CommandsGroup _grpBase;

        internal RsSmab_Diagnostic_Info_Ecount_Name(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Name", core, parent);
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>:NAME
        //     No additional help available
        //     Used Repeated Capabilities default values:
        //     ErrorCountRepCap.Nr1 (settable in the interface "Ecount")
        public string Get()
        {
            return Get(ErrorCountRepCap.Default);
        }

        //
        // Сводка:
        //     DIAGnostic:INFO:ECOunt<CH>:NAME
        //     No additional help available
        //
        // Параметры:
        //   errorCount:
        //     Repeated capability selector
        public string Get(ErrorCountRepCap errorCount)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(errorCount);
            return _grpBase.IO.QueryString("DIAGnostic:INFO:ECOunt" + repCapCmdValue + ":NAME?").TrimStringResponse();
        }
    }
}
