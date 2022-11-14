using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Test_Res commands group definition
    //     Sub-classes count: 0
    //     Commands count: 3
    //     Total commands count: 3
    public class RsSmab_Test_Res
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     TEST:RES:COLor
        //     No additional help available
        public ColourEnum Color
        {
            get
            {
                return _grpBase.IO.QueryString("TEST:RES:COLor?").ToScpiEnum<ColourEnum>();
            }
            set
            {
                _grpBase.IO.Write("TEST:RES:COLor " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     TEST:RES:TEXT
        //     No additional help available
        public string Text
        {
            get
            {
                return _grpBase.IO.QueryString("TEST:RES:TEXT?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("TEST:RES:TEXT " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     TEST:RES:WIND
        //     No additional help available
        public bool Wind
        {
            get
            {
                return _grpBase.IO.QueryBoolean("TEST:RES:WIND?");
            }
            set
            {
                _grpBase.IO.Write("TEST:RES:WIND " + value.ToBooleanString());
            }
        }

        internal RsSmab_Test_Res(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Res", core, parent);
        }
    }
}
