using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_System_Undo_Hid commands group definition
    //     Sub-classes count: 0
    //     Commands count: 1
    //     Total commands count: 1
    public class RsSmab_System_Undo_Hid
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     SYSTem:UNDO:HID:SELect
        //     No additional help available
        public int Select
        {
            set
            {
                _grpBase.IO.Write($"SYSTem:UNDO:HID:SELect {value}");
            }
        }

        internal RsSmab_System_Undo_Hid(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Hid", core, parent);
        }
    }
}
