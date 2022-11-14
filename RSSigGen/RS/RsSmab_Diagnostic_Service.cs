using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Diagnostic_Service
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     DIAGnostic<HW>:SERVice:SFUNction
        //     No additional help available
        public string Sfunction
        {
            get
            {
                return _grpBase.IO.QueryString("DIAGnostic<HwInstance>:SERVice:SFUNction?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("DIAGnostic<HwInstance>:SERVice:SFUNction " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     DIAGnostic:SERVice
        //     No additional help available
        public bool Value
        {
            get
            {
                return _grpBase.IO.QueryBoolean("DIAGnostic:SERVice?");
            }
            set
            {
                _grpBase.IO.Write("DIAGnostic:SERVice " + value.ToBooleanString());
            }
        }

        internal RsSmab_Diagnostic_Service(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Service", core, parent);
        }
    }
}
