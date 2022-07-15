using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Initiate_List_Mode
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     INITiate:LIST:MODE:CONTinuous
        //     No additional help available
        public bool Continuous
        {
            get
            {
                return _grpBase.IO.QueryBoolean("INITiate:LIST:MODE:CONTinuous?");
            }
            set
            {
                _grpBase.IO.Write("INITiate:LIST:MODE:CONTinuous " + value.ToBooleanString());
            }
        }

        internal RsSmab_Initiate_List_Mode(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Mode", core, parent);
        }
    }
}
